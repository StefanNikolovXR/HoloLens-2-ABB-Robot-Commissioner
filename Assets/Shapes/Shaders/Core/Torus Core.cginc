// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
#include "UnityCG.cginc"
#include "../Shapes.cginc"
#pragma target 3.0

UNITY_INSTANCING_BUFFER_START(Props)
UNITY_DEFINE_INSTANCED_PROP(int, _ScaleMode)
UNITY_DEFINE_INSTANCED_PROP(half4, _Color)
UNITY_DEFINE_INSTANCED_PROP(half, _Radius)
UNITY_DEFINE_INSTANCED_PROP(half, _RadiusSpace)
UNITY_DEFINE_INSTANCED_PROP(half, _Thickness)
UNITY_DEFINE_INSTANCED_PROP(half, _ThicknessSpace)
UNITY_INSTANCING_BUFFER_END(Props)

struct VertexInput {
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	UNITY_VERTEX_INPUT_INSTANCE_ID
};
struct VertexOutput {
	float4 pos : SV_POSITION;
	half pxCoverage : TEXCOORD0;
	UNITY_VERTEX_INPUT_INSTANCE_ID
	UNITY_VERTEX_OUTPUT_STEREO
};

VertexOutput vert(VertexInput v) {
	UNITY_SETUP_INSTANCE_ID(v);
	VertexOutput o = (VertexOutput)0;
	UNITY_TRANSFER_INSTANCE_ID(v, o);
	UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
	
	int scaleMode = UNITY_ACCESS_INSTANCED_PROP(Props, _ScaleMode);
    half uniformScale = GetUniformScale();
    half scaleThickness = scaleMode == SCALE_MODE_UNIFORM ? uniformScale : 1;
    
    half radiusMajorTarget = UNITY_ACCESS_INSTANCED_PROP(Props, _Radius) * uniformScale;
    int radiusMajorSpace = UNITY_ACCESS_INSTANCED_PROP(Props, _RadiusSpace);
    int thicknessSpace = UNITY_ACCESS_INSTANCED_PROP(Props, _ThicknessSpace);
    half thicknessTarget = UNITY_ACCESS_INSTANCED_PROP(Props, _Thickness) * scaleThickness;
    
    
    // calc radius
	LineWidthData widthDataRadius = GetScreenSpaceWidthDataSimple( OBJ_ORIGIN, CAM_RIGHT, radiusMajorTarget * 2 /*to thickness*/, radiusMajorSpace );
	float radiusMajor = widthDataRadius.thicknessMeters / 2;
	
	// calc thickness
	LineWidthData widthDataThickness = GetScreenSpaceWidthDataSimple( OBJ_ORIGIN, CAM_RIGHT, thicknessTarget, thicknessSpace );
	o.pxCoverage = widthDataThickness.thicknessPixelsTarget;
	float thicknessRadius = widthDataThickness.thicknessMeters * 0.5;

	// local space pos
    half3 dirFromCenter = normalize( half3( v.vertex.xy, 0 ) );
    half3 tubeCenter = dirFromCenter * radiusMajor;
	half3 localPos = tubeCenter + v.normal * thicknessRadius; 
	o.pos = LocalToClipPos( localPos / uniformScale );
	return o;
}

FRAG_OUTPUT_V4 frag( VertexOutput i ) : SV_Target {
	UNITY_SETUP_INSTANCE_ID(i);
	half4 color = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
	return ShapesOutput( color, saturate(i.pxCoverage) );
}