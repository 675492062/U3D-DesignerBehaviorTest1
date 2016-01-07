using UnityEngine;
using System.Collections;

public class MathParam : MonoBehaviour
{
	public MathParam()
	{
		dod_attenuation_coefficient_a = 0f;
		dod_attenuation_coefficient_b = -0.0135f;
		dod_attenuation_coefficient_c = 1.0135f;
		dodrate_coefficient_a = 0.0196f;
		dodrate_coefficient_b = 1.8036f;

		cri_attenuation_coefficient_a = 0f;
		cri_attenuation_coefficient_b = -0.0135f;
		cri_attenuation_coefficient_c = 1.0135f;
		crirate_coefficient_a = 0.0196f;
		crirate_coefficient_b = 1.8036f;

		hit_attenuation_coefficient_a = 0f;
		hit_attenuation_coefficient_b = -0.0135f;
		hit_attenuation_coefficient_c = 1.0135f;
		hitrate_coefficient_a = 0.0196f;
		hitrate_coefficient_b = 1.8036f;

		armor_attenuation_coefficient_a = 0f;
		armor_attenuation_coefficient_b = -0.0135f;
		armor_attenuation_coefficient_c = 1.0135f;
		armorrate_coefficient_a = 0.0002f;
		armorrate_coefficient_b = 0.0909f;

	}

	public float dod_attenuation_coefficient_a{get; set;}  //闪避率衰减参数计算系数a
	public float dod_attenuation_coefficient_b{get; set;}  //闪避率衰减参数计算系数b
	public float dod_attenuation_coefficient_c{get; set;}  //闪避率衰减参数计算系数c
	public float dodrate_coefficient_a{get; set;}	         //闪避率计算参数a	
	public float dodrate_coefficient_b{get; set;}	         //闪避率计算参数b	
	public float cri_attenuation_coefficient_a{get; set;}  //暴击率衰减参数计算系数a
	public float cri_attenuation_coefficient_b{get; set;}  //暴击率衰减参数计算系数b
	public float cri_attenuation_coefficient_c{get; set;}  //暴击率衰减参数计算系数c
	public float crirate_coefficient_a{get; set;}	       //暴击率计算参数a
	public float crirate_coefficient_b{get; set;}          //暴击率计算参数b

	public float hit_attenuation_coefficient_a{get; set;}  //命中衰减参数计算系数
	public float hit_attenuation_coefficient_b{get; set;}  //命中衰减参数计算系数
	public float hit_attenuation_coefficient_c{get; set;}  //命中衰减参数计算系数
	public float hitrate_coefficient_a{get; set;}			 //命中计算参数
	public float hitrate_coefficient_b{get; set;}          //命中计算参数
	
	public float armor_attenuation_coefficient_a{get; set;}//护甲衰减参数计算系数
	public float armor_attenuation_coefficient_b{get; set;}//护甲衰减参数计算系数
	public float armor_attenuation_coefficient_c{get; set;}//护甲衰减参数计算系数
	public float armorrate_coefficient_a{get; set;}        //护甲计算参数
	public float armorrate_coefficient_b{get; set;}        //护甲计算参数

}
