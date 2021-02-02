// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "3EmissionColorShader"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}
		_EmissionMap("Emission Map", 2D) = "white" {}
		_MetalicMap("Metalic Map", 2D) = "white" {}
		[HDR]_EmissionColor1("Emission Color 1", Color) = (0,0,0,0)
		[HDR]_EmissionColor2("Emission Color 2", Color) = (0,0,0,0)
		[HDR]_EmissionColor3("Emission Color 3", Color) = (0,0,0,0)
		_AlbedoColor("Albedo Color", Color) = (0,0,0,0)
		_Smoothness("Smoothness", Float) = 0
		_Metalic("Metalic", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float4 _AlbedoColor;
		uniform sampler2D _EmissionMap;
		uniform float4 _EmissionMap_ST;
		uniform float4 _EmissionColor1;
		uniform float4 _EmissionColor2;
		uniform float4 _EmissionColor3;
		uniform sampler2D _MetalicMap;
		uniform float4 _MetalicMap_ST;
		uniform float _Metalic;
		uniform float _Smoothness;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			o.Albedo = ( tex2D( _MainTex, uv_MainTex ) * _AlbedoColor ).rgb;
			float2 uv_EmissionMap = i.uv_texcoord * _EmissionMap_ST.xy + _EmissionMap_ST.zw;
			float4 tex2DNode3 = tex2D( _EmissionMap, uv_EmissionMap );
			o.Emission = ( ( tex2DNode3.r * _EmissionColor1 ) + ( tex2DNode3.g * _EmissionColor2 ) + ( tex2DNode3.b * _EmissionColor3 ) ).rgb;
			float2 uv_MetalicMap = i.uv_texcoord * _MetalicMap_ST.xy + _MetalicMap_ST.zw;
			float4 tex2DNode26 = tex2D( _MetalicMap, uv_MetalicMap );
			o.Metallic = ( tex2DNode26 * _Metalic ).r;
			o.Smoothness = ( tex2DNode26 * _Smoothness ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18800
85;116;1580;760;698.5515;-82.80934;1.3;True;True
Node;AmplifyShaderEditor.TexturePropertyNode;4;-1227.152,260.7762;Inherit;True;Property;_EmissionMap;Emission Map;1;0;Create;True;0;0;0;False;0;False;None;aea86151458a9364a9e4b8b3123b538a;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TexturePropertyNode;25;-291.5411,561.4704;Inherit;True;Property;_MetalicMap;Metalic Map;2;0;Create;True;0;0;0;False;0;False;None;2d2edcc032d8e684aaccc8848d6f7185;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ColorNode;22;-922.1585,857.2208;Inherit;False;Property;_EmissionColor3;Emission Color 3;5;1;[HDR];Create;True;0;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;2;-949.426,-170.1547;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;None;943f3c476130c4f4f8ae55ef3ccd38ba;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ColorNode;13;-920.6812,486.5459;Inherit;False;Property;_EmissionColor1;Emission Color 1;3;1;[HDR];Create;True;0;0;0;False;0;False;0,0,0,0;32,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;3;-985.05,262.4887;Inherit;True;Property;_TextureSample1;Texture Sample 1;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;21;-920.6818,671.145;Inherit;False;Property;_EmissionColor2;Emission Color 2;4;1;[HDR];Create;True;0;0;0;False;0;False;0,0,0,0;0.03954625,0.03954625,0.03954625,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-489.4569,343.2972;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;26;-54.63958,556.6831;Inherit;True;Property;_TextureSample3;Texture Sample 3;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-493.8876,594.3516;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;11;-528.1067,32.45644;Inherit;False;Property;_AlbedoColor;Albedo Color;6;0;Create;True;0;0;0;False;0;False;0,0,0,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-596.6494,-167.6762;Inherit;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;23;116.4939,763.7155;Inherit;False;Property;_Metalic;Metalic;8;0;Create;True;0;0;0;False;0;False;0;-0.68;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-490.9331,467.3473;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;24;92.71011,897.0367;Inherit;False;Property;_Smoothness;Smoothness;7;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-118.2072,-17.30443;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;17;-290.0898,390.5546;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;34;326.2513,790.2304;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;292.4511,582.2304;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;521.3358,113.7129;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;3EmissionColorShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;0;4;0
WireConnection;16;0;3;1
WireConnection;16;1;13;0
WireConnection;26;0;25;0
WireConnection;19;0;3;3
WireConnection;19;1;22;0
WireConnection;1;0;2;0
WireConnection;18;0;3;2
WireConnection;18;1;21;0
WireConnection;9;0;1;0
WireConnection;9;1;11;0
WireConnection;17;0;16;0
WireConnection;17;1;18;0
WireConnection;17;2;19;0
WireConnection;34;0;26;0
WireConnection;34;1;24;0
WireConnection;33;0;26;0
WireConnection;33;1;23;0
WireConnection;0;0;9;0
WireConnection;0;2;17;0
WireConnection;0;3;33;0
WireConnection;0;4;34;0
ASEEND*/
//CHKSM=66596EA15686259723A1FDA0AC7BD7A919994040