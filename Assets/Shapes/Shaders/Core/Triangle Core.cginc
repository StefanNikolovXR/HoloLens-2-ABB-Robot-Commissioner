// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
#include "UnityCG.cginc"
#include "../Shapes.cginc"
#pragma target 3.0

UNITY_INSTANCING_BUFFER_START(Props)
UNITY_DEFINE_INSTANCED_PROP( half4, _Color )
UNITY_DEFINE_INSTANCED_PROP( half4, _ColorB )
UNITY_DEFINE_INSTANCED_PROP( half4, _ColorC )
UNITY_DEFINE_INSTANCED_PROP( float3, _A )
UNITY_DEFINE_INSTANCED_PROP( float3, _B )
UNITY_DEFINE_INSTANCED_PROP( float3, _C )
UNITY_DEFINE_INSTANCED_PROP( half, _Roundness )
UNITY_DEFINE_INSTANCED_PROP( half, _Hollow )
UNITY_DEFINE_INSTANCED_PROP( half, _Thickness )
UNITY_DEFINE_INSTANCED_PROP( half, _ThicknessSpace )
UNITY_DEFINE_INSTANCED_PROP( half, _ScaleMode )
UNITY_INSTANCING_BUFFER_END(Props)

#define IP_A intp0.xy
#define IP_B intp0.zw
#define IP_C intp1.xy
#define IP_Pos intp1.zw
#define IP_AB intp2.x
#define IP_BC intp2.y
#define IP_CA intp2.z
#define IP_HALF_THICKNESS intp2.w
#define IP_DISTANCES intp2.xyz

struct VertexInput {
    float4 vertex : POSITION;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};
struct VertexOutput {
    half4 pos : SV_POSITION;
    half4 color : TEXCOORD0;
    half4 intp0 : TEXCOORD1;
    half4 intp1 : TEXCOORD2;
    half4 intp2 : TEXCOORD3;
    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};

// constructs a matrix where A to B is the X axis direction
inline half3x3 GetTriangleToProjectionSpaceMatrix( half abDistance, half3 a, half3 b, half3 c ) {
    half3 xAxis = (b-a)/abDistance; // we don't calculate abDist in here as it's already needed outside of this function
    half3 zAxis = normalize(cross(b-a, c-a));
    half3 yAxis = cross(xAxis, zAxis); // AB normal
    return half3x3( xAxis, yAxis, zAxis );
}

inline half4 GetColor( VertexInput v, half3 weights ) {
    half4 colorA = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
    half4 colorB = UNITY_ACCESS_INSTANCED_PROP(Props, _ColorB);
    half4 colorC = UNITY_ACCESS_INSTANCED_PROP(Props, _ColorC);
    return WeightedSum( weights, colorA, colorB, colorC );
}

