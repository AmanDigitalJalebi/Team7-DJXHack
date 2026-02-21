Shader "Custom/waterfall"
{
   Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _FlowSpeed ("Flow Speed", Float) = 1
        _DistortionStrength ("Distortion Strength", Float) = 0.05
        _EmissionColor ("Emission Color", Color) = (0,1,0,1)
        _Alpha ("Alpha", Range(0,1)) = 0.8
    }

    SubShader
    {
        Tags { 
            "RenderType"="Transparent" 
            "Queue"="Transparent" 
        }

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _NoiseTex;

            float4 _MainTex_ST;
            float _FlowSpeed;
            float _DistortionStrength;
            float4 _EmissionColor;
            float _Alpha;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Scroll UV downward
                float2 flowUV = i.uv;
                flowUV.y -= _Time.y * _FlowSpeed;

                // Animate noise
                float2 noiseUV = i.uv;
                noiseUV.y -= _Time.y * (_FlowSpeed * 0.5);

                float2 noise = tex2D(_NoiseTex, noiseUV).rg;

                // Distort main UV
                flowUV += (noise - 0.5) * _DistortionStrength;

                // Sample main texture
                fixed4 col = tex2D(_MainTex, flowUV);

                // Add emission glow
                col.rgb *= _EmissionColor.rgb;

                col.a = _Alpha;

                return col;
            }

            ENDHLSL
        }
    }
}
