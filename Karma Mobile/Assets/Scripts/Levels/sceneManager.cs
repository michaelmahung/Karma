using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;
using System;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms.GameCenter;
#endif
using UnityEngine.SocialPlatforms;
using GooglePlayGames;


public class sceneManager : MonoBehaviour {

    public GameObject outlines;
	public GameObject restartButton;
	public GameObject menuButton;
	public GameObject nextLevelButton;
	public Text deathText;
	public AudioClip spendToken;
	public GameObject saveButton;
	public GameObject continueButton;
	public GameObject sendScoresButton;
	private MonoBehaviour playerMovement;
	private MonoBehaviour arrowKeyMovement;
	public static float cpn;
	public static bool cpnDeducted;	
	public Text cpnText;
	public Text levelText;
	public static bool cookieAdded;
	public GameObject cookieAddedButton;	
	public static float heartsLeft;
	public bool gameOver;
	public GameObject buyLifeButton;
	public GameObject watchAdButton;
	public static bool lifeButtonPressed;
	public static bool adWatched;
	public Text startNextLevel1;
	public Text startNextLevel2;
	public AudioClip levelStartSound;
	public AudioSource menuSounds;
	public bool levelTextShown;
	public static Int64 sentScore;
	public static Int64 totalGameTime;
	public static Int64 totalDeaths;
	public static bool scoresSent;

	void Awake ()
	{
		//PlayGamesPlatform.Activate ();
		//Social.localUser.Authenticate;
		menuSounds = GetComponent <AudioSource> ();
		scoresSent = false;
		levelTextShown = false;
		startNextLevel1.enabled = false;
		startNextLevel2.enabled = false;
		Advertisement.Initialize (1665283.ToString(),true);
		adWatched = false;
		watchAdButton.SetActive (false);
		lifeButtonPressed = false;
		cookieAdded = false;
		levelText.enabled = false;
		cpnDeducted = false;
		if (FileBasedPrefs.HasKey ("CPN"))
			{
			cpn = FileBasedPrefs.GetFloat ("CPN");
		} else {cpn = 2000f;}

		if (FileBasedPrefs.HasKey ("Continues")) 
		{
			heartsLeft = FileBasedPrefs.GetFloat ("Continues");
		}

		if (!FileBasedPrefs.HasKey ("Continues")) 
		{
			heartsLeft = 3;
		}

		//saveButton = GameObject.Find ("Save Button");
		//nextLevelButton = GameObject.Find ("Next Level");
		//menuButton = GameObject.Find ("Menu Button");
		//restartButton = GameObject.Find ("Restart Button");
		//continueButton = GameObject.Find ("Continue Button");
		cpnText.enabled = false;
		//totalCPText.enabled = false;
		continueButton.SetActive (false);
		saveButton.SetActive (false);
		nextLevelButton.SetActive (false);
		menuButton.SetActive (false);
		restartButton.SetActive (false);
		arrowKeyMovement = GetComponent<ArrowKeyMovement> ();
		playerMovement = GetComponent<PlayerMovement> ();
		cookieAddedButton.SetActive (false);
	}
		
	public void RestartGame ()
	{
		ScoreManager.winnerScreen = false;
		FileBasedPrefs.DeleteKey ("Continues");
		FileBasedPrefs.DeleteKey ("CPN");
		FileBasedPrefs.DeleteKey ("Total Score");
		FileBasedPrefs.DeleteKey ("Total Cookie");
		if (levelManager.currentLevel >= 5) 
		{
			levelManager.currentLevel = 5;
			FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
		}

		if (levelManager.currentLevel <= 4) 
		{
			FileBasedPrefs.DeleteKey ("Current Level");
		}
		SceneManager.LoadScene ("Game");
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		if (!BGMAudio.bgmAudio.isPlaying) 
		{
			BGMAudio.bgmAudio.Play ();
		}
	}


