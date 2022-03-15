// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
#include "UnityCG.cginc"
#include "../Shapes.cginc"
#pragma target 3.0

UNITY_INSTANCING_BUFFER_START(Props)
UNITY_DEFINE_INSTANCED_PROP(int, _ScaleMode)
UNITY_DEFINE_INSTANCED_PROP(half4, _Color)
UNITY_DEFINE_INSTANCED_PROP(half4, _Rect)
#ifdef CORNER_RADIUS
    UNITY_DEFINE_INSTANCED_PROP(half4, _CornerRadii)
#endif
#ifdef BORDERED
    UNITY_DEFINE_INSTANCED_PROP(half, _Thickness)
	UNITY_DEFINE_INSTANCED_PROP(half, _ThicknessSpace)
#endif
SHAPES_FILL_PROPERTIES
UNITY_INSTANCING_BUFFER_END(Props)

#define IP_uv0 intp0.xy
#define IP_nrmCoord intp0.zw
#define IP_rect intp1
#define IP_thickness intp2.x
#define IP_pxCoverage intp2.y

struct VertexInput {
    float4 vertex : POSITION;
	UNITY_VERTEX_INPUT_INSTANCE_ID
};
struct VertexOutput {
    float4 pos : SV_POSITION;
	SHAPES_INTERPOLATOR_FILL(0)
    half4 intp0 : TEXCOORD1;
    half4 intp1 : TEXCOORD2;
    #if defined(BORDERED) || defined(CORNER_RADIUS)
        half2 intp2 : TEXCOORD3;
    #endif
	UNITY_VERTEX_INPUT_INSTANCE_ID
	UNITY_VERTEX_OUTPUT_STEREO
};

VertexOutput vert (VertexInput v) {
	UNITY_SETUP_INSTANCE_ID(v);
    VertexOutput o = (VertexOutput)0;
	UNITY_TRANSFER_INSTANCE_ID(v, o);
	UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
	
	half4 rect = UNITY_ACCESS_INSTANCED_PROP(Props, _Rect);

	#ifdef BORDERED
		half thickness = UNITY_ACCESS_INSTANCED_PROP(Props, _Thickness);
		half thicknessSpace = UNITY_ACCESS_INSTANCED_PROP(Props, _ThicknessSpace);
	#else
		half thickness = 1; 
		half thicknessSpace = THICKN_SPACE_METERS;
	#endif

	// needed for LAA padding, even if not hollow
	LineWidthData wd = GetScreenSpaceWidthDataSimple( LocalToWorldPos(v.vertex), CAM_UP, thickness, thicknessSpace );
	
	#if defined(BORDERED)
		o.IP_pxCoverage = saturate(wd.thicknessPixelsTarget);
		o.IP_thickness = wd.thicknessMeters;
	#endif
	
	#if defined(BORDERED) || defined(CORNER_RADIUS)
	    o.IP_nrmCoord = v.vertex.xy;
	#endif

    int scaleMode = UNITY_ACCESS_INSTANCED_PROP(Props, _ScaleMode);
	half2 objScale = GetObjectScaleXY();
	half2 rectScale = scaleMode == SCALE_MODE_UNIFORM ? 1 : objScale;
	rect *= rectScale.xyxy;
	o.IP_rect = rect;

	half2 padScale = scaleMode == SCALE_MODE_UNIFORM ? objScale : 1;
	half2 padding = AA_PADDING_PX / (wd.pxPerMeter * padScale);
	
	v.vertex.xy = Remap( half2(-1, -1), half2(1, 1), rect.xy - padding.xy, rect.xy + rect.zw + padding.xy, v.vertex );
    o.IP_uv0 = v.vertex.xy;
	v.vertex.xy /= rectScale;
    o.pos = UnityObjectToClipPos( v.vertex );
	SHAPES_TRANSFER_FILL
    return o;
}

FRAG_OUTPUT_V4 frag( VertexOutput i ) : SV_Target {
	UNITY_SETUP_INSTANCE_ID(i);
	
	//half4 rect = UNITY_ACCESS_INSTANCED_PROP(Props, _Rect);
	half2 rectCenter = i.IP_rect.xy + i.IP_rect.zw/2;
	
	#ifdef CORNER_RADIUS
	    half4 cornerRadii = UNITY_ACCESS_INSTANCED_PROP(Props, _CornerRadii);
	    fixed2 sgn = sign(i.IP_nrmCoord);
        int rComp = sgn.x-0.5*sgn.x*sgn.y+1.5; // thanks @khyperia <3
	    half cornerRadius = cornerRadii[rComp];
	    half maxRadius = min(i.IP_rect.z, i.IP_rect.w) / 2;
	    cornerRadius = min( cornerRadius, maxRadius );
    #endif
	
	// base sdf
	#ifdef CORNER_RADIUS
        half2 indentBoxSize = (i.IP_rect.zw - cornerRadius.xx*2);
        half boxSdf = SdfBox( i.IP_uv0.xy - rectCenter, indentBoxSize/2 ) - cornerRadius;
    #else
        half boxSdf = SdfBox( i.IP_uv0.xy - rectCenter, i.IP_rect.zw/2 );
    #endif
    
    // apply border to sdf
    #ifdef BORDERED
	    half thickness = i.IP_thickness;
        half halfthick = thickness / 2;
	    #if LOCAL_ANTI_ALIASING_QUALITY > 0
            half boxSdfPd = PD( boxSdf ); // todo: this has minor artifacts on inner corners, might want to separate masks by axis
            boxSdf = abs(boxSdf + halfthick) - halfthick;
            half shape_mask = 1.0-StepThresholdPD( boxSdf, boxSdfPd );
        #else
            boxSdf = abs(boxSdf + halfthick) - halfthick;
            half shape_mask = 1-StepAA(boxSdf);
        #endif
		shape_mask *= i.IP_pxCoverage;
	#else
        half shape_mask = 1.0-StepAA( boxSdf );
    #endif
    
	half4 shape_color = SHAPES_GET_FILL_COLOR;
	
	return ShapesOutput( shape_color, shape_mask );
}