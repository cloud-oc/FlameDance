Shader "Custom/GrayscaleWithTint"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _GrayscaleAmount ("Grayscale Amount", Range(0.0, 1.0)) = 1.0
        _DarkColor ("Dark Color", Color) = (0,0,0,1)
        _LightColor ("Light Color", Color) = (1,1,1,1)
    }
    
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            uniform sampler2D _MainTex;
            uniform float _GrayscaleAmount;
            uniform fixed4 _DarkColor;
            uniform fixed4 _LightColor;
            
            fixed4 frag(v2f_img i) : COLOR
            {
                fixed4 renderTex = tex2D(_MainTex, i.uv);
                float grayscale = Luminance(renderTex.rgb);
                fixed4 grayscaleColor = lerp(_DarkColor, _LightColor, grayscale);
                return lerp(renderTex, grayscaleColor, _GrayscaleAmount);
            }
            ENDCG
        }
    }
    
    FallBack off
}