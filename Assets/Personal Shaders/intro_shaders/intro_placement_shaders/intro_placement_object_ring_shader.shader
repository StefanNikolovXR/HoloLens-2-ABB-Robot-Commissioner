Shader "GalaxyExplorer/PlacementHaloShader"
{
	Properties
	{
		_Color ("Base Color", Color) = (1,1,1,1)
		_ProximityColor("Proximity Color", Color) = (1,1,1,1)
		_OuterDiameter("Outer Diameter", Range(0,1)) = .666
	}
		SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100

		ZWrite Off
		ZTest LEqual
		Cull Off
        Blend SrcAlpha OneMinusSrcAlpha

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
				float2 uv : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float mag : TEXCOORD1;
				float4 color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			fixed4 _Color;
			fixed4 _ProximityColor;
			float _InnerDiameter;
			float _OuterDiameter;

            float4 _ProximityLightData[2*6];
            
			v2f vert(appdata v)
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.mag = length(v.uv*2-1);
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
				float proximity = min(distance(worldPos, _ProximityLightData[0]), distance(worldPos, _ProximityLightData[6]));
				proximity = saturate(.1-proximity)*10.0;
				o.color = lerp(_Color, _ProximityColor, proximity);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float a = 1-saturate(i.mag/_OuterDiameter);
				a *= a;
				fixed4 c = i.color;
				c.a *= a;
				return c;
			}
			ENDCG
		}
	}
}
