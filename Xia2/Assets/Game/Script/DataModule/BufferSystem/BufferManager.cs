using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BufferManager : MonoBehaviour {

	Dictionary<int , BufferStruct>  bufferDic = new Dictionary<int, BufferStruct>();
	
	public Dictionary<int , int> bufferTypeToHeroProDic = new Dictionary<int, int>();		//bufferEvent --- >  NewHeroProperty/UnitState
	
	public BufferStruct GetBufferStructById(int id){
		if(bufferTypeToHeroProDic.Keys.Count == 0){
			Init();
		}

		if(bufferDic.ContainsKey(id)){
			bufferDic[id].Reset();
			return bufferDic[id];
		}
		
		var bufferStruct = LoadBufferStruct(id);
		bufferDic.Add(id , bufferStruct);
		return bufferStruct;
	}
	
	BufferStruct LoadBufferStruct(int id){
		var bufferStruct = new BufferStruct(id);
		return bufferStruct;
	}
	
	public void Init(){
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddHpMax , (int)GlobalDef.HeroProperty.PRO_LIFE);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddCritLv , (int)GlobalDef.NewHeroProperty.PRO_CRITICALLV);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddToughnessLv , (int)GlobalDef.NewHeroProperty.PRO_CRITICAL_DAMAGE);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddDodgeLv , (int)GlobalDef.NewHeroProperty.PRO_DODGELV);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddHitLv , (int)GlobalDef.NewHeroProperty.PRO_HITLV);
		bufferTypeToHeroProDic.Add((int)BufferEvent.DelHit , (int)GlobalDef.NewHeroProperty.PRO_HITLV);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddAtackStrength , (int)GlobalDef.NewHeroProperty.PRO_ATTACK);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddAtackSpeed , (int)GlobalDef.NewHeroProperty.PRO_ATKSPD);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddArmor , (int)GlobalDef.NewHeroProperty.PRO_ARMOR);
		bufferTypeToHeroProDic.Add((int)BufferEvent.DelDefense , (int)GlobalDef.NewHeroProperty.PRO_ARMOR);
		bufferTypeToHeroProDic.Add((int)BufferEvent.DelWalkSpeed , (int)GlobalDef.NewHeroProperty.PRO_MOVSPD);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddWalkSpeed , (int)GlobalDef.NewHeroProperty.PRO_MOVSPD);
		bufferTypeToHeroProDic.Add((int)BufferEvent.SustainedAddHp , (int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		bufferTypeToHeroProDic.Add((int)BufferEvent.SustainedDelHp , (int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AutoAddMp , (int)GlobalDef.NewHeroProperty.PRO_MP_GETAUTO);

		
		bufferTypeToHeroProDic.Add((int)BufferEvent.IngoreDefense , (int)GlobalDef.UnitState.State_IngoreDefense);
		bufferTypeToHeroProDic.Add((int)BufferEvent.ReflectDamage , (int)GlobalDef.UnitState.State_ReflectDamage);
		bufferTypeToHeroProDic.Add((int)BufferEvent.Silent , (int)GlobalDef.UnitState.State_Silent);
		bufferTypeToHeroProDic.Add((int)BufferEvent.Shackles , (int)GlobalDef.UnitState.State_Shackles);
		bufferTypeToHeroProDic.Add((int)BufferEvent.ImmuneAllDamage , (int)GlobalDef.UnitState.State_ImmuneAllDamage);
		bufferTypeToHeroProDic.Add((int)BufferEvent.Vertigo , (int)GlobalDef.UnitState.State_Vertigo);
		bufferTypeToHeroProDic.Add((int)BufferEvent.DamageDouble , (int)GlobalDef.UnitState.State_DoubleDamage);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddManaPoint , (int)GlobalDef.UnitState.State_DoubleManaPoint);
		bufferTypeToHeroProDic.Add((int)BufferEvent.Charm , (int)GlobalDef.UnitState.State_Charm);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AtackCombosOne , (int)GlobalDef.UnitState.State_AtackCombosOne);
		bufferTypeToHeroProDic.Add((int)BufferEvent.UpDamage , (int)GlobalDef.UnitState.State_UpDamage);
		bufferTypeToHeroProDic.Add((int)BufferEvent.SkillDamageUp , (int)GlobalDef.UnitState.State_SkillDamageUp);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AllDamageUp , (int)GlobalDef.UnitState.State_AllDamageUp);
		bufferTypeToHeroProDic.Add((int)BufferEvent.DelSkillCd , (int)GlobalDef.UnitState.State_DelSkillCd);
		bufferTypeToHeroProDic.Add((int)BufferEvent.CriticalCertain , (int)GlobalDef.UnitState.State_CriticalCertain);
		bufferTypeToHeroProDic.Add((int)BufferEvent.AddAttackByHp , (int)GlobalDef.UnitState.State_AddAttackByHp);
		bufferTypeToHeroProDic.Add((int)BufferEvent.ShieldBoom , (int)GlobalDef.UnitState.State_ShieldBoom);
		bufferTypeToHeroProDic.Add((int)BufferEvent.CumulativeThreeAtk , (int)GlobalDef.UnitState.State_CumulativeThreeAtk);
		bufferTypeToHeroProDic.Add((int)BufferEvent.ReflectDamageAddHp , (int)GlobalDef.UnitState.State_ReflectDamageAddHp);
		bufferTypeToHeroProDic.Add((int)BufferEvent.SkillNotUseMp , (int)GlobalDef.UnitState.State_SkillNotUseMp);

	}
	
	public int GetAttrOrStateKey(int bufferEvent){
		if(bufferTypeToHeroProDic.ContainsKey(bufferEvent)){
			return bufferTypeToHeroProDic[bufferEvent];
		}
		Debug.LogError("[BufferManager.GetAttrOrStateKey] : could not find the hero attr or state which will be modify!");
		return -1;
	}
}