using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms.GameCenter;
#endif

public class Spawner : MonoBehaviour {

	public GameObject[] greyList;
	public GameObject[] greyListHard;
	public GameObject[] blueList;
	public GameObject[] blueListHard;
	public GameObject[] greenList;
	public GameObject[] greenListHard;
	public GameObject[] purpleList;
	public GameObject[] purpleListHard;
	public GameObject[] violetList;
	public GameObject[] violetListHard;
	public GameObject[] pinkList;
	public GameObject[] pinkListHard;
	public GameObject[] goldList;
	public GameObject[] goldListHard;
	public GameObject[] whiteList;
	public GameObject[] whiteListHard;
	public GameObject[] bombList;
	public GameObject[] whiteList2;
	public GameObject[] whiteList3;
	public Vector3[] spawnPositions;
	public static float waitTime;
	public static float currentTime;
	public static float spawnSpeedMultiplier;
	public static bool hardMode = false;
	public static bool greyWinner = false;
	public static bool blueWinner = false;
	public static bool greenWinner = false;
	public static bool purpleWinner = false;
	public static bool violetWinner = false;
	public static bool pinkWinner = false;
	public static bool goldWinner = false;
	public static bool whiteWinner = false;
	public bool scoreMilestoneSet;
	public static float nextMilestone;
	public bool spawnsEnded;
	public static bool cheated;
	public static float hardTime;
	public static bool spawnsStarted;
	public static float savedMilestone;
	public static float savedWaitTime;
	//public static float musicMilestone;
	public AudioClip hardWait;
	public float randomPicked;
	public bool allUsed;
	public float [] usedNumbers;
	public static bool milestoneCapped;
	public float ppsIncrease;
	public float ssmIncrease;
	public static bool healTime;
	public float timeToHard;
	public static bool speedOverride;
	public static bool speedChange;

	void Start ()
	{
		scoreMilestoneSet = false;
		speedChange = false;
		speedOverride = false;
		healTime = false;
		hardWait = BGMAudio.trans2Clip;
		milestoneCapped = false;
		//musicMilestone = 1;
		spawnsStarted = false;
		greyWinner = false;
		blueWinner = false;
		greenWinner = false;
		purpleWinner = false;
		violetWinner = false;
		pinkWinner = false;
		goldWinner = false;
		whiteWinner = false;
		spawnSpeedMultiplier = 1f;
		cheated = false;
		spawnsEnded = false;
		hardMode = false;
		waitTime = 0.9f;
		nextMilestone = 300f;
	}

	void Update (){

		hardWait = BGMAudio.trans2Clip;

		if (waitTime <= hardTime && !milestoneCapped && !Powerups.timeChanged) {
			//Debug.Log ("Capping Milestone!");
			milestoneCapped = true;
		}

		if (levelManager.greyLevel) {
			hardTime = 0.71f;
			ppsIncrease = 0.0f;
			ssmIncrease = 0.0f;
		}

		if (levelManager.blueLevel) {
			hardTime = 0.61f;
			ppsIncrease = 0.0f;
			ssmIncrease = 0.0f;
		}

		if (levelManager.greenLevel) {
			hardTime = 0.51f;
			ppsIncrease = 1f;
			ssmIncrease = 1f;
		}

		if (levelManager.purpleLevel) {
			hardTime = 0.41f;
			ppsIncrease = 1;
			ssmIncrease = 1;
		}

		if (levelManager.violetLevel) {
			hardTime = 0.41f;
			ppsIncrease = 2;
			ssmIncrease = 2;
		}

		if (levelManager.pinkLevel) {
			hardTime = 0.31f;
			ppsIncrease = 3;
			ssmIncrease = 3;
		}

		if (levelManager.goldLevel) {
			hardTime = 0.226f;
			ppsIncrease = 4;
			ssmIncrease = 4;
		}

		if (levelManager.whiteLevel) {
			hardTime = 0.161f;
			ppsIncrease = 4;
			ssmIncrease = 4;
		}

		if (ScoreManager.currentScore >= nextMilestone && !hardMode && spawnsStarted && !milestoneCapped && !Powerups.timeChanged) {
			Debug.Log ("Setting new Milestone!");
			scoreMilestoneSet = false;
			setMilestone ();
		}
			
		if (levelManager.greyLevel && levelManager.startNext && !spawnsStarted)
		{
			Debug.Log ("Starting grey spawns! Wait time is: " + waitTime);
			spawnsStarted = true;
			StartCoroutine (greySpawns ());
		}


		if (levelManager.blueLevel && levelManager.startNext && !spawnsStarted) {
			//Debug.Log ("Starting blue spawns! Wait time is: " + waitTime);
			spawnsStarted = true;
			StartCoroutine (blueSpawns ());
		}

		if (levelManager.greenLevel && levelManager.startNext && !spawnsStarted) {
			//Debug.Log ("Starting green spawns! Wait time is: " + waitTime);
			spawnsStarted = true;
			StartCoroutine (greenSpawns ());
		}

		if (levelManager.purpleLevel && levelManager.startNext && !spawnsStarted) {
			//Debug.Log ("Starting purple spawns! Wait time is: " + waitTime);
			spawnsStarted = true;
			StartCoroutine (purpleSpawns ());
		}

		if (levelManager.violetLevel && levelManager.startNext && !spawnsStarted) {
			//Debug.Log ("Starting violet spawns! Wait time is: " + waitTime);
			spawnsStarted = true;
			StartCoroutine (violetSpawns ());
		}

		if (levelManager.pinkLevel && levelManager.startNext && !spawnsStarted) {
			//Debug.Log ("Starting pink spawns! Wait time is: " + waitTime);
			spawnsStarted = true;
			StartCoroutine (pinkSpawns ());
		}

		if (levelManager.goldLevel && levelManager.startNext && !spawnsStarted) {
			//Debug.Log ("Starting gold spawns! Wait time is: " + waitTime);
			spawnsStarted = true;
			StartCoroutine (goldSpawns ());
		}

		if (levelManager.whiteLevel && levelManager.startNext && !spawnsStarted) {
			//Debug.Log ("Starting white spawns! Wait time is: " + waitTime);
			spawnsStarted = true;
			StartCoroutine (whiteSpawns ());
		}


	}

