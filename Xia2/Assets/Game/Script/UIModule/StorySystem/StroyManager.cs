using UnityEngine;
using System.Collections;

public class StroyManager : MonoBehaviour {

	public UIPanel StroyPanel;
	public UIPanel parent;

	UIPanel story = null;//temp
	// Use this for initialization
	void Start () 
	{
		if(!MonoInstancePool.getInstance<UserData>().stroyPlayed)
		{
			startStory(611001);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startStory(int templateID)
	{
		story  = Instantiate(StroyPanel, Vector3.zero, Quaternion.identity) as UIPanel;
		story.transform.parent = parent.transform;
		story.transform.localScale = Vector3.one;
		story.transform.localPosition = Vector3.zero;
		story.gameObject.SetActive(true);

		StroyPlay play = story.GetComponentInChildren<StroyPlay>();
		if(null != play)
		{
			play.play(templateID);
		}
	}
	public void endStroy(int templateID)
	{
//		MainScenePanelManager manager = (MainScenePanelManager)FindObjectOfType(typeof(MainScenePanelManager));
//		if(manager != null)
//		{
//			manager.openAcceptTaskWindow();
//
//			AcceptTaskWindow info = manager.AcceptTaskWindow.GetComponentInChildren<AcceptTaskWindow>();
//			if(info != null)
//			{
//				info.taskID = templateID;
//			}
//
//		}
//		story.gameObject.AddComponent<AutoDestroyGameObj>();
//
//		MonoInstancePool.getInstance<UserData>().stroyPlayed = true;
	}
}
