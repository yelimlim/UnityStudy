Shader "Custom/MutiTexture" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_MainTex2 ("Albedo2 (RGB)", 2D) = "white" {}
		_MainTex3 ("Albedo3 (RGB)", 2D) = "white" {}
		_MainTex4 ("Albedo4 (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MainTex2;
		sampler2D _MainTex3;
		sampler2D _MainTex4;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MainTex2;
			float2 uv_MainTex3;
			float2 uv_MainTex4;
			float4 color : COLOR;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 c2 = tex2D (_MainTex2, IN.uv_MainTex2);
			half4 c3 = tex2D (_MainTex3, IN.uv_MainTex3);
			half4 c4 = tex2D (_MainTex4, IN.uv_MainTex4);

			float4 finalColor = lerp(c, c2, IN.color.r);
			finalColor = lerp(finalColor, c3, IN.color.g);
			finalColor = lerp(finalColor, c4, IN.color.b);

			//o.Albedo = c.rgb;
			o.Emission = finalColor.rgb;
			o.Alpha = finalColor.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