	public void increaseDifficulty ()
	{

		if (levelManager.greyLevel || levelManager.blueLevel || levelManager.greenLevel || levelManager.purpleLevel) {
			waitTime = waitTime - 0.1f;
			currentTime = currentTime - 0.1f;
		}

		if (levelManager.violetLevel || levelManager.pinkLevel) {
			waitTime = waitTime - 0.05f;
			currentTime = currentTime - 0.5f;
		}

		if (levelManager.goldLevel) {
			waitTime = waitTime - 0.025f;
			currentTime = currentTime - 0.025f;
		}
		if (levelManager.whiteLevel) {
			waitTime = waitTime - 0.02f;
			currentTime = currentTime - 0.02f;
			speedChange = true;
			FallingScript.regSpeed += 0.02f;
		}
		ScoreManager.pointsPerSecond = ScoreManager.pointsPerSecond + ppsIncrease;
		spawnSpeedMultiplier = spawnSpeedMultiplier + ssmIncrease;
		Debug.Log ("Milestone of " + nextMilestone + "reached! Decreasing waitTime to " + waitTime);
		Debug.Log ("Fall speed is now: " + FallingScript.regSpeed);
	}


	public void setMilestone ()
	{
		if (ScoreManager.currentScore >= nextMilestone && !scoreMilestoneSet && spawnsStarted)
		{
			increaseDifficulty ();
			nextMilestone = Mathf.Round ((nextMilestone * 1.5f) + (100f));
			Debug.Log ("New milestone set to: " + nextMilestone);
			scoreMilestoneSet = (true);	
		}

	}

	IEnumerator startHeals ()
	{
		Debug.Log ("Starting Heal Time");
		ScoreManager.originalScore = ScoreManager.currentScore;
		yield return new WaitForSeconds (1.5f);
		healTime = true;
		yield return new WaitForSeconds (hardWait.length - 2f);
		healTime = false;
		StopCoroutine (startHeals ());
	}

	IEnumerator greySpawns ()
	{
		yield return new WaitForSeconds (waitTime);
		if (!PlayerHealth.isDead && !spawnsEnded && levelManager.greyLevel && spawnsStarted) {
			spawnGrey ();
		}
			

		if (waitTime <= hardTime && levelManager.greyLevel && !greyWinner && BGMAudio.hardReady) {
			ScoreManager.ppsIncreasing = false;
			StartCoroutine (startHeals());
			yield return new WaitForSeconds (hardWait.length);
			if (!hardMode) 
			{
				hardMode = true;
				StartCoroutine (spawnGreyHard ());
			}

			//StopCoroutine (startHeals());
			//StopAllCoroutines ();
			Debug.Log ("Entering Grey Hard Mode!");

		} else {
			if (PlayerHealth.isDead == (true)) {
				StopCoroutine (greySpawns ());
			} else {
				StartCoroutine (greySpawns ());
			}
		}

	}