	void Update ()
	{
		if (ArrowKeyMovement.paused) {
			menuSounds.Pause ();
		} else {menuSounds.UnPause ();
		}
		if (lifeButtonPressed) 
		{
			cpnText.text = "Next Life = " + cpn + " BP";
		}else {cpnText.text = "Life Costs " + cpn + " BP"; }

		//continueText.text = "Continues Left: " + heartsLeft;

		if (ScoreManager.totalCookie <= cpn) {
			cpnText.text = (cpn - ScoreManager.totalCookie) + " More Points Needed";
		}
		//totalCPText.text = "Total Cookie Points: " + ScoreManager.totalCookie;

		if (PlayerHealth.isDead && heartsLeft == 0) 
		{
			//restartButton.SetActive (true);
			//menuButton.SetActive (true);
		}

		if (ScoreManager.winnerScreen && !ScoreManager.gameWinner) 
		{
			levelText.enabled = true;
			nextLevelButton.SetActive (true);
			saveButton.SetActive (true);
		} else 
		{
		nextLevelButton.SetActive (false);
		saveButton.SetActive (false);
		levelText.enabled = false;
		}

		if (cookieAdded && !scoresSent) {
			sendScoresButton.SetActive (true);	
			nextLevelButton.SetActive (false);
		} else {
			sendScoresButton.SetActive (false);
		}

		if (ScoreManager.winnerScreen && ScoreManager.gameWinner) 
		{
			menuButton.SetActive (true);
			sendScoresButton.SetActive (true);
			cpnText.enabled = false;
			levelText.enabled = true;
			levelText.text = "Final Score is: " + Mathf.Round (ScoreManager.totalScore);
		}

		if (PlayerHealth.isDead && heartsLeft > 0) {
			cpnDeducted = false;
			menuButton.SetActive (true);
			continueButton.SetActive (true);
			cookieAddedButton.SetActive (false);
			//restartButton.SetActive (true);
			cpnText.enabled = true;
			//totalCPText.enabled = true;
		} 

		if (PlayerHealth.isDead && heartsLeft <= 0) {
			cpnDeducted = false;
			//continueButton.SetActive (true);
			//restartButton.SetActive (true);
			cpnText.enabled = true;
			//totalCPText.enabled = true;
		} 

		if (PlayerHealth.isDead && cookieAdded) {
			cpnText.enabled = false;
			menuButton.SetActive (true);
			//continueButton.SetActive (false);
			restartButton.SetActive (true);
		}

		if (PlayerHealth.isDead && scoresSent || cookieAdded) {
			buyLifeButton.SetActive (false);
		}

		if (PlayerHealth.isDead && !cookieAdded && heartsLeft <= 0) {
			cookieAddedButton.SetActive (true);
		}

		if (!PlayerHealth.isDead && !Spawner.whiteWinner) 
		{
			continueButton.SetActive (false);
			restartButton.SetActive (false);
			menuButton.SetActive (false);
			cpnText.enabled = false;
			//totalCPText.enabled = false;
		}

		if (!adWatched && heartsLeft <= 2.5f && heartsLeft >= 0 && PlayerHealth.isDead && !cookieAdded) 
		{
			watchAdButton.SetActive (true);
		}

		if (PlayerHealth.isDead && !cookieAdded &&  ScoreManager.totalCookie >= cpn && heartsLeft <= 3) 
		{
			buyLifeButton.SetActive (true);
		}

		if (ScoreManager.winnerScreen && !cookieAdded && ScoreManager.totalCookie >= cpn && heartsLeft <= 3)
		{
			buyLifeButton.SetActive (true);
		}

		if (ScoreManager.totalCookie <= cpn || heartsLeft >= 3 || heartsLeft == 2.5 || !ScoreManager.winnerScreen && !PlayerHealth.isDead) 
		{
			buyLifeButton.SetActive (false);
		}



		if (levelManager.currentLevel == 1 && !levelTextShown) 
		{
			levelTextShown = true;
			StartCoroutine (startNext ());
		}


	}
		
