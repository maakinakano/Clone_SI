Shader "Custom/AutoColorShader" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}

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
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float2 worldPos : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

			sampler2D _MainTex;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : COLOR {
            	fixed4 tex = tex2D(_MainTex, i.uv);
            	if(tex.r == 0 && tex.g == 0 && tex.b == 0) {
            		return fixed4(0, 0, 0, 0);
            	}
	            float y = i.worldPos.y;
	            if(y > 3) {
	                return fixed4(1, 0, 1, 1);
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