	public void spawnGrey()
	{
		transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
		int g = Random.Range (0, greyList.Length);

		Instantiate (greyList [g],
			transform.position,
			Quaternion.identity);
	}




	public void greyHard()
	{

		if (Powerups.murderOnly) {
			int bo = Random.Range (0, bombList.Length);
			transform.position = spawnPositions [0];
			Instantiate (bombList [bo],
				transform.position,
				Quaternion.identity);
		}


		if (!Powerups.murderOnly) 
		{
			int gh = Random.Range (0, greyListHard.Length);
			transform.position = spawnPositions [0];
			Instantiate (greyListHard [gh],
				transform.position,
				Quaternion.identity);
		}

	}



	IEnumerator spawnGreyHard()
	{
		greyHard ();
		yield return new WaitForSeconds (waitTime); 
		if (PlayerHealth.isDead == (true) || !levelManager.greyLevel || !spawnsStarted) {
			StopCoroutine (spawnGreyHard ());
		} else {
			StartCoroutine (spawnGreyHard ());
		}

		if (hardMode == (true) && levelManager.greyLevel && !greyWinner) {
			waitTime = 0.7f;
			yield return new WaitForSeconds (22);
			waitTime = 0.685f;
			yield return new WaitForSeconds (15);
			waitTime = 0.65f;
			yield return new WaitForSeconds (10);
			StopAllCoroutines();
			if (!PlayerHealth.isDead && levelManager.greyLevel)
			{
				Debug.Log ("Winner Winner Grey Chicken Dinner!");
				levelManager.firstWon = 1;
				FileBasedPrefs.SetFloat ("First Won", levelManager.firstWon);
				//musicMilestone = 1;
				MusicMilestones.musicMilestone = 1;
				//hardMode = false;
				spawnsStarted = false;
				greyWinner = true;
				levelManager.startNext = false;
				levelManager.levelSet = false;
				Debug.Log ("Stopping spawns!  " + spawnsStarted);
				Social.ReportProgress (LeaderboardManager.achiev1, 100, (bool success) => {
				});
			}
		}
			

	}

	IEnumerator blueSpawns ()
	{
		yield return new WaitForSeconds (waitTime);
		if (!PlayerHealth.isDead && !spawnsEnded && levelManager.blueLevel && spawnsStarted) {
			spawnBlue ();
		}


		if (waitTime <= hardTime && levelManager.blueLevel && !blueWinner && BGMAudio.hardReady) {
			ScoreManager.ppsIncreasing = false;
			StartCoroutine (startHeals());
			yield return new WaitForSeconds (hardWait.length);
			StopCoroutine (startHeals());
			StopAllCoroutines ();
			Debug.Log ("Entering Blue Hard Mode!");
			hardMode = true;
			StartCoroutine (spawnBlueHard ());
		} else {
			if (PlayerHealth.isDead == (true)) {
				StopCoroutine (blueSpawns ());
			} else {
				StartCoroutine (blueSpawns ());
			}
		}

	}

	public void spawnBlue()
	{
		transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
		int b = Random.Range (0, blueList.Length);

		Instantiate (blueList [b],
			transform.position,
			Quaternion.identity);
	}




	public void blueHard()
	{
		if (Powerups.murderOnly) {
			int bo = Random.Range (0, bombList.Length);
			transform.position = spawnPositions [0];
			Instantiate (bombList [bo],
				transform.position,
				Quaternion.identity);
		}

		if (!Powerups.murderOnly) {
			int bh = Random.Range (0, blueListHard.Length);
			transform.position = spawnPositions [0];
			Instantiate (blueListHard [bh],
				transform.position,
				Quaternion.identity);
		}

	}



	IEnumerator spawnBlueHard()
	{
		blueHard ();
		yield return new WaitForSeconds (waitTime); 
		if (PlayerHealth.isDead == (true) || !levelManager.blueLevel || !spawnsStarted) {
			StopCoroutine (spawnBlueHard ());
		} else {
			StartCoroutine (spawnBlueHard ());
		}

		if (hardMode == (true) && levelManager.blueLevel && !blueWinner) {
			waitTime = 0.6f;
			yield return new WaitForSeconds (30);
			waitTime = 0.575f;
			yield return new WaitForSeconds (15);
			waitTime = 0.50f;
			yield return new WaitForSeconds (10);
			StopAllCoroutines();
			if (!PlayerHealth.isDead && levelManager.blueLevel)
			{
				Debug.Log ("Winner Winner Blue Chicken Dinner!");
				levelManager.secondWon = 1;
				FileBasedPrefs.SetFloat ("Second Won", levelManager.secondWon);
				//musicMilestone = 1;
				MusicMilestones.musicMilestone = 1;
				//hardMode = false;
				spawnsStarted = false;
				levelManager.startNext = false;
				blueWinner = true;
				levelManager.levelSet = false;
				Debug.Log ("Stopping spawns!  " + spawnsStarted);
				Social.ReportProgress (LeaderboardManager.achiev2, 100, (bool success) => {
				});
			}
		}


	}

