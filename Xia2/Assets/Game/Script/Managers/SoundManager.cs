using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public enum SoundType{
		NormalBtnSound,
	}

	public AudioClip normalBtnClick;
	
	private static SoundManager _instance;
	
	public static SoundManager Instance{
		get{
			if(_instance == null){
				_instance = (SoundManager)GameObject.FindObjectOfType(typeof(SoundManager));
				if(_instance == null){
					GameObject gameObject = new GameObject();
					gameObject.AddComponent(typeof(SoundManager));
				}
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	void Awake(){
		if(_instance == null){
			_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}else{
			if(_instance != this){
				Destroy(this.gameObject);
				return;
			}
		}
	}
	
	public AudioClip GetAudioClip(SoundType type){
		switch(type){
			case SoundType.NormalBtnSound:
				return normalBtnClick;
		}
		Debug.LogError("[SoundManager] cannot get the audioclip by the type");
		return null;
	}
}
