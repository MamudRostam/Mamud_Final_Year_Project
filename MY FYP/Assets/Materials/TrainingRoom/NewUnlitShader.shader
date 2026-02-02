Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GridScale ("Grid Scale", Float) = 0.1
        [HDR]_GridColour("Grid Colour", Color) = (1, 0, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _GridColour;
            float4 _MainTex_ST;
            float _GridScale;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float GridTest(float2 r)
            {
                float2 grid = frac(r);

                float2 lineweight = smoothstep(0.01, 0.0, grid) + smoothstep(0.99, 1.0, grid);
                return saturate(lineweight.x + lineweight.y);
            }


            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 texCol = tex2D(_MainTex, i.uv);

                float mask = GridTest(i.uv * _GridScale);

                float4 gridOut = mask * _GridColour;

                return texCol + gridOut;
            }
            ENDCG
        }
    }
}