	IEnumerator greenSpawns ()
	{
		yield return new WaitForSeconds (waitTime);
		if (!PlayerHealth.isDead && !spawnsEnded && levelManager.greenLevel && spawnsStarted) {
			spawnGreen ();
		}


		if (waitTime <= hardTime && levelManager.greenLevel && !greenWinner && BGMAudio.hardReady) {
			ScoreManager.ppsIncreasing = false;
			StartCoroutine (startHeals());
			yield return new WaitForSeconds (hardWait.length);
			StopCoroutine (startHeals());
			StopAllCoroutines ();
			Debug.Log ("Entering Green Hard Mode!");
			hardMode = true;
			StartCoroutine (spawnGreenHard ());
		} else {
			if (PlayerHealth.isDead == (true)) {
				StopCoroutine (greenSpawns ());
			} else {
				StartCoroutine (greenSpawns ());
			}
		}

	}

	public void spawnGreen()
	{
		transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
		int g = Random.Range (0, greenList.Length);

		Instantiate (greenList [g],
			transform.position,
			Quaternion.identity);
	}




	public void greenHard()
	{

		if (Powerups.murderOnly) {
			int bo = Random.Range (0, bombList.Length);
			transform.position = spawnPositions [0];
			Instantiate (bombList [bo],
				transform.position,
				Quaternion.identity);
		}

		if (!Powerups.murderOnly) {
			int gh = Random.Range (0, greenListHard.Length);
			transform.position = spawnPositions [0];
			Instantiate (greenListHard [gh],
				transform.position,
				Quaternion.identity);
		}

	}



	IEnumerator spawnGreenHard()
	{
		greenHard ();
		yield return new WaitForSeconds (waitTime); 
		if (PlayerHealth.isDead == (true) || !levelManager.greenLevel || !spawnsStarted) {
			StopCoroutine (spawnGreenHard ());
		} else {
			StartCoroutine (spawnGreenHard ());
		}

		if (hardMode == (true) && levelManager.greenLevel && !greenWinner) {
			waitTime = 0.500f;
			yield return new WaitForSeconds (30);
			waitTime = 0.485f;
			yield return new WaitForSeconds (15);
			waitTime = 0.450f;
			yield return new WaitForSeconds (10);
			StopAllCoroutines();
			if (!PlayerHealth.isDead && levelManager.greenLevel)
			{
				Debug.Log ("Winner Winner Green Chicken Dinner!");
				levelManager.thirdWon = 1;
				FileBasedPrefs.SetFloat ("Third Won", levelManager.thirdWon);
				//musicMilestone = 1;
				MusicMilestones.musicMilestone = 1;
				//hardMode = false;
				spawnsStarted = false;
				levelManager.startNext = false;
				greenWinner = true;
				levelManager.levelSet = false;
				//Debug.Log ("Stopping spawns!  " + spawnsStarted);
				Social.ReportProgress (LeaderboardManager.achiev3, 100, (bool success) => {
				});
			}
		}


	}
		

	IEnumerator purpleSpawns ()
	{
		yield return new WaitForSeconds (waitTime);
		if (!PlayerHealth.isDead && !spawnsEnded && levelManager.purpleLevel && spawnsStarted) {
			spawnPurple ();
		}


		if (waitTime <= hardTime && levelManager.purpleLevel && !purpleWinner && BGMAudio.hardReady) {
			ScoreManager.ppsIncreasing = false;
			StartCoroutine (startHeals());
			yield return new WaitForSeconds (hardWait.length);
			StopCoroutine (startHeals());
			StopAllCoroutines ();
			Debug.Log ("Entering Purple Hard Mode!");
			hardMode = true;
			StartCoroutine (spawnPurpleHard ());
			StartCoroutine (purpleHardDifficulty ());
			//StartCoroutine (spawnPurpleHard ());
		} else {
			if (PlayerHealth.isDead == (true)) {
				StopCoroutine (purpleSpawns ());
			} else {
				StartCoroutine (purpleSpawns ());
			}
		}

	}


