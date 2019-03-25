using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSFX : MonoBehaviour {

	public static bool isHurting;
	public static bool isHealing;
	public static bool isMurder;
	public static bool isOneShot;
	public AudioSource audioPlayer;
	public AudioClip hurtSound;
	public AudioClip healSound;
	public AudioClip murderSound;
	public AudioClip oneshotSound;

	// Use this for initialization
	void Start () {
		
		audioPlayer = GetComponent<AudioSource> ();
		audioPlayer.volume = 0.15f;
		audioPlayer.Stop ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isOneShot && !audioPlayer.isPlaying)
		{
			audioPlayer.clip = oneshotSound;
			audioPlayer.PlayOneShot (oneshotSound);
		}

		if (isHurting && !audioPlayer.isPlaying) 
		{
			audioPlayer.clip = hurtSound;
			audioPlayer.PlayOneShot (hurtSound);
		}

		if (isHealing && !audioPlayer.isPlaying) 
		{
			audioPlayer.clip = healSound;
			audioPlayer.PlayOneShot (healSound);
		}

		if (isMurder && !audioPlayer.isPlaying) 
		{
			audioPlayer.clip = murderSound;
			audioPlayer.PlayOneShot (murderSound);
		}
		
	}
}
