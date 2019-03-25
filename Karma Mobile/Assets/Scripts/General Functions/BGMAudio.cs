using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMAudio : MonoBehaviour {

	public AudioClip greyLoop1;
	public AudioClip greyLoop2;
	public AudioClip greyTrans1;
	public AudioClip greyTrans2;
	public AudioClip greyHardMode;
	public AudioClip blueLoop1;
	public AudioClip blueLoop2;
	public AudioClip blueTrans1;
	public AudioClip blueTrans2;
	public AudioClip blueHardMode;
	public AudioClip greenLoop1;
	public AudioClip greenLoop2;
	public AudioClip greenTrans1;
	public AudioClip greenTrans2;
	public AudioClip greenHardMode;
	public AudioClip purpleLoop1;
	public AudioClip purpleLoop2;
	public AudioClip purpleTrans1;
	public AudioClip purpleTrans2;
	public AudioClip purpleHardMode;
	public AudioClip violetLoop1;
	public AudioClip violetLoop2;
	public AudioClip violetTrans1;
	public AudioClip violetTrans2;
	public AudioClip violetHardMode;
	public AudioClip pinkLoop1;
	public AudioClip pinkLoop2;
	public AudioClip pinkTrans1;
	public AudioClip pinkTrans2;
	public AudioClip pinkHardMode;
	public AudioClip goldLoop1;
	public AudioClip goldLoop2;
	public AudioClip goldTrans1;
	public AudioClip goldTrans2;
	public AudioClip goldHardMode;
	public AudioClip whiteLoop1;
	public AudioClip whiteLoop2;
	public AudioClip whiteTrans1;
	public AudioClip whiteTrans2;
	public AudioClip whiteHardMode;
	public AudioClip loop1;
	public AudioClip loop2;
	public AudioClip trans1;
	public AudioClip trans2;
	public static AudioClip trans2Clip;
	public AudioClip hardClip;
	public static AudioSource bgmAudio;
	public AudioDistortionFilter filter2;
	public AudioLowPassFilter filter;
	public bool hardModeSetup;
	public static bool musicSet;
	public bool loopPlaying;
	public static bool transitionPlayed;
	public static bool hardReady;
	public Text hardText;
	public Text healTimeText;
	public bool hardTextShown;
	private bool greyPlaying;
	private bool bluePlaying;
	private bool greenPlaying;
	private bool purplePlaying;
	private bool violetPlaying;
	private bool pinkPlaying;
	private bool goldPlaying;
	private bool whitePlaying;
	private bool hardPlaying;
	public float flashSpeed;
	public float flashTimes;
	public bool musicOverride;


	// Use this for initialization
	void Awake () {

		musicOverride = false;
		hardPlaying = false;
		hardTextShown = true;
		hardText.enabled = false;
		healTimeText.enabled = false;
		//Destroy (GameObject.Find ("Menu Player"));
		hardReady = false;
		//bgmAudio.volume = 0.75f;
		filter2 = GetComponent<AudioDistortionFilter>();
		filter = GetComponent<AudioLowPassFilter> ();
		bgmAudio = GetComponent<AudioSource> ();
		//bgmAudio.loop = true;
		//bgmAudio.playOnAwake = true;
		//bgmAudio.Play ();
		transitionPlayed = false;

	}




	public void Update()
	{

		/*if (!levelManager.startNext) {
			bgmAudio.Stop ();
		}*/
		if (Spawner.waitTime <= Spawner.hardTime && !musicOverride && levelManager.whiteLevel && !hardPlaying) {
			musicOverride = true;
			//Debug.Log ("Resetting music loop " + musicOverride);
			StopCoroutine (musicLoop ());
			StartCoroutine (musicLoop ());
		}


		if (Spawner.healTime) {
			healTimeText.enabled = true;
		} else {healTimeText.enabled = false;
		}

		if (levelManager.greyLevel && !Spawner.greyWinner && levelManager.startNext && !greyPlaying) {
			bgmAudio.loop = true;
			loop1 = greyLoop1;
			loop2 = greyLoop2;
			trans1 = greyTrans1;
			trans2 = greyTrans2;
			trans2Clip = trans2;
			hardClip = greyHardMode;
			//Debug.Log ("Starting Grey Music Loop");
			greyPlaying = true;
			StartCoroutine (musicLoop ());
		}

		if (levelManager.blueLevel && !Spawner.blueWinner && levelManager.startNext && !bluePlaying) {
			bgmAudio.loop = true;
			loop1 = blueLoop1;
			loop2 = blueLoop2;
			trans1 = blueTrans1;
			trans2 = blueTrans2;
			trans2Clip = trans2;
			hardClip = blueHardMode;
			//Debug.Log ("Starting Blue Music Loop");
			bluePlaying = true;
			StartCoroutine (musicLoop ());
		}

		if (levelManager.greenLevel && !Spawner.greenWinner && levelManager.startNext && !greenPlaying) {
			bgmAudio.loop = true;
			loop1 = greenLoop1;
			loop2 = greenLoop2;
			trans1 = greenTrans1;
			trans2 = greenTrans2;
			trans2Clip = trans2;
			hardClip = greenHardMode;
			//Debug.Log ("Starting Green Music Loop");
			greenPlaying = true;
			StartCoroutine (musicLoop ());
		}

		if (levelManager.purpleLevel && !Spawner.purpleWinner && levelManager.startNext && !purplePlaying) {
			bgmAudio.loop = true;
			loop1 = purpleLoop1;
			loop2 = purpleLoop2;
			trans1 = purpleTrans1;
			trans2 = purpleTrans2;
			trans2Clip = trans2;
			hardClip = purpleHardMode;
			//Debug.Log ("Starting Purple Music Loop");
			purplePlaying = true;
			StartCoroutine (musicLoop ());
		}

		if (levelManager.violetLevel && !Spawner.violetWinner && levelManager.startNext && !violetPlaying) {
			bgmAudio.loop = true;
			loop1 = violetLoop1;
			loop2 = violetLoop2;
			trans1 = violetTrans1;
			trans2 = violetTrans2;
			trans2Clip = trans2;
			hardClip = violetHardMode;
			//Debug.Log ("Starting Violet Music Loop");
			violetPlaying = true;
			StartCoroutine (musicLoop ());
		}

		if (levelManager.pinkLevel && !Spawner.pinkWinner && levelManager.startNext && !pinkPlaying) {
			bgmAudio.loop = true;
			loop1 = pinkLoop1;
			loop2 = pinkLoop2;
			trans1 = pinkTrans1;
			trans2 = pinkTrans2;
			trans2Clip = trans2;
			hardClip = pinkHardMode;
			//Debug.Log ("Starting Pink Music Loop");
			pinkPlaying = true;
			StartCoroutine (musicLoop ());
		}

		if (levelManager.goldLevel && !Spawner.goldWinner && levelManager.startNext && !goldPlaying) {
			bgmAudio.loop = true;
			loop1 = goldLoop1;
			loop2 = goldLoop2;
			trans1 = goldTrans1;
			trans2 = goldTrans2;
			trans2Clip = trans2;
			hardClip = goldHardMode;
			//Debug.Log ("Starting Gold Music Loop");
			goldPlaying = true;
			StartCoroutine (musicLoop ());
		}

		if (levelManager.whiteLevel && !Spawner.whiteWinner && levelManager.startNext && !whitePlaying) {
			bgmAudio.loop = true;
			loop1 = whiteLoop1;
			loop2 = whiteLoop2;
			trans1 = whiteTrans1;
			trans2 = whiteTrans2;
			trans2Clip = trans2;
			hardClip = whiteHardMode;
			//Debug.Log ("Starting White Music Loop");
			whitePlaying = true;
			StartCoroutine (musicLoop ());
		}

		if (PlayerHealth.damaged == (true)) 
		{
			filter.cutoffFrequency = 15000f;
			filter.lowpassResonanceQ = 2f;
			filter2.distortionLevel = 0.15f;
			//bgmAudio.pitch = 0.97f;
		} else 
		{
			filter.cutoffFrequency = 22000f;
			filter.lowpassResonanceQ = 2f;
			filter2.distortionLevel = 0f;
			//bgmAudio.pitch = 1f;
		}


		if (PlayerHealth.isDead) 
		{
			bgmAudio.loop = false;
			StopAllCoroutines ();
			bgmAudio.Stop ();
		}

		hardText.text = ("Entering Hard Mode!");
		if (PlayerHealth.currentHealth > 50) {
			healTimeText.text = ("Move to Trade Points For Health!");
		} else {
			healTimeText.text = ("Move to Heal!");
		}

		if (levelManager.whiteLevel) {
			hardText.text = ("Fight For Your Life!");
			healTimeText.text = ("Struggle While You Still Can!");
		}

	}

	IEnumerator hardTextFlash ()
	{
		flashSpeed = 0.5f;
		flashTimes = 7;
		/*hardText.text = ("Entering Hard Mode!");
		if (PlayerHealth.currentHealth > 50) {
			healTimeText.text = ("Move to Trade Points For Health!");
		} else {
			healTimeText.text = ("Move to Heal!");
		}*/

		if (levelManager.whiteLevel) {
			flashTimes = 5;
			flashSpeed = 0.7f;
			/*hardText.text = ("Fight For Your Life!");
			healTimeText.text = ("Struggle While You Still Can!");*/
		}


		if (!hardTextShown && !ScoreManager.winnerScreen) 
		{
			while (flashTimes > 0) 
			{
				hardText.enabled = true;
				if (Spawner.healTime)
				{
					healTimeText.enabled = true;
				}
				yield return new WaitForSeconds (flashSpeed);
				flashTimes -= 1;
				//Debug.Log ("Flashes left: " + flashTimes);
				//healTimeText.enabled = false;
				hardText.enabled = false;
				yield return new WaitForSeconds (flashSpeed);
			}
		}


	}

	IEnumerator musicLoop ()
	{

		if (MusicMilestones.musicMilestone == 1) {
			musicSet = true;
			if (!loopPlaying && levelManager.startNext) 
			{
				//Debug.Log ("Playing loop 1");
				bgmAudio.clip = loop1;
				bgmAudio.Play ();
				loopPlaying = true;
			}
			//musicSet = false;
			yield return new WaitForSeconds (loop1.length);
			//Debug.Log ("Waited for " + loop1.length + "seconds, initiating loop");
			StartCoroutine (musicLoop ());
		
		}

		if (MusicMilestones.musicMilestone == 2 && !transitionPlayed && !musicSet) 
		{
			//Debug.Log ("Playing transition 1");
			musicSet = true;
			bgmAudio.clip = trans1;
			bgmAudio.Play ();
			yield return new WaitForSeconds (trans1.length);
			musicSet = false;
			transitionPlayed = true;
			loopPlaying = false;
			//Debug.Log ("Waited for " + trans1.length + "seconds, initiating loop");
			StartCoroutine (musicLoop ());
		}

		if (MusicMilestones.musicMilestone == 2 && transitionPlayed && !musicSet)
		{
			//Debug.Log ("Playing loop 2");
			musicSet = true;
			if (!loopPlaying) 
			{
				bgmAudio.clip = loop2;
				bgmAudio.Play ();
				loopPlaying = true;
			}

			yield return new WaitForSeconds (loop2.length);
			//Debug.Log ("Waited for " + loop2.length + "seconds, initiating loop");
			musicSet = false;
			StartCoroutine (musicLoop ());

		}
			

		if (MusicMilestones.musicMilestone == 3 && !musicSet && !hardPlaying)
		{
			musicSet = true;
			hardReady = true;
			hardPlaying = true;
			//Debug.Log ("Playing hard mode music " + hardReady);
			//Debug.Log ("Current level is: " + levelManager.currentLevel);
			//Debug.Log ("Have I won? " + Spawner.whiteWinner);
			//Debug.Log ("Wait time is " + Spawner.waitTime);
			bgmAudio.Stop ();
			bgmAudio.loop = false;
			bgmAudio.clip = hardClip;
			bgmAudio.Play ();
			//Debug.Log ("Signaling to start hard mode!");
			hardTextShown = false;
			StartCoroutine (hardTextFlash ());
			yield return new WaitForSeconds (hardClip.length);
			//Debug.Log ("Waited for " + hardClip.length + "seconds, stopping music");
			StopAllCoroutines ();
			hardPlaying = false;
			hardReady = false;
			loopPlaying = false;
		}
			

	}
		
	
	
}
