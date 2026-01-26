Shader "Custom/T"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo", 2D) = "white" {}

        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Roughness ("Roughness", Range(0,1)) = 0.5

        _BumpMap ("Normal Map", 2D) = "bump" {}
        _OcclusionMap ("Occlusion", 2D) = "white" {}

        _EmissionMap ("Emission", 2D) = "black" {}
        _EmissionColor ("Emission Color", Color) = (0,0,0)
    }
    SubShader
    {
Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _OcclusionMap;
        sampler2D _EmissionMap;

        fixed4 _Color;
        half _Metallic;
        half _Roughness;
        fixed4 _EmissionColor;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

            o.Metallic = _Metallic;
            o.Smoothness = 1.0 - _Roughness;

            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            o.Occlusion = tex2D(_OcclusionMap, IN.uv_MainTex).r;

            fixed4 e = tex2D(_EmissionMap, IN.uv_MainTex) * _EmissionColor;
            o.Emission = e.rgb;

            o.Alpha = c.a;
        }
        ENDCG
    }

    FallBack "Standard"
}
