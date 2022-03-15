// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
#include "UnityCG.cginc"
#include "../Shapes.cginc"
#pragma target 3.0

UNITY_INSTANCING_BUFFER_START(Props)
UNITY_DEFINE_INSTANCED_PROP(float4, _Color)
UNITY_DEFINE_INSTANCED_PROP(float, _Radius)
UNITY_DEFINE_INSTANCED_PROP(float, _Length)
UNITY_DEFINE_INSTANCED_PROP(int, _SizeSpace)
UNITY_INSTANCING_BUFFER_END(Props)

struct VertexInput {
	float4 vertex : POSITION;
	float2 uv0 : TEXCOORD0;
	UNITY_VERTEX_INPUT_INSTANCE_ID
};
struct VertexOutput {
	float4 pos : SV_POSITION;
	float pxCoverage : TEXCOORD0;
	UNITY_VERTEX_INPUT_INSTANCE_ID
	UNITY_VERTEX_OUTPUT_STEREO
};

VertexOutput vert(VertexInput v) {
	UNITY_SETUP_INSTANCE_ID(v);
	VertexOutput o = (VertexOutput)0;
	UNITY_TRANSFER_INSTANCE_ID(v, o);
	UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
	
    float radiusTarget = UNITY_ACCESS_INSTANCED_PROP(Props, _Radius);
    float lengthTarget = UNITY_ACCESS_INSTANCED_PROP(Props, _Length);
    int sizeSpace = UNITY_ACCESS_INSTANCED_PROP(Props, _SizeSpace);
    
	LineWidthData widthDataLength = GetScreenSpaceWidthDataSimple( OBJ_ORIGIN, CAM_RIGHT, lengthTarget, sizeSpace );
	float length = widthDataLength.thicknessMeters;
	
	LineWidthData widthDataRadius = GetScreenSpaceWidthDataSimple( OBJ_ORIGIN, CAM_RIGHT, radiusTarget*2, sizeSpace );
	float radius = widthDataRadius.thicknessMeters / 2;
	
	o.pxCoverage = min( widthDataLength.thicknessPixelsTarget, widthDataRadius.thicknessPixelsTarget );
	float scaleBranched = (v.vertex.z > 0.5 ? length : radius);
	float3 localPos = v.vertex.xyz * scaleBranched;
	o.pos = LocalToClipPos( localPos );
	return o;
}

FRAG_OUTPUT_V4 frag( VertexOutput i ) : SV_Target {
	UNITY_SETUP_INSTANCE_ID(i);
	float4 color = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
	return ShapesOutput( color, saturate(i.pxCoverage) ); 
}