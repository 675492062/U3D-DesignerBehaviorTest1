Shader "Custom/GhostChar"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ocsColor ("Occlusion Color", Color) = (0.23,0.94,0.9,0.5)
	}

	CGINCLUDE
		#include "UnityCG.cginc"

		float4 _ocsColor;
		
		struct appdata_t
		{
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f
		{
			float4 vertex : SV_POSITION;
			float3 normal : TEXCOORD0;
			float3 viewDir : TEXCOORD1;
		};

		v2f vert (appdata_t v)
		{
			v2f o;
			float4 vIW = mul(v.vertex,_Object2World);					
			o.normal = normalize(mul(v.normal,float3x3(_World2Object))).xyz;
			o.viewDir = normalize(WorldSpaceViewDir(vIW));
			o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			return o;
		}

		fixed4 frag (v2f i) : COLOR
		{
			float4 col;
			col.rgb = pow(1.25-dot(i.normal,i.viewDir),2);
			col.a = _ocsColor.a;
			return col*_ocsColor;
		}
	ENDCG 

	SubShader
	{
		Tags { "Queue" = "AlphaTest+5" "RenderType" = "TransparentCutout" }

		Pass
		{
			ZWrite Off
			ZTest Greater
			Blend one zero
		
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest
				#pragma exclude_renderers d3d11 d3d11_9x xbox360
			ENDCG
		}
		
		Pass
		{
			Tags {"LightMode" = "Vertex"}
			ZWrite On
			ZTest LEqual
			Lighting On
			SeparateSpecular On
			Material
			{
				Diffuse [_Color]
				Ambient [_Color]
			}
			SetTexture [_MainTex]
			{
				ConstantColor [_Color]
				Combine texture * primary DOUBLE, texture * constant
			}
		}
	}
	FallBack "Diffuse", 1
}