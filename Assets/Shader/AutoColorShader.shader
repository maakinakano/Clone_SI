Shader "Custom/AutoColorShader" {
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
            };

            struct v2f {
                float2 worldPos : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target {
	            float y = i.worldPos.y;
	            if(y > 10) {
	                return fixed4(1, 0, 0, 1);
	            } else if(y>1.73){
	                return fixed4(0, 1, 0, 1);
	            } else if(y>0.51){
	                return fixed4(0, 1, 1, 1);
	            } else if(y>-0.75){
	                return fixed4(1, 0, 1, 1);
	            } else if(y>-2.02){
	                return fixed4(1, 1, 0, 1);
	            } else if(y>-2.95){
	                return fixed4(1, 0, 0, 1);
	            } else if(y>-4) {
	            	return fixed4(0, 1, 1, 1);
	            }
	            return fixed4(1,0,0,1);
            }
            ENDCG
        }
    }
}
