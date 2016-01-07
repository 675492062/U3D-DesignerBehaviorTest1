Shader "Custom/ProjectorCloud"
{
	Properties
	{
		_ShadowTex ("Projected Image", 2D) = "white" {}
		_CloudSpeed ("Move Speed",Float) = 0.1
	}
	SubShader
	{
		Pass
		{      
			Blend Zero OneMinusSrcAlpha			  
			Program "vp" {
// Vertex combos: 1
//   opengl - ALU: 8 to 8
//   d3d9 - ALU: 8 to 8
SubProgram "opengl " {
Keywords { }
Bind "vertex" Vertex
Matrix 5 [_Projector]
"!!ARBvp1.0
# 8 ALU
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[0].w, vertex.position, c[8];
DP4 result.texcoord[0].z, vertex.position, c[7];
DP4 result.texcoord[0].y, vertex.position, c[6];
DP4 result.texcoord[0].x, vertex.position, c[5];
END
# 8 instructions, 0 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Projector]
"vs_2_0
; 8 ALU
dcl_position0 v0
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oT0.w, v0, c7
dp4 oT0.z, v0, c6
dp4 oT0.y, v0, c5
dp4 oT0.x, v0, c4
"
}

SubProgram "ps3 " {
Keywords { }
Matrix 256 [glstate_matrix_mvp]
Bind "vertex" Vertex
Matrix 260 [_Projector]
"sce_vp_rsx // 8 instructions using 1 registers
[Configuration]
8
0000000800010100
[Microcode]
128
401f9c6c01d0300d8106c0c360403f80401f9c6c01d0200d8106c0c360405f80
401f9c6c01d0100d8106c0c360409f80401f9c6c01d0000d8106c0c360411f80
401f9c6c01d0700d8106c0c360403f9c401f9c6c01d0600d8106c0c360405f9c
401f9c6c01d0500d8106c0c360409f9c401f9c6c01d0400d8106c0c360411f9d
"
}

SubProgram "gles " {
Keywords { }
"!!GLES


#ifdef VERTEX

varying highp vec4 xlv_TEXCOORD0;
uniform highp mat4 _Projector;
uniform highp mat4 glstate_matrix_mvp;
attribute vec4 _glesVertex;
void main ()
{
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = (_Projector * _glesVertex);
}



#endif
#ifdef FRAGMENT

varying highp vec4 xlv_TEXCOORD0;
uniform lowp float _CloudSpeed;
uniform highp vec4 _ShadowTex_ST;
uniform sampler2D _ShadowTex;
uniform highp vec4 _Time;
void main ()
{
  highp vec4 tmpvar_1;
  if ((xlv_TEXCOORD0.w > 0.0)) {
    highp vec2 tmpvar_2;
    tmpvar_2.x = (xlv_TEXCOORD0.x * _ShadowTex_ST.x);
    tmpvar_2.y = (xlv_TEXCOORD0.y * _ShadowTex_ST.y);
    lowp vec4 tmpvar_3;
    highp vec2 P_4;
    P_4 = ((tmpvar_2 / xlv_TEXCOORD0.w) + (_Time * _CloudSpeed).xy);
    tmpvar_3 = texture2D (_ShadowTex, P_4);
    tmpvar_1 = tmpvar_3;
  } else {
    tmpvar_1 = vec4(0.0, 0.0, 0.0, 0.0);
  };
  gl_FragData[0] = tmpvar_1;
}



#endif"
}

SubProgram "glesdesktop " {
Keywords { }
"!!GLES


#ifdef VERTEX

varying highp vec4 xlv_TEXCOORD0;
uniform highp mat4 _Projector;
uniform highp mat4 glstate_matrix_mvp;
attribute vec4 _glesVertex;
void main ()
{
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = (_Projector * _glesVertex);
}



#endif
#ifdef FRAGMENT

varying highp vec4 xlv_TEXCOORD0;
uniform lowp float _CloudSpeed;
uniform highp vec4 _ShadowTex_ST;
uniform sampler2D _ShadowTex;
uniform highp vec4 _Time;
void main ()
{
  highp vec4 tmpvar_1;
  if ((xlv_TEXCOORD0.w > 0.0)) {
    highp vec2 tmpvar_2;
    tmpvar_2.x = (xlv_TEXCOORD0.x * _ShadowTex_ST.x);
    tmpvar_2.y = (xlv_TEXCOORD0.y * _ShadowTex_ST.y);
    lowp vec4 tmpvar_3;
    highp vec2 P_4;
    P_4 = ((tmpvar_2 / xlv_TEXCOORD0.w) + (_Time * _CloudSpeed).xy);
    tmpvar_3 = texture2D (_ShadowTex, P_4);
    tmpvar_1 = tmpvar_3;
  } else {
    tmpvar_1 = vec4(0.0, 0.0, 0.0, 0.0);
  };
  gl_FragData[0] = tmpvar_1;
}



#endif"
}

SubProgram "flash " {
Keywords { }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Projector]
"agal_vs
[bc]
bdaaaaaaaaaaaiadaaaaaaoeaaaaaaaaadaaaaoeabaaaaaa dp4 o0.w, a0, c3
bdaaaaaaaaaaaeadaaaaaaoeaaaaaaaaacaaaaoeabaaaaaa dp4 o0.z, a0, c2
bdaaaaaaaaaaacadaaaaaaoeaaaaaaaaabaaaaoeabaaaaaa dp4 o0.y, a0, c1
bdaaaaaaaaaaabadaaaaaaoeaaaaaaaaaaaaaaoeabaaaaaa dp4 o0.x, a0, c0
bdaaaaaaaaaaaiaeaaaaaaoeaaaaaaaaahaaaaoeabaaaaaa dp4 v0.w, a0, c7
bdaaaaaaaaaaaeaeaaaaaaoeaaaaaaaaagaaaaoeabaaaaaa dp4 v0.z, a0, c6
bdaaaaaaaaaaacaeaaaaaaoeaaaaaaaaafaaaaoeabaaaaaa dp4 v0.y, a0, c5
bdaaaaaaaaaaabaeaaaaaaoeaaaaaaaaaeaaaaoeabaaaaaa dp4 v0.x, a0, c4
"
}

SubProgram "gles3 " {
Keywords { }
"!!GLES3#version 300 es


#ifdef VERTEX

#define gl_Vertex _glesVertex
in vec4 _glesVertex;

#line 60
struct vertexOutput {
    highp vec4 pos;
    highp vec4 posProj;
};
#line 55
struct vertexInput {
    highp vec4 vertex;
};
uniform highp vec4 _Time;
uniform highp vec4 _SinTime;
#line 3
uniform highp vec4 _CosTime;
uniform highp vec4 unity_DeltaTime;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _ProjectionParams;
#line 7
uniform highp vec4 _ScreenParams;
uniform highp vec4 _ZBufferParams;
uniform highp vec4 unity_CameraWorldClipPlanes[6];
uniform highp vec4 _WorldSpaceLightPos0;
#line 11
uniform highp vec4 _LightPositionRange;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
#line 15
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_LightPosition[8];
uniform highp vec4 unity_LightAtten[8];
#line 19
uniform highp vec4 unity_SpotDirection[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
#line 23
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
#line 27
uniform highp vec3 unity_LightColor0;
uniform highp vec3 unity_LightColor1;
uniform highp vec3 unity_LightColor2;
uniform highp vec3 unity_LightColor3;
uniform highp vec4 unity_ShadowSplitSpheres[4];
uniform highp vec4 unity_ShadowSplitSqRadii;
uniform highp vec4 unity_LightShadowBias;
#line 31
uniform highp vec4 _LightSplitsNear;
uniform highp vec4 _LightSplitsFar;
uniform highp mat4 unity_World2Shadow[4];
uniform highp vec4 _LightShadowData;
#line 35
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 glstate_matrix_invtrans_modelview0;
#line 39
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 unity_Scale;
uniform highp mat4 glstate_matrix_transpose_modelview0;
#line 43
uniform highp mat4 glstate_matrix_texture0;
uniform highp mat4 glstate_matrix_texture1;
uniform highp mat4 glstate_matrix_texture2;
uniform highp mat4 glstate_matrix_texture3;
#line 47
uniform highp mat4 glstate_matrix_projection;
uniform highp vec4 glstate_lightmodel_ambient;
uniform highp mat4 unity_MatrixV;
uniform highp mat4 unity_MatrixVP;
#line 51
uniform sampler2D _ShadowTex;
uniform highp mat4 _Projector;
uniform highp vec4 _ShadowTex_ST;
uniform lowp float _CloudSpeed;
#line 66
#line 66
vertexOutput vert( in vertexInput xlat_varinput ) {
    vertexOutput xlat_varoutput;
    xlat_varoutput.posProj = (_Projector * xlat_varinput.vertex);
    #line 70
    xlat_varoutput.pos = (glstate_matrix_mvp * xlat_varinput.vertex);
    return xlat_varoutput;
}
out highp vec4 xlv_TEXCOORD0;
void main() {
    vertexOutput xl_retval;
    vertexInput xlt_xlat_varinput;
    xlt_xlat_varinput.vertex = vec4(gl_Vertex);
    xl_retval = vert( xlt_xlat_varinput);
    gl_Position = vec4(xl_retval.pos);
    xlv_TEXCOORD0 = vec4(xl_retval.posProj);
}


#endif
#ifdef FRAGMENT

#define gl_FragData _glesFragData
layout(location = 0) out mediump vec4 _glesFragData[4];

#line 60
struct vertexOutput {
    highp vec4 pos;
    highp vec4 posProj;
};
#line 55
struct vertexInput {
    highp vec4 vertex;
};
uniform highp vec4 _Time;
uniform highp vec4 _SinTime;
#line 3
uniform highp vec4 _CosTime;
uniform highp vec4 unity_DeltaTime;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _ProjectionParams;
#line 7
uniform highp vec4 _ScreenParams;
uniform highp vec4 _ZBufferParams;
uniform highp vec4 unity_CameraWorldClipPlanes[6];
uniform highp vec4 _WorldSpaceLightPos0;
#line 11
uniform highp vec4 _LightPositionRange;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
#line 15
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_LightPosition[8];
uniform highp vec4 unity_LightAtten[8];
#line 19
uniform highp vec4 unity_SpotDirection[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
#line 23
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
#line 27
uniform highp vec3 unity_LightColor0;
uniform highp vec3 unity_LightColor1;
uniform highp vec3 unity_LightColor2;
uniform highp vec3 unity_LightColor3;
uniform highp vec4 unity_ShadowSplitSpheres[4];
uniform highp vec4 unity_ShadowSplitSqRadii;
uniform highp vec4 unity_LightShadowBias;
#line 31
uniform highp vec4 _LightSplitsNear;
uniform highp vec4 _LightSplitsFar;
uniform highp mat4 unity_World2Shadow[4];
uniform highp vec4 _LightShadowData;
#line 35
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 glstate_matrix_invtrans_modelview0;
#line 39
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 unity_Scale;
uniform highp mat4 glstate_matrix_transpose_modelview0;
#line 43
uniform highp mat4 glstate_matrix_texture0;
uniform highp mat4 glstate_matrix_texture1;
uniform highp mat4 glstate_matrix_texture2;
uniform highp mat4 glstate_matrix_texture3;
#line 47
uniform highp mat4 glstate_matrix_projection;
uniform highp vec4 glstate_lightmodel_ambient;
uniform highp mat4 unity_MatrixV;
uniform highp mat4 unity_MatrixVP;
#line 51
uniform sampler2D _ShadowTex;
uniform highp mat4 _Projector;
uniform highp vec4 _ShadowTex_ST;
uniform lowp float _CloudSpeed;
#line 66
#line 73
highp vec4 frag( in vertexOutput xlat_varinput ) {
    #line 75
    if ((xlat_varinput.posProj.w > 0.0)){
        return texture( _ShadowTex, ((vec2( (xlat_varinput.posProj.x * _ShadowTex_ST.x), (xlat_varinput.posProj.y * _ShadowTex_ST.y)) / xlat_varinput.posProj.w) + vec2( (_Time * _CloudSpeed))));
    }
    else{
        return vec4( 0.0);
    }
}
in highp vec4 xlv_TEXCOORD0;
void main() {
    highp vec4 xl_retval;
    vertexOutput xlt_xlat_varinput;
    xlt_xlat_varinput.pos = vec4(0.0);
    xlt_xlat_varinput.posProj = vec4(xlv_TEXCOORD0);
    xl_retval = frag( xlt_xlat_varinput);
    gl_FragData[0] = vec4(xl_retval);
}


#endif"
}

}
Program "fp" {
// Fragment combos: 1
//   opengl - ALU: 10 to 10, TEX: 1 to 1
//   d3d9 - ALU: 9 to 9, TEX: 1 to 1
SubProgram "opengl " {
Keywords { }
Vector 0 [_Time]
Vector 1 [_ShadowTex_ST]
Float 2 [_CloudSpeed]
SetTexture 0 [_ShadowTex] 2D
"!!ARBfp1.0
# 10 ALU, 1 TEX
PARAM c[4] = { program.local[0..2],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
MOV R0.z, c[2].x;
MUL R1.xy, R0.z, c[0];
RCP R0.z, fragment.texcoord[0].w;
MUL R0.xy, fragment.texcoord[0], c[1];
MAD R0.xy, R0, R0.z, R1;
SLT R1.x, c[3].y, fragment.texcoord[0].w;
ABS R1.x, R1;
CMP R1.x, -R1, c[3].y, c[3];
TEX R0, R0, texture[0], 2D;
CMP result.color, -R1.x, c[3].y, R0;
END
# 10 instructions, 2 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Vector 0 [_Time]
Vector 1 [_ShadowTex_ST]
Float 2 [_CloudSpeed]
SetTexture 0 [_ShadowTex] 2D
"ps_2_0
; 9 ALU, 1 TEX
dcl_2d s0
def c3, 0.00000000, 1.00000000, 0, 0
dcl t0.xyzw
mov r0.xy, c0
mul r1.xy, c2.x, r0
mul r2.xy, t0, c1
rcp r0.x, t0.w
mad r0.xy, r2, r0.x, r1
texld r1, r0, s0
cmp r0.x, -t0.w, c3, c3.y
abs_pp r0.x, r0
cmp r0, -r0.x, c3.x, r1
mov oC0, r0
"
}

SubProgram "ps3 " {
Keywords { }
Vector 0 [_Time]
Vector 1 [_ShadowTex_ST]
Float 2 [_CloudSpeed]
SetTexture 0 [_ShadowTex] 2D
"sce_fp_rsx // 10 instructions using 3 registers
[Configuration]
24
ffffffff000040200001fffe000000000000844003000000
[Offsets]
3
_Time 1 0
00000080
_ShadowTex_ST 1 0
00000050
_CloudSpeed 1 0
00000020
[Microcode]
160
8e02010068011c9dc8000001c8003fe11002010000021c9cc8000001c8000001
00000000000000000000000000000000037e418054041c9dc8000001c8000001
1804020080041c9c80020000c800000100000000000000000000000000000000
06023a005c081c9d54040001c800000106020400fe041c9d08020000c8040001
000000000000000000000000000000001e011700c8040011c8000001c8000001
"
}

SubProgram "gles " {
Keywords { }
"!!GLES"
}

SubProgram "glesdesktop " {
Keywords { }
"!!GLES"
}

SubProgram "flash " {
Keywords { }
Vector 0 [_Time]
Vector 1 [_ShadowTex_ST]
Float 2 [_CloudSpeed]
SetTexture 0 [_ShadowTex] 2D
"agal_ps
c3 0.0 1.0 0.0 0.0
[bc]
aaaaaaaaaaaaadacaaaaaaoeabaaaaaaaaaaaaaaaaaaaaaa mov r0.xy, c0
adaaaaaaabaaadacacaaaaaaabaaaaaaaaaaaafeacaaaaaa mul r1.xy, c2.x, r0.xyyy
adaaaaaaacaaadacaaaaaaoeaeaaaaaaabaaaaoeabaaaaaa mul r2.xy, v0, c1
afaaaaaaaaaaabacaaaaaappaeaaaaaaaaaaaaaaaaaaaaaa rcp r0.x, v0.w
adaaaaaaaaaaadacacaaaafeacaaaaaaaaaaaaaaacaaaaaa mul r0.xy, r2.xyyy, r0.x
abaaaaaaaaaaadacaaaaaafeacaaaaaaabaaaafeacaaaaaa add r0.xy, r0.xyyy, r1.xyyy
ciaaaaaaabaaapacaaaaaafeacaaaaaaaaaaaaaaafaababb tex r1, r0.xyyy, s0 <2d wrap linear point>
bfaaaaaaacaaaiacaaaaaappaeaaaaaaaaaaaaaaaaaaaaaa neg r2.w, v0.w
ckaaaaaaaaaaabacacaaaappacaaaaaaadaaaaaaabaaaaaa slt r0.x, r2.w, c3.x
beaaaaaaaaaaabacaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa abs r0.x, r0.x
bfaaaaaaacaaabacaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa neg r2.x, r0.x
ckaaaaaaacaaapacacaaaaaaacaaaaaaadaaaaaaabaaaaaa slt r2, r2.x, c3.x
acaaaaaaabaaapacabaaaaoeacaaaaaaadaaaaaaabaaaaaa sub r1, r1, c3.x
adaaaaaaaaaaapacabaaaaoeacaaaaaaacaaaaoeacaaaaaa mul r0, r1, r2
abaaaaaaaaaaapacaaaaaaoeacaaaaaaadaaaaaaabaaaaaa add r0, r0, c3.x
aaaaaaaaaaaaapadaaaaaaoeacaaaaaaaaaaaaaaaaaaaaaa mov o0, r0
"
}

SubProgram "gles3 " {
Keywords { }
"!!GLES3"
}

}

#LINE 56

		}
	}
	// Fallback "Projector/Light"
}