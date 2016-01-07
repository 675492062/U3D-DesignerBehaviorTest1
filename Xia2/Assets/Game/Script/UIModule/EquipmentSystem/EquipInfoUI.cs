using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EquipInfoUI : MonoBehaviour {

	public GameObject CurEquipmentUI;
    public GameObject EquipmentInfoUI;
    public GameObject ButtonScrollView;
    public GameObject EquipmentBox;
    public UIGrid grid;

    private EquipItemUI curEquipmentUI;
    private EquipItemUI equipmentInfoUI;
    private Vector3 CurEquipmentUIpoint;
    private Vector3 EquipmentInfoUIpoint;


	// Use this for initialization
    void Avake()
    {
        CurEquipmentUIpoint = CurEquipmentUI.transform.localPosition;
        EquipmentInfoUIpoint = EquipmentInfoUI.transform.localPosition;
    }
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    void OnGUI() 
	{

    }

    public void addEquipment(EquipmentItem itemHero, EquipmentItem itemBag)
    {
        if (itemHero == null && itemBag == null)
        {
            gameObject.SetActive(false);
            return;
        }


        if (itemHero == null)
        {
            if (itemBag.gholestar1 == 0)
            {
                objLocation((int)GlobalDef.EquipStateType.EQUIP_ALLGRADE,
                      (int)GlobalDef.EquipStateType.EQUIP_LEFT,
                      0, itemHero, itemBag);
            }
            else 
            {
                objLocation((int)GlobalDef.EquipStateType.EQUIP_ALLGRADE,
                      (int)GlobalDef.EquipStateType.EQUIP_RIGHT,
                      0, itemHero, itemBag);
            }
           
        }

        if (itemBag == null)
        {
            if (itemHero.gholestar1 == 0)
            {
                objLocation((int)GlobalDef.EquipStateType.EQUIP_ALLGRADE,
                      (int)GlobalDef.EquipStateType.EQUIP_LEFT,
                      0, itemHero, itemBag);
            }
            else
            {
                objLocation((int)GlobalDef.EquipStateType.EQUIP_ALLGRADE,
                      (int)GlobalDef.EquipStateType.EQUIP_RIGHT,
                      0, itemHero, itemBag);
            }
        }


        if (itemBag != null && itemHero != null)
        {

            if (itemHero.gholestar1 == 0 && itemBag.gholestar1 == 0)
            {
                objLocation((int)GlobalDef.EquipStateType.EQUIP_LOWGRADE, 0, 
                    0, itemHero, itemBag);
            }

           else if (itemHero.gholestar1 != 0 && itemBag.gholestar1 != 0)
            {
                objLocation((int)GlobalDef.EquipStateType.EQUIP_HIGHTGRADE, 0,
                    0, itemHero, itemBag);
            }

            else if (itemHero.gholestar1 == 0 && itemBag.gholestar1 != 0)
            {
                objLocation((int)GlobalDef.EquipStateType.EQUIP_ALLGRADE,
                            (int)GlobalDef.EquipStateType.EQUIP_CENTER,
                            (int)GlobalDef.EquipStateType.EQUIP_ONDRESS, itemHero, itemBag);
            }

            else if (itemHero.gholestar1 != 0 && itemBag.gholestar1 == 0)
            {
                objLocation((int)GlobalDef.EquipStateType.EQUIP_ALLGRADE,
                            (int)GlobalDef.EquipStateType.EQUIP_CENTER,
                            (int)GlobalDef.EquipStateType.EQUIP_INBAG, itemHero, itemBag);
            }  
        }      
    }

    private void objLocation(int current, int count, int itemCount, EquipmentItem itemHero, EquipmentItem itemBag)
    { 
        //定位    
        //分三种可能布局 current == 2 3 4
        CurEquipmentUI.SetActive(true);
        EquipmentInfoUI.SetActive(true);
        destroy(EquipmentBox);
       
        if (current == (int)GlobalDef.EquipStateType.EQUIP_LOWGRADE)
        {
            EquipmentInfoUI.SetActive(false);
            GameObject obj = Instantiate(CurEquipmentUI,new Vector3(0,0,0),Quaternion.identity) as GameObject;
            obj.transform.parent = EquipmentBox.transform;
			obj.transform.localPosition = new Vector3(170, -3.34f, 0);
            obj.transform.localScale = new Vector3(1,1,1);
            EquipItemUI itemB = obj.GetComponent<EquipItemUI>();
            itemB.UpdateInfo(itemBag);
            itemB.m_close.gameObject.SetActive(true); 
            itemB.m_equipSprite.gameObject.SetActive(false);

			CurEquipmentUI.transform.localPosition = new Vector3(-170, -3.34f, 0);
            EquipItemUI itemH = CurEquipmentUI.GetComponent<EquipItemUI>();
            itemH.UpdateInfo(itemHero);
            itemH.m_close.gameObject.SetActive(false);
            itemH.m_equipSprite.gameObject.SetActive(true);
            ButtonScrollView.transform.localPosition = new Vector3(395, -50, 0);
        }

         else if (current == (int)GlobalDef.EquipStateType.EQUIP_HIGHTGRADE)
        {
            CurEquipmentUI.SetActive(false);
            GameObject obj = Instantiate(EquipmentInfoUI, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            obj.transform.parent = EquipmentBox.transform;
            obj.transform.localPosition = new Vector3(170, 0, 0);
            obj.transform.localScale = new Vector3(1, 1, 1);
            EquipmentInfoUI.transform.localPosition = new Vector3(-170, 0, 0);
            EquipItemUI itemB = obj.GetComponent<EquipItemUI>();
            itemB.UpdateInfo(itemBag);
            itemB.m_close.gameObject.SetActive(true); 
            itemB.m_equipSprite.gameObject.SetActive(false);

            EquipItemUI itemH = EquipmentInfoUI.GetComponent<EquipItemUI>();
            itemH.UpdateInfo(itemHero);
            itemH.m_close.gameObject.SetActive(false);
            itemH.m_equipSprite.gameObject.SetActive(true);
            ButtonScrollView.transform.localPosition = new Vector3(395, -150, 0);
        }

        else if (current == (int)GlobalDef.EquipStateType.EQUIP_ALLGRADE)
        {
            //count == 5 6 7
            if (count == (int)GlobalDef.EquipStateType.EQUIP_LEFT)
            {
                EquipmentInfoUI.SetActive(false);
				CurEquipmentUI.transform.localPosition = new Vector3(0, -3.34f, 0);
                ButtonScrollView.transform.localPosition = new Vector3(225, -50, 0);

                EquipItemUI itemH = CurEquipmentUI.GetComponent<EquipItemUI>();
                if (itemHero != null)
                {                  
                    itemH.UpdateInfo(itemHero);
                    itemH.m_close.gameObject.SetActive(true);
                    itemH.m_equipSprite.gameObject.SetActive(true);
                }

                if (itemBag != null)
                {
                    itemH.UpdateInfo(itemBag);
                    itemH.m_equipSprite.gameObject.SetActive(false);
                    itemH.m_close.gameObject.SetActive(true);
                }
                    
            }

           else if (count == (int)GlobalDef.EquipStateType.EQUIP_RIGHT)
            {
                CurEquipmentUI.SetActive(false);
                EquipmentInfoUI.transform.localPosition = new Vector3(0, 0, 0);
                
                ButtonScrollView.transform.localPosition = new Vector3(225, -150, 0);

                EquipItemUI itemH = EquipmentInfoUI.GetComponent<EquipItemUI>();

                if (itemHero != null)
                {
                    itemH.UpdateInfo(itemHero);
                    itemH.m_close.gameObject.SetActive(true);
                    itemH.m_equipSprite.gameObject.SetActive(true);
                }

                if (itemBag != null)
                {
                    itemH.UpdateInfo(itemBag);
                    itemH.m_close.gameObject.SetActive(true);
                    itemH.m_equipSprite.gameObject.SetActive(false);
                }
            }

            else if (count == (int)GlobalDef.EquipStateType.EQUIP_CENTER)
            {
                //判断装备是属于哪个档次 来布局
                if (itemCount == (int)GlobalDef.EquipStateType.EQUIP_ONDRESS)
                {
					CurEquipmentUI.transform.localPosition = new Vector3(-170, -3.34f, 0);
                    EquipmentInfoUI.transform.localPosition = new Vector3(170, 0, 0);
                    ButtonScrollView.transform.localPosition = new Vector3(395, -150, 0);

                    EquipItemUI itemH = CurEquipmentUI.GetComponent<EquipItemUI>();
                    itemH.UpdateInfo(itemHero);
                    itemH.m_close.gameObject.SetActive(false);
                    itemH.m_equipSprite.gameObject.SetActive(true);

                    EquipItemUI itemB = EquipmentInfoUI.GetComponent<EquipItemUI>();
                    itemB.UpdateInfo(itemBag);
                    itemB.m_close.gameObject.SetActive(true);
                    itemB.m_equipSprite.gameObject.SetActive(false);

                }
                else if (itemCount == (int)GlobalDef.EquipStateType.EQUIP_INBAG)
                {
					CurEquipmentUI.transform.localPosition = new Vector3(170, -3.34f, 0);
                    EquipmentInfoUI.transform.localPosition = new Vector3(-170, 0, 0);
                    ButtonScrollView.transform.localPosition = new Vector3(395, -50, 0);
                    EquipItemUI itemH = EquipmentInfoUI.GetComponent<EquipItemUI>();
                    itemH.UpdateInfo(itemHero);
                    itemH.m_close.gameObject.SetActive(false);
                    itemH.m_equipSprite.gameObject.SetActive(true);

                    EquipItemUI itemB = CurEquipmentUI.GetComponent<EquipItemUI>();
                    itemB.UpdateInfo(itemBag);
                    itemB.m_close.gameObject.SetActive(true);
                    itemB.m_equipSprite.gameObject.SetActive(false);
                }
            }
        }
        ButtonScrollView.SetActive(false);
        ButtonScrollView.SetActive(true);
        if (grid != null)
            grid.repositionNow = true;
    }

    private void destroy(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