	public void spawnPurple()
	{
		transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
		int p = Random.Range (0, purpleList.Length);
		int w2 = Random.Range (0, whiteList2.Length);

		if (p == 0) {
			Instantiate (whiteList2 [w2],
				transform.position,
				Quaternion.identity);
		} else {

			Instantiate (purpleList [p],
				transform.position = spawnPositions [0],
				Quaternion.identity);
		}
	}




	public void purpleHard()
	{

		if (Powerups.murderOnly) {
			int bo = Random.Range (0, bombList.Length);
			transform.position = spawnPositions [0];
			Instantiate (bombList [bo],
				transform.position,
				Quaternion.identity);
		}

		if (!Powerups.murderOnly) {
			int ph = Random.Range (0, purpleListHard.Length);
			transform.position = spawnPositions [0];
			int w3 = Random.Range (0, whiteList3.Length);

			if (ph == 0) {
				transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
				Instantiate (whiteList3 [w3],
					transform.position,
					Quaternion.identity);
			}
			Instantiate (purpleListHard [ph],
				transform.position,
				Quaternion.identity);
		}

	}



	IEnumerator spawnPurpleHard()
	{
		purpleHard ();
		yield return new WaitForSeconds (waitTime); 
		if (PlayerHealth.isDead == (true) || !levelManager.purpleLevel || !spawnsStarted) {
			StopCoroutine (spawnPurpleHard ());
		} else {
			StartCoroutine (spawnPurpleHard ());
		}
	}

	IEnumerator purpleHardDifficulty () {

		if (hardMode == (true) && levelManager.purpleLevel && !purpleWinner) {
			speedOverride = true;
			FallingScript.hardSpeed = 0.185f;
			waitTime = 0.400f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.195f;
			waitTime = 0.365f;
			yield return new WaitForSeconds (10);
			FallingScript.hardSpeed = 0.2f;
			waitTime = 0.345f;
			yield return new WaitForSeconds (10);
			FallingScript.hardSpeed = 0.225f;
			waitTime = 0.330f;
			yield return new WaitForSeconds (10);
			StopAllCoroutines ();
			if (!PlayerHealth.isDead && levelManager.purpleLevel) {
				Debug.Log ("Winner Winner Purple Chicken Dinner!");
				speedOverride = false;
				levelManager.fourthWon = 1;
				FileBasedPrefs.SetFloat ("Fourth Won", levelManager.fourthWon);
				//musicMilestone = 1;
				MusicMilestones.musicMilestone = 1;
				//hardMode = false;
				levelManager.startNext = false;
				spawnsStarted = false;
				purpleWinner = true;
				levelManager.levelSet = false;
				Debug.Log ("Stopping spawns!  " + spawnsStarted);
				Social.ReportProgress (LeaderboardManager.achiev4, 100, (bool success) => {
				});
			}
		}
	}




	IEnumerator violetSpawns ()
	{
		yield return new WaitForSeconds (waitTime);
		if (!PlayerHealth.isDead && !spawnsEnded && levelManager.violetLevel && spawnsStarted) {
			spawnViolet ();
		}


		if (waitTime <= hardTime && levelManager.violetLevel && !violetWinner && BGMAudio.hardReady) {
			ScoreManager.ppsIncreasing = false;
			StartCoroutine (startHeals());
			yield return new WaitForSeconds (hardWait.length);
			StopCoroutine (startHeals());
			StopAllCoroutines ();
			Debug.Log ("Entering Violet Hard Mode!");
			hardMode = true;
			StartCoroutine (spawnVioletDifficulty ());
			StartCoroutine (spawnVioletHard ());
		} else {
			if (PlayerHealth.isDead == (true)) {
				StopCoroutine (violetSpawns ());
			} else {
				StartCoroutine (violetSpawns ());
			}
		}

	}


	public void spawnViolet()
	{
		transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
		int v = Random.Range (0, violetList.Length);
		int w2 = Random.Range (0, whiteList2.Length);

		if (v == 0) {
			Instantiate (whiteList2 [w2],
				transform.position,
				Quaternion.identity);
		} else {
			Instantiate (violetList [v],
				transform.position = spawnPositions [0],
				Quaternion.identity);
		}
	}




