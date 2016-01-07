using UnityEngine;
using System.Collections;

public class LabEventListener : MonoBehaviour
{
    public enum EventType
    {
        Gold,
        Diamond,
        SoulStone,
        Stamina
    }

    private LabEventManager manager { get { return LabEventManager.instance; } }

    public EventType tp = EventType.Gold;

    private UILabel mLab;
    private UILabel lab
    {
        get
        {
            if (mLab == null) mLab = GetComponent<UILabel>();
            if (mLab == null) mLab = gameObject.AddComponent<UILabel>();
            return mLab;
        }
    }

    void UpdateEvent(string str)
    {
        //Debug.Log(str);
        lab.text = str;
    }

    void Start()
    {
        switch (tp)
        {
            case EventType.Gold:
                manager.goldEvent += UpdateEvent;
                break;
            case EventType.Diamond:
                manager.diamondEvent += UpdateEvent;
                break;
            case EventType.SoulStone:
                manager.soulStoneEvent += UpdateEvent;
                break;
            case EventType.Stamina:
                manager.staminaEvent += UpdateEvent;
                break;
        }
    }

    //void OnDisable()
    //{
    //    switch (tp)
    //    {
    //        case EventType.Gold:
    //            manager.goldEvent -= UpdateEvent;
    //            break;
    //        case EventType.Diamond:
    //            manager.diamondEvent -= UpdateEvent;
    //            break;
    //        case EventType.SoulStone:
    //            manager.soulStoneEvent -= UpdateEvent;
    //            break;
    //        case EventType.Stamina:
    //            manager.staminaEvent -= UpdateEvent;
    //            break;
    //    }
    //}
}