	public void addCookie ()
	{
		if (!cookieAdded)
		{
			cookieAdded = true;
			ScoreManager.totalScore = ScoreManager.tailgateBonus + ScoreManager.currentScore + ScoreManager.totalCookie;
			if (ScoreManager.totalScore == 1337) {
				Social.ReportProgress (LeaderboardManager.achiev10, 100.0f, (bool success) => {
				});

			}
			levelText.text = "Final Score is: " + ScoreManager.totalScore;
			levelText.enabled = true;
			//ScoreManager.totalCookie = 0;
			ScoreManager.currentScore = ScoreManager.totalScore;
			cookieAddedButton.SetActive (false);
			//shareScoreButton.SetActive (true);
			watchAdButton.SetActive (false);
			FileBasedPrefs.DeleteKey ("CPN");
			FileBasedPrefs.DeleteKey ("Total Score");
			FileBasedPrefs.DeleteKey ("Total Cookie");
			if (levelManager.currentLevel >= 5) 
			{
				levelManager.currentLevel = 5;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
			}

			if (levelManager.currentLevel <= 4) 
			{
				FileBasedPrefs.DeleteKey ("Current Level");
			}
			FileBasedPrefs.DeleteKey ("Continues");
		}
	}

	public void sendScore ()
	{
		#if UNITY_ANDROID
		PlayGamesPlatform.Activate ();
		#endif

		sentScore = System.Convert.ToInt64 (ScoreManager.totalScore);
		totalDeaths = Convert.ToInt64 (PlayerHealth.deathCount);
		totalGameTime = Convert.ToInt64(timeManager.gameTime);
		scoresSent = true;
	
		//Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
		if (Spawner.whiteWinner && ScoreManager.gameWinner)
		{
			Social.ReportScore (totalGameTime, LeaderboardManager.timeID, success =>
				{
				});
			Social.ReportScore (totalDeaths, LeaderboardManager.deathsID, success =>
				{
				});
			Social.ReportScore(sentScore, LeaderboardManager.leaderboardID, success =>
				{
					if (success)
					{
						Debug.Log("Reported score successfully");
					}
					else
					{
						Debug.Log("Failed to report score");
					}

				});

			FileBasedPrefs.DeleteKey ("Death Count");
			FileBasedPrefs.DeleteKey ("Game Time");
			FileBasedPrefs.DeleteKey ("Total Cookie");
			FileBasedPrefs.DeleteKey ("CPN");
			FileBasedPrefs.DeleteKey ("Current Level");
			FileBasedPrefs.DeleteKey ("Total Score");
			FileBasedPrefs.DeleteKey ("Continues");
		} else {

		Social.ReportScore(sentScore, LeaderboardManager.leaderboardID, success =>
			{
				if (success)
				{
					Debug.Log("Reported score successfully");
				}
				else
				{
					Debug.Log("Failed to report score");
				}

			});
		}

	}


	public void MainMenu ()
	{
		if (heartsLeft > 0) {
			SceneManager.LoadScene ("Main Menu");
			ScoreManager.winnerScreen = false;
			//cpnDeducted = true;
			//ScoreManager.totalCookie = ScoreManager.totalCookie - cpn;
			//PlayerPrefs.SetFloat ("Total Cookie", ScoreManager.totalCookie);
			//Debug.Log ("Total Cookie Points are now: " + ScoreManager.totalCookie);
			//cpn = cpn * 3;
			//PlayerPrefs.SetFloat ("CPN", cpn);
			//Debug.Log ("CPN is now: " + cpn);
			//Debug.Log ("Quitting to Menu!");
			continueButton.SetActive (false);
			restartButton.SetActive (false);
			menuButton.SetActive (false);
		} else {
			SceneManager.LoadScene ("Main Menu");
			//Debug.Log ("Quitting to Menu!");
			ScoreManager.winnerScreen = false;
			FileBasedPrefs.DeleteKey ("CPN");
			FileBasedPrefs.DeleteKey ("Total Score");
			FileBasedPrefs.DeleteKey ("Total Cookie");
			if (levelManager.currentLevel >= 5) 
			{
				levelManager.currentLevel = 5;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
			}

			if (levelManager.currentLevel <= 4) 
			{
				FileBasedPrefs.DeleteKey ("Current Level");
			}
			FileBasedPrefs.DeleteKey ("Continues");

		}
	}
		