	public void violetHard()
	{
		
		if (Powerups.murderOnly) {
			int bo = Random.Range (0, bombList.Length);
			transform.position = spawnPositions [0];
			Instantiate (bombList [bo],
				transform.position,
				Quaternion.identity);
		}

		if (!Powerups.murderOnly) {
			int vh = Random.Range (0, violetListHard.Length);
			transform.position = spawnPositions [0];
			int w3 = Random.Range (0, whiteList3.Length);

			if (vh == 0) {
				transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
				Instantiate (whiteList3 [w3],
					transform.position,
					Quaternion.identity);
			}
			Instantiate (violetListHard [vh],
				transform.position,
				Quaternion.identity);
		}

	}



	IEnumerator spawnVioletHard()
	{
		violetHard ();
		yield return new WaitForSeconds (waitTime); 
		if (PlayerHealth.isDead == (true) || !levelManager.violetLevel || !spawnsStarted) {
			StopCoroutine (spawnVioletHard ());
		} else {
			StartCoroutine (spawnVioletHard ());
		}
	}

	IEnumerator spawnVioletDifficulty ()
	{

		if (hardMode == (true) && levelManager.violetLevel && !violetWinner) {
			speedOverride = true;
			FallingScript.hardSpeed = 0.215f;
			waitTime = 0.385f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.225f;
			waitTime = 0.35f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.23f;
			waitTime = 0.325f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.235f;
			waitTime = 0.3f;
			yield return new WaitForSeconds (10);
			StopAllCoroutines();
			if (!PlayerHealth.isDead && levelManager.violetLevel)
			{
				speedOverride = false;
				Debug.Log ("Winner Winner Violet Chicken Dinner!");
				levelManager.fifthWon = 1;
				FileBasedPrefs.SetFloat ("Fifth Won", levelManager.fifthWon);
				//musicMilestone = 1;
				MusicMilestones.musicMilestone = 1;
				//hardMode = false;
				levelManager.startNext = false;
				spawnsStarted = false;
				violetWinner = true;
				levelManager.levelSet = false;
				Debug.Log ("Stopping spawns!  " + spawnsStarted);
				Social.ReportProgress (LeaderboardManager.achiev5, 100, (bool success) => {
				});
			}
		}


	}


	IEnumerator pinkSpawns ()
	{
		yield return new WaitForSeconds (waitTime);
		if (!PlayerHealth.isDead && !spawnsEnded && levelManager.pinkLevel && spawnsStarted) {
			spawnPink ();
		}


		if (waitTime <= hardTime && levelManager.pinkLevel && !pinkWinner && BGMAudio.hardReady) {
			ScoreManager.ppsIncreasing = false;
			StartCoroutine (startHeals());;
			yield return new WaitForSeconds (hardWait.length);
			StopCoroutine (startHeals());
			StopAllCoroutines ();
			Debug.Log ("Entering Pink Hard Mode!");
			hardMode = true;
			StartCoroutine (spawnPinkDifficulty());
			StartCoroutine (spawnPinkHard ());
		} else {
			if (PlayerHealth.isDead == (true)) {
				StopCoroutine (pinkSpawns ());
			} else {
				StartCoroutine (pinkSpawns ());
			}
		}

	}


	public void spawnPink()
	{
		transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
		int pi = Random.Range (0, pinkList.Length);
		int w2 = Random.Range (0, whiteList2.Length);

		if (pi == 0) {
			Instantiate (whiteList2 [w2],
				transform.position,
				Quaternion.identity);
		} else
		{
		Instantiate (pinkList [pi],
			transform.position = spawnPositions [0],
			Quaternion.identity);
		}
	}




	public void pinkHard()
	{

		if (Powerups.murderOnly) {
			int bo = Random.Range (0, bombList.Length);
			transform.position = spawnPositions [0];
			Instantiate (bombList [bo],
				transform.position,
				Quaternion.identity);
		}

		if (!Powerups.murderOnly) {
			int pih = Random.Range (0, pinkListHard.Length);
			transform.position = spawnPositions [0];
			int w3 = Random.Range (0, whiteList3.Length);

			if (pih == 0) {
				transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
				Instantiate (whiteList3 [w3],
					transform.position,
					Quaternion.identity);
			}
			Instantiate (pinkListHard [pih],
				transform.position,
				Quaternion.identity);
		}

	}



	IEnumerator spawnPinkHard()
	{
		pinkHard ();
		yield return new WaitForSeconds (waitTime); 
		if (PlayerHealth.isDead == (true) || !levelManager.pinkLevel || !spawnsStarted) {
			StopCoroutine (spawnPinkHard ());
		} else {
			StartCoroutine (spawnPinkHard ());
		}
	}

