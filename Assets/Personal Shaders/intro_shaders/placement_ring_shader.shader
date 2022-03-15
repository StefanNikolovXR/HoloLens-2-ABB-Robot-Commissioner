Shader "GalaxyExplorer/PlacementRingShader"
{
	Properties
	{
		_Color ("Base Color", Color) = (.5,1,1,1)
		_HighLightColor ("Highlight Color", Color) = (1,1,1,1)
		_Distance ("Highligh Distance", Float) = .1
		_GripAmount ("Grip Shrink Amount", Float) = .01
	}
		SubShader
	{
//		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		Tags { "Queue" = "Geometry" "RenderType" = "Opaque" }
		LOD 100

		ZWrite On
		ZTest LEqual
		Cull Back
//        Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{

			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile_fwdbase

			#pragma target 5.0
			#pragma only_renderers d3d11

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 worldPos : TEXCOORD0;
				float2 con_dist : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			fixed4 _Color;
			fixed4 _HighLightColor;
			float _DistanceSqrd;
			float _Pinch;
			float _GripAmount;
			float4 _ControllersPos[2];

			v2f vert(appdata v)
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				o.vertex = UnityObjectToClipPos(v.vertex-v.normal*_Pinch*_GripAmount);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				float3 dav = o.worldPos.xyz-_ControllersPos[0].xyz; 
				float3 dbv = o.worldPos.xyz-_ControllersPos[1].xyz; 
			    o.con_dist = float2(dot(dav, dav), dot(dbv, dbv));
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
			    float da = lerp(0, 1-saturate(i.con_dist.x/_DistanceSqrd), _ControllersPos[0].w);
			    float db = lerp(0, 1-saturate(i.con_dist.y/_DistanceSqrd), _ControllersPos[1].w);
			    float a = max(da, db);
			    
				fixed4 c = lerp(_Color, _HighLightColor, a);
				return c;
			}
			ENDCG
		}
	}
}