VertexOutput vert (VertexInput v) {
    UNITY_SETUP_INSTANCE_ID(v);
    VertexOutput o = (VertexOutput)0;
    UNITY_TRANSFER_INSTANCE_ID(v, o);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
    
    half3 w = v.vertex.xyz; // vertex weights
    o.color = GetColor( v, w ); // colors

    // local space vertex positions
    bool useUniformScale = UNITY_ACCESS_INSTANCED_PROP(Props, _ScaleMode) == SCALE_MODE_UNIFORM;
    half3 objScale = GetObjectScale();
  
    half3 coordinateScaling = useUniformScale ? half3(1,1,1) : objScale; 
    half3 a = UNITY_ACCESS_INSTANCED_PROP(Props, _A) * coordinateScaling;
    half3 b = UNITY_ACCESS_INSTANCED_PROP(Props, _B) * coordinateScaling;
    half3 c = UNITY_ACCESS_INSTANCED_PROP(Props, _C) * coordinateScaling;

    // construct a 2D space and project all vertices
    o.IP_AB = length(b-a); // distance from a to b. this distance is the same as in projection space
    half3x3 mtxLocalToProj = GetTriangleToProjectionSpaceMatrix( o.IP_AB, a, b, c );

    // triangle corners in projection space
    half2 aProj = mul((half2x3)mtxLocalToProj,a);
    half2 bProj = mul((half2x3)mtxLocalToProj,b);
    half2 cProj = mul((half2x3)mtxLocalToProj,c);

    // calculate incircle, then make projection coordinates relative to the incenter
    o.IP_BC = distance(bProj,cProj);
    o.IP_CA = distance(cProj,aProj);
    Circle incircle = GetIncirclePosRadius( aProj, bProj, cProj, o.IP_AB, o.IP_BC, o.IP_CA );
    aProj -= incircle.pos; 
    bProj -= incircle.pos;
    cProj -= incircle.pos;
    
    half roundness = UNITY_ACCESS_INSTANCED_PROP(Props, _Roundness);
    half thickness = UNITY_ACCESS_INSTANCED_PROP(Props, _Thickness);
    int thicknessSpace = UNITY_ACCESS_INSTANCED_PROP(Props, _ThicknessSpace);

    half3 center = LocalToWorldPos( ((a+b+c)/3)/coordinateScaling );
    LineWidthData widthData = GetScreenSpaceWidthDataSimple(center, CAM_UP, thickness, thicknessSpace );

    // thinness fade
    o.color.a *= saturate(widthData.thicknessPixelsTarget);
    
    o.IP_HALF_THICKNESS = 0.5*widthData.thicknessMeters/incircle.r; // todo: space scaling
    bool hollow = UNITY_ACCESS_INSTANCED_PROP(Props, _Hollow) > 0;

    half padding = 0;//hollow ? thickness/2 : 0;

    #if LOCAL_ANTI_ALIASING_QUALITY > 0
        half uniformScale = useUniformScale ? GetUniformScale(objScale) : 1;
        padding += AA_PADDING_PX/(widthData.pxPerMeter*uniformScale); // extra padding for LAA
    #endif

    // outer vertices in projection space. with no padding, they equal aProj etc
    half2 aProjOuter = aProj;
    half2 bProjOuter = bProj;
    half2 cProjOuter = cProj;

    // handle extra padding for anti-aliasing
    if( padding > 0 ) {
        // edge normal directions in projection space 
        half2 nAB = half2(0,1); // projection space is already aligned with a to b
        half2 nBC = Rotate90Left((cProj-bProj)/o.IP_BC); // divide normalizes here
        half2 nCA = Rotate90Left((aProj-cProj)/o.IP_CA);
        
        // 2D miter offset directions
        half2 miterVecA = GetMiterOffsetDirFast( nCA, nAB, padding );
        half2 miterVecB = GetMiterOffsetDirFast( nAB, nBC, padding );
        half2 miterVecC = GetMiterOffsetDirFast( nBC, nCA, padding );

        // add local space padding
        half3x3 mtxProjToLocal = transpose(mtxLocalToProj);
        a += mul(mtxProjToLocal, miterVecA);
        b += mul(mtxProjToLocal, miterVecB);
        c += mul(mtxProjToLocal, miterVecC);

        // calculate the post-padding projection coords
        aProjOuter = aProj + miterVecA;
        bProjOuter = bProj + miterVecB;
        cProjOuter = cProj + miterVecC;
    }

    o.IP_Pos = WeightedSum( w, aProjOuter, bProjOuter, cProjOuter ) / incircle.r; // scale by inverse inradius

    // scale by inverse inradius, then move inner points based on roundness
    o.IP_A = (aProj/incircle.r)*(1-roundness);
    o.IP_B = (bProj/incircle.r)*(1-roundness);
    o.IP_C = (cProj/incircle.r)*(1-roundness);
    o.IP_DISTANCES = (o.IP_DISTANCES/incircle.r)*(1-roundness); // rescale distances too
    
    // set local space positions
    v.vertex.xyz = WeightedSum( w, a, b, c ); 
    o.pos = UnityObjectToClipPos( v.vertex / coordinateScaling );
    return o;
}

inline half SdfToMaskBordered( half sdf, bool hollow, half halfThickness ) {
    if( hollow )
        return StepAAExplicitPD( -abs(sdf+halfThickness)+halfThickness, sdf );
    return StepAA(-sdf);
}

inline half GetMask( VertexOutput i ) {

    half roundness = UNITY_ACCESS_INSTANCED_PROP(Props, _Roundness);
    bool hollow = UNITY_ACCESS_INSTANCED_PROP(Props, _Hollow) > 0;

    // no rounding, use three planes instead
    if( roundness < 0.002 ) {
        #if LOCAL_ANTI_ALIASING_QUALITY > 0
            half sdfAB = SdfLine( i.IP_Pos, i.IP_A, i.IP_B ) / i.IP_AB;      
            half sdfBC = SdfLine( i.IP_Pos, i.IP_B, i.IP_C ) / i.IP_BC;
            half sdfCA = SdfLine( i.IP_Pos, i.IP_C, i.IP_A ) / i.IP_CA;
            half sdf = max(sdfAB, max(sdfBC, sdfCA));
            return SdfToMaskBordered(sdf, hollow, i.IP_HALF_THICKNESS );
        #else
            return 1; // no AA and no rounding, so, no sdfs needed
        #endif
    }

    // 100% rounded, just use an incircle disc
    if( roundness > 0.998 ) 
        return SdfToMaskBordered( length( i.IP_Pos )-1, hollow, i.IP_HALF_THICKNESS );

    // rounded triangle, use full triangle SDF
    return SdfToMaskBordered( SdfTriangle( i.IP_Pos, i.IP_A, i.IP_B, i.IP_C ) - roundness, hollow, i.IP_HALF_THICKNESS );
} 

FRAG_OUTPUT_V4 frag( VertexOutput i ) : SV_Target {
    UNITY_SETUP_INSTANCE_ID(i);
    return ShapesOutput( i.color, GetMask( i ) );
}