Shader "UI/RoundedButton"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _Radius("Corner Radius", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        LOD 100

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Color;
            float _Radius;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv * 2.0 - 1.0; // Chuyển đổi tọa độ UV thành [-1, 1]
                float dist = length(uv);     // Tính khoảng cách từ tâm
                float alpha = smoothstep(1.0, 1.0 - _Radius, dist); // Bo góc
                return fixed4(_Color.rgb, alpha);
            }
            ENDCG
        }
    }
}
