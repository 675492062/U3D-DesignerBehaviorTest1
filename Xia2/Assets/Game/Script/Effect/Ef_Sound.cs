using UnityEngine;
using System.Collections;


[System.Serializable]
public class StSound
{
	public AudioClip	clip;
	public float 		startDelay = -1;
	public float 		endDelay = -1;
	public bool			loop;
	public AudioSource	audio{ set; get;}
    public bool			onlyOne{ set; get;}
	public float 		volume = -1;
}

public class Ef_Sound : MonoBehaviour {

	public StSound[] m_sounds;
	float  m_delay = 0;
	
	void Awake()
	{
		//m_audio = audio;
	}
	
	void Start () 
	{
		for (int i = 0; i < m_sounds.Length; i++) {
			StSound sound = m_sounds[i];
			sound.audio = gameObject.AddComponent<AudioSource> ();
			sound.audio.clip = sound.clip;
			sound.audio.loop = sound.loop;
			if( sound.volume > 0 )
				sound.audio.volume = sound.volume;
		}
	}

	void Update()
	{
		ProcessSkillAudio ();
	}

	public void ProcessSkillAudio()
	{

		m_delay += Time.deltaTime;

		for (int i = 0; i < m_sounds.Length; i++) {
			StSound sound = m_sounds[i];

			if( sound.audio == null  )
				continue;

			if (sound.endDelay != -1 && m_delay >= sound.endDelay) {
				sound.audio.Stop();
			}
			
			if ( sound.startDelay != -1 && !sound.onlyOne && m_delay >= sound.startDelay ) {
				sound.onlyOne = true;
				sound.audio.Play();
			}		
		}
	}
}
