Shader "GalaxyExplorer/PlacementRimShader"
{
	Properties
	{
		_Color ("Base Color", Color) = (1,1,1,1)
		_ProximityColor("Proximity Color", Color) = (1,1,1,1)
		_Multiplier("Multiplier", Range(0,1)) = 0
	}
		SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100

		ZWrite Off
		ZTest LEqual
		Cull Back
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
				float3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float inclination : TEXCOORD0;
				float proximity : TEXCOORD1;
				float4 color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			fixed4 _Color;
			fixed4 _ProximityColor;
			float _Multiplier;
			
            float4 _ProximityLightData[2*6];

			v2f vert(appdata v)
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				o.vertex = UnityObjectToClipPos(v.vertex);
				float3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
				float3 dir = normalize(WorldSpaceViewDir(v.vertex));
				float inclination = 1-dot(dir, worldNormal);
				inclination *= inclination;
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
				float proximity = min(distance(worldPos, _ProximityLightData[0]), distance(worldPos, _ProximityLightData[6]));
				proximity = saturate(.1-proximity)*10.0;
				o.color = lerp(_Color, _ProximityColor, proximity);
				inclination = lerp(inclination*inclination, inclination, max(_Multiplier, proximity));
				o.inclination = inclination;
				o.proximity = proximity;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 c = _Color;
				c.a *= i.inclination;
				return c;
			}
			ENDCG
		}
	}
}