	public void nextLevel ()
	{
		//Debug.Log ("Next button pressed!");
		BGMAudio.bgmAudio.Stop ();
		BGMAudio.hardReady = false;
		lifeButtonPressed = false;
		ScoreManager.cookiePoints = 0;
		Spawner.milestoneCapped = false;
		ScoreManager.winnerScreen = false;
		PlayerHealth.currentHealth = PlayerHealth.startingHealth;
		ScoreManager.finalAdd = false;
		deathText.enabled = false;
		levelManager.scoresSet = false;
		Spawner.spawnsStarted = false;
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		saveButton.SetActive (false);
		nextLevelButton.SetActive (false);
		MusicMilestones.mMilestoneSet = false;
		MusicMilestones.firstMilestoneReached = false;
		StartCoroutine (startNext ());
	}

	IEnumerator startNext ()
	{
		PanelAnimator.panelPlayed = false;
		menuSounds.clip = levelStartSound;
		startNextLevel1.text = "Reach Target Score of: " + levelManager.endScore;
		startNextLevel2.text = "Level " + levelManager.currentLevel + " in 3";
		startNextLevel1.enabled = true;
		startNextLevel2.enabled = true;
		menuSounds.Play ();
        outlines.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        outlines.SetActive(false);
        startNextLevel2.text = "Level " + levelManager.currentLevel + " in 2";
        yield return new WaitForSeconds(0.85f);
        outlines.SetActive(true);
        startNextLevel2.text = "Level " + levelManager.currentLevel + " in 1";
        yield return new WaitForSeconds(0.85f);
        outlines.SetActive(false);
        startNextLevel2.text = "Level " + levelManager.currentLevel + " Start!";
        yield return new WaitForSeconds(0.65f);
        startNextLevel1.enabled = false;
		startNextLevel2.enabled = false;
		levelManager.startNext = true;

		if (!BGMAudio.bgmAudio.isPlaying) 
		{
			BGMAudio.bgmAudio.Play ();
		}
		StopCoroutine (startNext ());
	}

	public void saveProgress ()
	{
		//Debug.Log ("Progress Saved!");
		saveButton.SetActive (false);
		SceneManager.LoadScene ("Main Menu");
	}


	public void watchAd ()
	{
		ShowRewardedVideo ();
	}

	void ShowRewardedVideo ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			if (heartsLeft <= 2.5f && !adWatched) {
				adWatched = true;
				watchAdButton.SetActive (false);
				heartsLeft = heartsLeft + 0.5f;
				//Debug.Log("Video completed - Offer a reward to the player");
				FileBasedPrefs.SetFloat ("Continues", heartsLeft);
				//Debug.Log ("You now have " + heartsLeft + "lives!");
			} else {}


		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}

	public void BuyContinueCP ()
	{
		lifeButtonPressed = true;
		menuSounds.clip = spendToken;
		menuSounds.Play ();
		if (ScoreManager.totalCookie >= cpn && heartsLeft <= 3 && heartsLeft != 2.5) {
			cpnDeducted = true;
			ScoreManager.totalCookie = ScoreManager.totalCookie - cpn;
			FileBasedPrefs.SetFloat ("Total Cookie", ScoreManager.totalCookie);
			cpn = cpn * 2;
			FileBasedPrefs.SetFloat ("CPN", cpn);
			heartsLeft = heartsLeft + 1;
			FileBasedPrefs.SetFloat ("Continues", heartsLeft);
			//continueButton.SetActive (false);
			//restartButton.SetActive (false);
			//menuButton.SetActive (false);
			//Debug.Log ("CPN is now: " + cpn);
			//Debug.Log ("You now have " + heartsLeft + "lives!");
			//Debug.Log ("Total Cookie Points are now: " + ScoreManager.totalCookie);
		}

		if (ScoreManager.totalCookie < cpn && !cpnDeducted) {
			//Debug.Log (cpn + "cookie points are needed! You only have: " + ScoreManager.totalCookie);
		}
	}

	public void Continue ()
	{
		if (heartsLeft > 0) 
		{
			SceneManager.LoadScene ("Game");
		}
	}

}
