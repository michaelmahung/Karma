using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

	public AudioSource playerAudio;
	public AudioClip deathClip;
	public AudioClip hurtClip;
	//public AudioClip healClip;
	private bool canRunAudio = true;

	// Use this for initialization
	void Awake () {
		
		playerAudio = GetComponent<AudioSource> ();
		
	}

	public void Update()
	{
		/*if (canRunAudio == (true) && PlayerHealth.damaged) 
		{
			canRunAudio = false;
			playerAudio.clip = hurtClip;
			Debug.Log ("Playing hurt sound");
			playerAudio.Play ();
		}

		if (PlayerHealth.healing == (true)) 
		{
			playerAudio.clip = healClip;
			Debug.Log ("Playing healing sound");
			playerAudio.Play ();
		*/
		if (canRunAudio == (true) && PlayerHealth.isDead) 
		{
			canRunAudio = false;
			playerAudio.clip = deathClip;
			//Debug.Log ("Playing death sound");
			playerAudio.Play ();
		}
	}

}
