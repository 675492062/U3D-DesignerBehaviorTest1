using UnityEngine;
using System.Collections;

public abstract class DBaseBuffer
{
    public int id;							//buffer id

    public int interval;					//跳数 1,chixue  

    public float duration;					//持续时间，-1为持久性

    public int effectId;

    public delegate void BufferDelegate(params object[] paramsValue);

    public BufferDelegate addBufferEvent;

    public object[] addBufferParams;

    public BufferDelegate removeBufferEvent;

    public object[] removeBufferParams;

    public Transform atkCollider;

    public DBaseBuffer(int id, int interval, float duraion)
    {
        this.id = id;
        this.interval = interval;
        this.duration = duraion;
    }

    public abstract bool Update(float delta);

    public void ExecuteAddBufferEvent()
    {
        if (addBufferEvent != null)
        {
            addBufferEvent(addBufferParams);
        }
    }

    public void ExecuteRemoveBufferEvent()
    {
        if (removeBufferEvent != null)
        {
            removeBufferEvent(removeBufferParams);
        }
    }
}

////被动buffer
public class PassiveBuffer : DBaseBuffer
{
    public PassiveBuffer(int newId, int newInterval, float newduration)
        : base(newId, newInterval, newduration)
    {

    }
    public override bool Update(float delta) { return false; }
}

//时间buffer
public class TimeBuffer : DBaseBuffer
{
    float timeCount;

    public TimeBuffer(int newId, int newInterval, float newduration)
        : base(newId, newInterval, newduration)
    {
        //Init();
    }

    public void Init()
    {
        timeCount = 0;
        interval = 0;
        ExecuteAddBufferEvent();
    }

    public override bool Update(float delta)
    {
        timeCount += delta;
        if (interval > 0 && interval <= timeCount)
        {
            ExecuteAddBufferEvent();
            timeCount = 0;
        }
        duration -= delta;
        if (duration <= 0)
        {
            ExecuteRemoveBufferEvent();
            return true;
        }
        return false;
    }
}

public class AttrTimeBuffer : TimeBuffer
{
    public float addPercent;
    public int addNum;

    public AttrTimeBuffer(int newId, int newInterval, float newduration, float addPercent, int addNum)
        : base(newId, newInterval, newduration)
    {
        this.addPercent = addPercent / 100;
        this.addNum = addNum;
    }
}
/// <summary>
/// State parameters.
/// </summary>
[System.Serializable]
public class StateParams
{
    public int iValue;
    public float fvalue;
    public object[] extraValue;
}

public class StateTimeBuffer : TimeBuffer
{
    public StateParams stateParams;

    public StateTimeBuffer(int newId, int newInterval, float newduration, float fvalue, int iValue)
        : base(newId, newInterval, newduration)
    {
        stateParams = new StateParams();
        stateParams.iValue = iValue;
        stateParams.fvalue = fvalue;
    }
}

public class AddAttackByHpBuffer : StateTimeBuffer
{
    float hasAddedHp = 0;

    public AddAttackByHpBuffer(int newId, int newInterval, float newduration, float fvalue, int iValue)
        : base(newId, newInterval, newduration, fvalue, iValue)
    {
        hasAddedHp = 0;
    }

    public float AddHp(float added)
    {
        hasAddedHp += added;
        return hasAddedHp;
    }

    public float GetAddedHp() { return hasAddedHp; }
}

public class ShieldBoomBuffer : StateTimeBuffer
{
    float currentDamage;

    public ShieldBoomBuffer(int newId, int newInterval, float newduration, float fvalue, int iValue)
        : base(newId, newInterval, newduration, fvalue, iValue)
    {
        currentDamage = (float)iValue;
    }

    public bool AddDamage(float added)
    {
        currentDamage += added;
        if (currentDamage <= 0)
        {
            removeBufferEvent();
            removeBufferEvent = null;
            duration = -1;
            return true;
        }
        return false;
    }
    public float GetDamage() { return this.currentDamage; }
}


//< 每第3次攻击造成大量伤害
public class CumulativeThreeAtkBuffer : StateTimeBuffer
{
    int count = 0;
    public CumulativeThreeAtkBuffer(int newId, int newInterval, float newduration, float fvalue, int iValue)
        : base(newId, newInterval, newduration, fvalue, iValue)
    {
        count = 0;
    }

    public void AddCount()
    {
        if (count > 2)
            count = 0;
        count++;

    }

    public float CheckTrigger(float damge)
    {
        if (count >= 3)
        {
            stateParams.fvalue = 250;
            return damge * stateParams.fvalue / 100 + stateParams.iValue;
        }
        return damge;
    }
}

