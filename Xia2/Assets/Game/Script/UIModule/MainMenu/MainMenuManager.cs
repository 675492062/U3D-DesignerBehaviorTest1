using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public Transform m_aniManMBasic;   //男人动作库   
	public Transform m_aniWomenWBasic; //女人动作库 
	public Transform m_aniBigMLBasic;  //大型动作库

	public Transform particle;

	public ModelRenderTexture []ModelPreView = new ModelRenderTexture[3];//模型预览的三个纹理

	public TitleInfo[] heroInfo = new TitleInfo[3];
	public UILabel lv;
	public UILabel gold;
	public UILabel damond;
	public UILabel soulstone;
	void OnEnable()
	{
		MonoInstancePool.getInstance<HeroManager> ().fightHeroList.updateMenuModel = true;
		UIPanel panel = NGUITools.FindInParents<UIPanel> (gameObject);
		UICurrencyManager.Show (transform,panel.depth);
		if(lv != null)
			lv.text = ""+MonoInstancePool.getInstance<UserData> ().level;
	}
	// Use this for initialization
	void Start () 
	{
		
	}
	public void replay()
	{

	}
	// Update is called once per frame
	void Update () 
	{
		if(MonoInstancePool.getInstance<HeroManager>().fightHeroList.updateMenuModel == true)
		{
			MonoInstancePool.getInstance<HeroManager>().fightHeroList.updateMenuModel = false;
			refresh ();		
			for(int i = 0; i < 3; i++)
			{
				MonoInstancePool.getInstance<HeroManager>().fightHeroList.isDirtyModel[i] = true;
			}
		}
	}
	public void refresh()
	{
		FightHeroList list = MonoInstancePool.getInstance<HeroManager> ().fightHeroList;
		lv.text = ""+MonoInstancePool.getInstance<UserData> ().level;
		for(int i = 0; i < 3; i++)
		{
			HeroData data = MonoInstancePool.getInstance<HeroManager> ().getFightHeroByIdx(i);
			if(null == data)
			{
				heroInfo[i].hide();
				ModelPreView[i].clear();
				continue;
			}
			ModelPreView[i].refresh(data.templateID);
			ModelPreView[i].gameObject.GetComponentInChildren<DragModerRender>().enabled = false;
			ModelPreView[i].gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
			heroInfo[i].show();
			heroInfo[i].level.text = "Lv."+data.level;
			heroInfo[i].name.text = data.name;
			heroInfo[i].setStar(data.starLevel);
		}
		refreshInfo ();
	}
	public void refreshInfo()
	{
		lv.text = "Lv."+MonoInstancePool.getInstance<UserData> ().level;
		gold.text = ""+MonoInstancePool.getInstance<UserData> ().getMoney ((int)GlobalDef.MoneyType.MONEY_GOLD);
		damond.text = ""+MonoInstancePool.getInstance<UserData> ().getMoney ((int)GlobalDef.MoneyType.MONEY_DIAMOND);
		soulstone.text = ""+MonoInstancePool.getInstance<UserData> ().getMoney ((int)GlobalDef.MoneyType.MONEY_SOULSTONE);
	}
	public void hideEffect()
	{
		if(particle != null)
		{
			particle.gameObject.SetActive(false);
		}
	}
	public void showEffect()
	{
		if(particle != null && !particle.gameObject.activeSelf)
		{
			particle.gameObject.SetActive(true);
		}
	}
}