	IEnumerator spawnPinkDifficulty ()
	{

		if (hardMode == (true) && levelManager.pinkLevel && !pinkWinner) {
			speedOverride = true;
			FallingScript.hardSpeed = 0.225f;
			waitTime = 0.290f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.23f;
			waitTime = 0.260f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.235f;
			waitTime = 0.240f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.245f;
			waitTime = 0.220f;
			yield return new WaitForSeconds (10);
			StopAllCoroutines ();
			if (!PlayerHealth.isDead && levelManager.pinkLevel) {
				speedOverride = false;
				Debug.Log ("Winner Winner Pink Chicken Dinner!");
				levelManager.sixthWon = 1;
				FileBasedPrefs.SetFloat ("Sixth Won", levelManager.sixthWon);
				//musicMilestone = 1;
				MusicMilestones.musicMilestone = 1;
				//hardMode = false;
				levelManager.startNext = false;
				spawnsStarted = false;
				pinkWinner = true;
				levelManager.levelSet = false;
				Debug.Log ("Stopping spawns!  " + spawnsStarted);
				Social.ReportProgress (LeaderboardManager.achiev6, 100, (bool success) => {
				});
			}
		}
	}




	IEnumerator goldSpawns ()
	{
		yield return new WaitForSeconds (waitTime);
		if (!PlayerHealth.isDead && !spawnsEnded && levelManager.goldLevel && spawnsStarted) {
			spawnGold ();
		}


		if (waitTime <= hardTime && levelManager.goldLevel && !goldWinner && BGMAudio.hardReady) {
			ScoreManager.ppsIncreasing = false;
			StartCoroutine (startHeals());
			yield return new WaitForSeconds (hardWait.length);
			StopCoroutine (startHeals());
			StopAllCoroutines ();
			Debug.Log ("Entering Gold Hard Mode!");
			hardMode = true;
			StartCoroutine (spawnGoldDifficulty ());
			StartCoroutine (spawnGoldHard ());
		} else {
			if (PlayerHealth.isDead == (true)) {
				StopCoroutine (goldSpawns ());
			} else {
				StartCoroutine (goldSpawns ());
			}
		}

	}


	public void spawnGold ()
	{
		transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
		int g = Random.Range (0, goldList.Length);
		int w2 = Random.Range (0, whiteList2.Length);

		if (g == 0) {
			Instantiate (whiteList2 [w2],
				transform.position,
				Quaternion.identity);

		} else {
			Instantiate (goldList [g],
				transform.position = spawnPositions [0],
				Quaternion.identity);
		}
	}




	public void goldHard()
	{
		if (Powerups.murderOnly) {
			int bo = Random.Range (0, bombList.Length);
			transform.position = spawnPositions [0];
			Instantiate (bombList [bo],
				transform.position,
				Quaternion.identity);
		}

		if (!Powerups.murderOnly) {
			int gh = Random.Range (0, goldListHard.Length);
			transform.position = spawnPositions [0];
			int w3 = Random.Range (0, whiteList3.Length);

			if (gh == 0) {
				transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
				Instantiate (whiteList3 [w3],
					transform.position,
					Quaternion.identity);
			} else {
				Instantiate (goldListHard [gh],
					transform.position,
					Quaternion.identity);
			}
		}

	}



	IEnumerator spawnGoldHard()
	{
		goldHard ();
		yield return new WaitForSeconds (waitTime); 
		if (PlayerHealth.isDead == (true) || !levelManager.goldLevel || !spawnsStarted) {
			StopCoroutine (spawnGoldHard ());
		} else {
			StartCoroutine (spawnGoldHard ());
		}
	}

	IEnumerator spawnGoldDifficulty ()
	{

		if (hardMode == (true) && levelManager.goldLevel && !goldWinner) {
			speedOverride = true;
			FallingScript.hardSpeed = 0.225f;
			waitTime = 0.235f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.235f;
			waitTime = 0.225f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.245f;
			waitTime = 0.215f;
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.25f;
			waitTime = 0.200f;
			yield return new WaitForSeconds (12);
			StopAllCoroutines ();
			if (!PlayerHealth.isDead && levelManager.goldLevel) {
				Debug.Log ("Winner Winner Gold Chicken Dinner!");
				speedOverride = false;
				levelManager.seventhWon = 1;
				FileBasedPrefs.SetFloat ("Seventh Won", levelManager.seventhWon);
				//musicMilestone = 1;
				MusicMilestones.musicMilestone = 1;
				//hardMode = false;
				levelManager.startNext = false;
				spawnsStarted = false;
				goldWinner = true;
				levelManager.levelSet = false;
				Debug.Log ("Stopping spawns!  " + spawnsStarted);
				Social.ReportProgress (LeaderboardManager.achiev7, 100, (bool success) => {
				});
			}
		}
	}