//< 使用N次技能不消耗MP
public class SkillNotUseMpBuffer : StateTimeBuffer
{
    int count = 0;
    public SkillNotUseMpBuffer(int newId, int newInterval, float newduration, float fvalue, int iValue)
        : base(newId, newInterval, newduration, fvalue, iValue)
    {
        count = iValue;
    }

    public bool AddCount()
    {
        count--;
        if (count <= 0)
        {
            count = 0;
            return false;
        }
        return true;
    }

    public int GetCount()
    {
        return count;
    }
}

//< 貂蝉魅惑
public class CharmBuffer : StateTimeBuffer
{
    int count = 0;
    Vector3 targetPos = new Vector3();
    public CharmBuffer(int newId, int newInterval, float newduration, float fvalue, int iValue)
        : base(newId, newInterval, newduration, fvalue, iValue)
    {
        count = iValue;
        targetPos = atkCollider.position;
        targetPos.y = 0;
        stateParams.extraValue = new object[1];
        stateParams.extraValue[0] = targetPos;
    }
}


public class BufferFactory
{
    public static DBaseBuffer CreateOneBuffer(int typeId, int newInterval, float newDuration, float param1, int param2)
    {
        BufferEvent typeEvent = (BufferEvent)typeId;
        switch (typeEvent)
        {
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
                return CreateAttrBuffer(typeId, newInterval, newDuration, param1, param2);
            //state
            case BufferEvent.Silent:
            case BufferEvent.IngoreDefense:
            case BufferEvent.Shackles:
            case BufferEvent.ImmuneAllDamage:
            case BufferEvent.DamageDouble:
            case BufferEvent.Vertigo:
            case BufferEvent.AddManaPoint:
            case BufferEvent.ReflectDamage:
            case BufferEvent.UpDamage:
            case BufferEvent.SkillDamageUp:
            case BufferEvent.AllDamageUp:
            case BufferEvent.DelSkillCd:
            case BufferEvent.CriticalCertain:
            case BufferEvent.AtackCombosOne:
            case BufferEvent.ReflectDamageAddHp:
                return CreateStateBuffer(typeId, newInterval, newDuration, param1, param2);
            //espcial
            case BufferEvent.AddAttackByHp:
                return CreateAddAttackbyHpBuffer(typeId, newInterval, newDuration, param1, param2);
            case BufferEvent.ShieldBoom:
                return CreateShieldBuffer(typeId, newInterval, newDuration, param1, param2);
            case BufferEvent.CumulativeThreeAtk:
                return CreateCumulativeThreeAtkBuffer(typeId, newInterval, newDuration, param1, param2);
            case BufferEvent.SkillNotUseMp:
                return CreateSkillNotUseMpBuffer(typeId, newInterval, newDuration, param1, param2);
            case BufferEvent.Charm:
                return CreateCharmBuffer(typeId, newInterval, newDuration, param1, param2);
            default:
                {
                    Debug.LogError("s");
                }
                break;

        }
        Debug.LogError("[BufferFactory] could not find the buffer which type is " + typeEvent.ToString());
        return null;
    }

    public static AttrTimeBuffer CreateAttrBuffer(int typeId, int newInterval, float newDuration, float param1, int param2)
    {
        return new AttrTimeBuffer(typeId, newInterval, newDuration, param1, param2);
    }

    public static StateTimeBuffer CreateStateBuffer(int typeId, int newInterval, float newDuation, float parma1, int param2)
    {
        return new StateTimeBuffer(typeId, newInterval, newDuation, parma1, param2);
    }

    public static AddAttackByHpBuffer CreateAddAttackbyHpBuffer(int typeId, int newInterval, float newDuation, float parma1, int param2)
    {
        return new AddAttackByHpBuffer(typeId, newInterval, newDuation, parma1, param2);
    }

    public static ShieldBoomBuffer CreateShieldBuffer(int typeId, int newInterval, float newDuation, float parma1, int param2)
    {
        return new ShieldBoomBuffer(typeId, newInterval, newDuation, parma1, param2);
    }

    //< 每第3次攻击造成大量伤害
    public static CumulativeThreeAtkBuffer CreateCumulativeThreeAtkBuffer(int typeId, int newInterval, float newDuation, float parma1, int param2)
    {
        return new CumulativeThreeAtkBuffer(typeId, newInterval, newDuation, parma1, param2);
    }

    //< 使用N次技能不消耗MP
    public static SkillNotUseMpBuffer CreateSkillNotUseMpBuffer(int typeId, int newInterval, float newDuation, float parma1, int param2)
    {
        return new SkillNotUseMpBuffer(typeId, newInterval, newDuation, parma1, param2);
    }

    //< 使用貂蝉魅惑
    public static CharmBuffer CreateCharmBuffer(int typeId, int newInterval, float newDuation, float parma1, int param2)
    {
        return new CharmBuffer(typeId, newInterval, newDuation, parma1, param2);
    }

}