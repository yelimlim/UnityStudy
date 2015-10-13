Shader "Custom/ShaderTest" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_EmissiveColor ("EmissiveColor", Color) = (1,1,1,1)
		_AmbientColor ("AmbientColor", Color) = (1,1,1,1)
		_PowerValue("Color Power", Range(0, 10)) = 1.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float4 _EmissiveColor;
		float4 _AmbientColor;
		float _PowerValue;

		struct Input
		{
			float2 uv_MainTex;	
		};

		void surf (Input IN, inout SurfaceOutput o) {
			float4 c;
			c = pow((_EmissiveColor + _AmbientColor), _PowerValue);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