	IEnumerator whiteSpawns ()
	{
		yield return new WaitForSeconds (waitTime);
		if (!PlayerHealth.isDead && !spawnsEnded && levelManager.whiteLevel && spawnsStarted) {
			spawnWhite ();
		}


		if (waitTime <= hardTime && levelManager.whiteLevel && !whiteWinner && BGMAudio.hardReady) {
			Debug.Log ("Initiating Heal Time");
			ScoreManager.ppsIncreasing = false;
			StartCoroutine (startHeals());
			yield return new WaitForSeconds (hardWait.length);
			StopCoroutine (startHeals());
			StopAllCoroutines ();
			Debug.Log ("Entering White Hard Mode!");
			hardMode = true;
			StartCoroutine (spawnWhiteHard ());
			StartCoroutine (whiteHardDifficulty ());
		} else {
			if (PlayerHealth.isDead == (true)) {
				StopCoroutine (whiteSpawns ());
			} else {
				StartCoroutine (whiteSpawns ());
			}
		}

	}


	public void spawnWhite()
	{
		
		transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
		int w = Random.Range (0, whiteList.Length);
		int w2 = Random.Range (0, whiteList2.Length);
			

		if (w == 0) {
			//Debug.Log (2);
			//transform.position = spawnPositions [wr];
			Instantiate (whiteList2 [w2],
				transform.position,
				Quaternion.identity);
		} else {
			//Debug.Log (1);
			Instantiate (whiteList [w],
				transform.position = spawnPositions [0],
				Quaternion.identity);
		}
	}




	public void whiteHard()
	{
		if (Powerups.murderOnly) {
			int bo = Random.Range (0, bombList.Length);
			transform.position = spawnPositions [0];
			Instantiate (bombList [bo],
				transform.position,
				Quaternion.identity);
		}

		if (!Powerups.murderOnly) {
			int wh = Random.Range (0, whiteListHard.Length);
			transform.position = spawnPositions [0];
			int w3 = Random.Range (0, whiteList3.Length);

			if (wh == 0) {
				transform.position = spawnPositions [Random.Range (0, spawnPositions.Length)];
				Instantiate (whiteList3 [w3],
					transform.position,
					Quaternion.identity);
			} else {
				Instantiate (whiteListHard [wh],
					transform.position,
					Quaternion.identity);
			}
		}


	}



	IEnumerator spawnWhiteHard()
	{
		whiteHard ();
		yield return new WaitForSeconds (waitTime); 
		if (PlayerHealth.isDead == (true) || !levelManager.whiteLevel || !spawnsStarted) {
			StopCoroutine (spawnWhiteHard ());
		} else {
			StartCoroutine (spawnWhiteHard ());
		}
	}

	IEnumerator whiteHardDifficulty ()
	{

		if (hardMode == (true) && levelManager.whiteLevel && !whiteWinner) {
			speedOverride = true;
			FallingScript.hardSpeed = 0.25f;
			waitTime = 0.2f;
			Debug.Log ("" + waitTime + FallingScript.hardSpeed);
			yield return new WaitForSeconds (30);
			FallingScript.hardSpeed = 0.255f;
			waitTime = 0.195f;
			Debug.Log ("" + waitTime + FallingScript.hardSpeed);
			yield return new WaitForSeconds (30);
			FallingScript.hardSpeed = 0.2575f;
			waitTime = 0.1875f;
			Debug.Log ("" + waitTime + FallingScript.hardSpeed);
			yield return new WaitForSeconds (15);
			FallingScript.hardSpeed = 0.26f;
			waitTime = 0.185f;
			Debug.Log ("" + waitTime + FallingScript.hardSpeed);
			yield return new WaitForSeconds (10);
			StopAllCoroutines();
			if (!PlayerHealth.isDead && levelManager.whiteLevel)
			{
				Debug.Log ("Winner Winner White Chicken Dinner!");

				speedOverride = false;
				levelManager.gameWon = 1;
				FileBasedPrefs.SetFloat ("Game Won", levelManager.gameWon);
				//musicMilestone = 1;
				MusicMilestones.musicMilestone = 1;
				//hardMode = false;
				levelManager.startNext = false;
				spawnsStarted = false;
				whiteWinner = true;
				levelManager.levelSet = false;
				Debug.Log ("Stopping spawns!  " + spawnsStarted);
				Social.ReportProgress (LeaderboardManager.achiev8, 100, (bool success) => {
				});

			}
		}


	}
		
}
	