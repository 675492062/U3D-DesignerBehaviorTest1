using UnityEngine;
using System.Collections;

public class SoundEf_slash : MonoBehaviour {

	float delay = 0;
	AudioSource myaudio;
	//int priority = 256;
	
	public AudioClip thrust;
	public AudioClip smash;
	public AudioClip[] slash = new AudioClip[2];
	public AudioClip block;
	public AudioClip block_break;
	public AudioClip split;
	int rndsound =0;
	
	void Awake () 
	{
		myaudio = GetComponent<AudioSource>();
	}
	
	
	public void SoundOn(int soundkind)
	{
		switch(soundkind)
		{
		case 4:
				//myaudio.clip = split;
				//myaudio.Play();
			myaudio.PlayOneShot(split);
			break;
		case 3:
				myaudio.clip = thrust;
				myaudio.Play();
			break;
		case 2:
			myaudio.PlayOneShot(smash);
			break;
		case 1:
			if (delay <=0)
			{
				rndsound = Random.Range(0,2);
				//rndsound = (rndsound+1)%2;
				myaudio.clip = slash[rndsound];
				myaudio.Play();	
			}
			break;
		case 0:
			myaudio.clip = block;
			myaudio.Play();
			break;
		case -1:
			myaudio.PlayOneShot(block_break);
			break;	
		}
		delay =0.05f;
		/*if (priority >128)
		{
			myaudio.priority = priority;
			priority -= 1;
		}
		else
		{
			priority = 256;
		}*/
	}
	
	void Update () 
	{
		if (delay>0)
		{
			delay -= Time.deltaTime;
		}
	}
}
