using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BufferController{

	List<DBaseBuffer> bufferList = new List<DBaseBuffer>();
	
	Dictionary<int , Transform> effectDic = new Dictionary<int, Transform>();
	
	Unit baseUnit;
	
	public BufferController(){
	}
	
	public void Update(){
		for(int i = bufferList.Count - 1 ; i >=0 ; i--){
			if(bufferList[i].Update(Time.deltaTime)){
				bufferList.RemoveAt(i);
				GetBaseUnit().m_curHeroData.refreshProperty();
			}
		}
	}
	
	public void Init(Unit baseUnit){
		this.baseUnit = baseUnit;
		bufferList.Clear();
		if(baseUnit == null)Debug.LogError("[BufferController]: the baseUnit need have one unit script!");
	}
	
	public void ResetUnit(Unit baseUnit){
		this.baseUnit = baseUnit;
	}
	
	Unit GetBaseUnit(){return baseUnit;}
	
	public void AddOneBufferById(int id,Transform fx,Transform atkCollider){
		BufferStruct bufferStruct = MonoInstancePool.getInstance<BufferManager>().GetBufferStructById(id);
		DBaseBuffer buffer = bufferStruct.DBaseBuffer;
		if(CheckBufferExist((int)buffer.id))
			DestoryEffect(buffer.id);
		buffer.atkCollider = atkCollider;
		bufferList.Add(buffer);
		bool handresult =HandleBufferEvent(buffer);
		if (!handresult) {
			RemoveBufferById(buffer.id);
			return;
		}
		effectDic.Add(buffer.id ,fx);
	}
	
	public void RemoveBufferById(int id){
		int index = IsBufferring(id);
		if(index == -1){
			Debug.LogError("[BufferController RemoveBufferById ] the hero doesnot own this buffer which id is " + id);
			return;
		}
		bufferList.RemoveAt(index);
		DestoryEffect(id);
	}
	
	public void RemoveAllBuffer(){
		bufferList.Clear();
		int count = effectDic.Count;
		foreach(KeyValuePair<int  , Transform > keyValue in effectDic){
			if( keyValue.Value )
				GameObject.Destroy(keyValue.Value.gameObject);
		}
	}

	public List<AttrTimeBuffer> FindAttrBuffers()
	{
		List<AttrTimeBuffer> aryBuf = new List<AttrTimeBuffer> ();
		for (int i = 0; i < bufferList.Count; i++) {
			if( bufferList[i] == null )
				continue;
			if( bufferList[i].GetType() !=  typeof(AttrTimeBuffer) )
				continue;
			AttrTimeBuffer buff = (AttrTimeBuffer)bufferList[i];		
			if( buff == null )
				continue;
			aryBuf.Add(buff);
		}
		return aryBuf;
	}
	
	public void HideAllEffect(){
		foreach(KeyValuePair<int  , Transform > keyValue in effectDic){
			if( keyValue.Value )
				keyValue.Value.gameObject.SetActive(false);
		}
	}
	
	public void ShowAllEffect(){
		foreach(KeyValuePair<int  , Transform > keyValue in effectDic){
			if( keyValue.Value )
				keyValue.Value.gameObject.SetActive(true);
		}
	}
	
	bool HandleBufferEvent(DBaseBuffer gameBuffer){
		BufferEvent bufferEvent = (BufferEvent)gameBuffer.id;
		
		switch(bufferEvent){
				case BufferEvent.AddHpMax:
				case BufferEvent.AddAtackSpeed:
				case BufferEvent.AddAtackStrength:
				case BufferEvent.AddArmor:
				case BufferEvent.AddCritLv:
				case BufferEvent.AddToughnessLv:
				case BufferEvent.AddDodgeLv:
				case BufferEvent.DelWalkSpeed:
				case BufferEvent.AddWalkSpeed:
				case BufferEvent.SustainedAddHp:
				case BufferEvent.SustainedDelHp:
				case BufferEvent.DelDefense:
				case BufferEvent.DelHit:
				case BufferEvent.DelAtackStrength:
				case BufferEvent.AutoAddMp:
					HandleNormalAttrBuffer((AttrTimeBuffer)gameBuffer);
					return true;
				case BufferEvent.AddAttackByHp:
					HandleAddAtackByHpBuffer((AddAttackByHpBuffer)gameBuffer);
					return true;
				case BufferEvent.Silent:
				case BufferEvent.IngoreDefense:
				case BufferEvent.Shackles:
				case BufferEvent.ImmuneAllDamage:
				case BufferEvent.DamageDouble:
				case BufferEvent.Vertigo:
				case BufferEvent.AddManaPoint:
				case BufferEvent.Charm:
				case BufferEvent.ReflectDamage:
				case BufferEvent.AtackCombosOne:
				case BufferEvent.UpDamage:
				case BufferEvent.SkillDamageUp:
				case BufferEvent.AllDamageUp:
				case BufferEvent.DelSkillCd:
				case BufferEvent.CriticalCertain:
				case BufferEvent.CumulativeThreeAtk:
				case BufferEvent.ReflectDamageAddHp:
					HandleNormalStateBuffer((StateTimeBuffer)gameBuffer);
					return true;
				case BufferEvent.ShieldBoom:
					HandleShieldBoomBuffer((ShieldBoomBuffer)gameBuffer);
					return true;
				case BufferEvent.SkillNotUseMp:
					HandleSkillNotUseMpBuffer((SkillNotUseMpBuffer)gameBuffer);
					return true;
				default:
					Debug.LogError("[BufferController.HandleBufferEvent]: you may forget to handle with this buffer : " + bufferEvent.ToString());
					break;
		}
		return false;
	}

	//< 护盾爆
	void HandleShieldBoomBuffer(ShieldBoomBuffer buffer){
		int heroProId = MonoInstancePool.getInstance<BufferManager>().GetAttrOrStateKey(buffer.id);
		if(heroProId == -1){
			return;
		}
		buffer.addBufferEvent = delegate(object[] paramsValue) {
			GetBaseUnit().setState(heroProId , buffer.stateParams);
		};

		buffer.removeBufferEvent = delegate(object[] paramsValue) {
			GetBaseUnit().removeState(heroProId);
			if(effectDic.ContainsKey((int)BufferEvent.ShieldBoom)){
				Transform effect = effectDic[(int)BufferEvent.ShieldBoom];
				if(effect != null){
					var effectfx = (Ef_triggerOtherFx)effect.GetComponent(typeof(Ef_triggerOtherFx));
					if(effectfx != null)effectfx.FireBoom();
					effectDic.Remove((int)BufferEvent.ShieldBoom);
				}
			}
		};
		buffer.Init ();
	}

	void HandleSkillNotUseMpBuffer( SkillNotUseMpBuffer buffer )
	{
		int heroProId = MonoInstancePool.getInstance<BufferManager>().GetAttrOrStateKey(buffer.id);
		if(heroProId == -1){
			return;
		}
		buffer.removeBufferEvent = delegate(object[] paramsValue) {
			DestoryEffect(buffer.id);	
		};
		buffer.Init ();
	}
	
	void HandleAddAtackByHpBuffer(AddAttackByHpBuffer buffer){
		int heroProId = MonoInstancePool.getInstance<BufferManager>().GetAttrOrStateKey(buffer.id);
		if(heroProId == -1){
			return;
		}
		buffer.removeBufferEvent = delegate(object[] paramsValue) {
			GetBaseUnit().m_curHeroData.addEffectProNum((int)GlobalDef.NewHeroProperty.PRO_ATTACK, - (int)buffer.GetAddedHp());
			GetBaseUnit().m_curHeroData.refreshProperty();
			DestoryEffect(buffer.id);
		};
		buffer.Init ();

	}
		
	void HandleNormalAttrBuffer(AttrTimeBuffer buffer){
		int heroProId = MonoInstancePool.getInstance<BufferManager>().GetAttrOrStateKey(buffer.id);
		if(heroProId == -1){
			return;
		}
		
		buffer.addBufferEvent = delegate(object[] paramsValue) {
			if(buffer.addNum != 0)
				GetBaseUnit().m_curHeroData.addEffectProNum(heroProId, buffer.addNum);
            if (buffer.addPercent != 0)
				GetBaseUnit().m_curHeroData.addEffectProPercent(heroProId, buffer.addPercent);
			GetBaseUnit().m_curHeroData.refreshProperty();
		};
		
		buffer.removeBufferEvent = delegate(object[] paramsValue) {
			DestoryEffect(buffer.id);
			if(buffer.addNum != 0)
				GetBaseUnit().m_curHeroData.addEffectProNum(heroProId, -buffer.addNum);
			if (buffer.addPercent != 0)
				GetBaseUnit().m_curHeroData.addEffectProPercent(heroProId, -buffer.addPercent);
		};
		buffer.Init ();
	}
	
	void DestoryEffect(int id){
		if(effectDic.ContainsKey(id)){
			if(effectDic[id] != null)GameObject.Destroy(effectDic[id].gameObject);
			effectDic.Remove(id);
		}
	}
	
	void HandleNormalStateBuffer(StateTimeBuffer buffer){
		int heroStateId = MonoInstancePool.getInstance<BufferManager>().GetAttrOrStateKey(buffer.id);
		if(heroStateId == -1){
			return;
		}
		buffer.addBufferEvent = delegate(object[] paramsValue) {
			GetBaseUnit().setState(heroStateId , buffer.stateParams);
		};
		
		buffer.removeBufferEvent = delegate(object[] paramsValue) {
			GetBaseUnit().removeState(heroStateId);
			DestoryEffect(buffer.id);
		};
		buffer.Init ();
	}
	
	bool CheckBufferExist(int id){
		int index = IsBufferring(id);
		if(index != -1){
			bufferList.RemoveAt(index);
			return true;
		}
		return false;
	}

	int IsBufferring(int bufferId){
		int count = bufferList.Count;
		for(int i = 0 ; i < count ; i++){
			if((int)bufferList[i].id == bufferId){
				return i;
			}
		}
		return -1;
	}

	// or disable
	void OnDestory(){
//		RemoveAllBuffer();
	}

	public bool AbsorbDamage(float damage){
		int result = IsBufferring((int)BufferEvent.ShieldBoom);
		if(result == -1){
			//Debug.LogError("[the addAttackbyHp buffer is over,you may be wrong!]");
			return true;
		}
		return ((ShieldBoomBuffer)bufferList[result]).AddDamage(damage);
	}
	
	public void AddAttackByHp(){
		int result = IsBufferring((int)BufferEvent.AddAttackByHp);
		if(result == -1){
			return;
		}
		float currentHp = GetBaseUnit().getCurProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		int added =  (int)Mathf.Clamp(2000 - currentHp * 0.2f , 20 , 2000);
		
		//		float ccc = GetBaseUnit ().getCurProperty ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		//		float max = GetBaseUnit ().getProperty ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		GetBaseUnit().m_curHeroData.addEffectProNum((int)GlobalDef.NewHeroProperty.PRO_ATTACK, added);
		GetBaseUnit().m_curHeroData.refreshProperty();
		((AddAttackByHpBuffer)bufferList[result]).AddHp(added);
		
		//		ccc = GetBaseUnit ().getCurProperty ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		//		max = GetBaseUnit ().getProperty ((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
		//		int a = 0;
	}

	//< 每第3次攻击造成大量伤害
	public bool AddThreeAtkBuffCount()
	{
		int result = IsBufferring((int)BufferEvent.CumulativeThreeAtk);
		if(result == -1){
			return false;
		}
		//CumulativeThreeAtkBuffer buff = ((CumulativeThreeAtkBuffer)bufferList[result]);
		((CumulativeThreeAtkBuffer)bufferList [result]).AddCount ();
		//buff.AddCount ();
		return true;
	}
	public float CheckTriggerThreeAtkBuff( float damage )
	{
		int result = IsBufferring((int)BufferEvent.CumulativeThreeAtk);
		if(result == -1){
			return damage;
		}
		CumulativeThreeAtkBuffer buff = ((CumulativeThreeAtkBuffer)bufferList[result]);
		return buff.CheckTrigger ( damage);
	}

	//< 使用N次技能不消耗MP
	public void AddSkillNotUseMpCount()
	{
		int result = IsBufferring((int)BufferEvent.SkillNotUseMp);
		if(result == -1){
			return;
		}
		bool b = ((SkillNotUseMpBuffer)bufferList [result]).AddCount();
		if (!b) {
			RemoveBufferById(bufferList[result].id);						
		}
	}

	public bool CheckTriggerSkillNotUseMp()
	{
		int result = IsBufferring((int)BufferEvent.SkillNotUseMp);
		if(result == -1){
			return false;
		}
		int count = ((SkillNotUseMpBuffer)bufferList [result]).GetCount ();
		if (count <= 0)
			return false;
		return true;
	}
}