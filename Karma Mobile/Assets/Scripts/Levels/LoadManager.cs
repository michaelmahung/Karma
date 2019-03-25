using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour {

	public GameObject skipLevelButton;
	public bool levelLoaded = true;

	void Start () {

		if (FileBasedPrefs.HasKey ("Current Level")) 
		{
			levelManager.currentLevel = FileBasedPrefs.GetFloat ("Current Level");
			levelLoaded = false;
			//Debug.Log ("Loaded current level of: " + levelManager.currentLevel);
		}

		if (!FileBasedPrefs.HasKey ("Current Level")) 
		{
			ScoreManager.winnerScreen = false;
			levelManager.currentLevel = 1;
		}
			
		//Debug.Log ("Current Level is: " + levelManager.currentLevel);
	}

	void Update ()
	{

		if (levelManager.currentLevel <= 3 && ScoreManager.winnerScreen && ScoreManager.totalCookie >= (sceneManager.cpn * 2)) {
			skipLevelButton.SetActive (true);
		} else 
		{
			skipLevelButton.SetActive (false);
		}

		if (levelManager.currentLevel == 2 && !levelLoaded) 
		{
			Load2 ();
		}

		if (levelManager.currentLevel == 3 && !levelLoaded) 
		{
			Load3 ();
		}

		if (levelManager.currentLevel == 4 && !levelLoaded) 
		{
			Load4 ();
		}

		if (levelManager.currentLevel == 5 && !levelLoaded) 
		{
			Load5 ();
		}

		if (levelManager.currentLevel == 6 && !levelLoaded) 
		{
			Load6 ();
		}

		if (levelManager.currentLevel == 7 && !levelLoaded) 
		{
			Load7 ();
		}

		if (levelManager.currentLevel == 8 && !levelLoaded) 
		{
			Load8 ();
		}
		
	}

	public void SkipLevel ()
	{
		if (levelManager.currentLevel == 2) {
			ScoreManager.totalCookie = ScoreManager.totalCookie - (sceneManager.cpn * 2);
			skipLevelButton.SetActive (false);
			FileBasedPrefs.SetFloat ("Total Score", ScoreManager.totalScore);
			FileBasedPrefs.SetFloat ("Total Cookie", ScoreManager.totalCookie);
			levelManager.currentLevel = 3;
			FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
			SceneManager.LoadScene ("Game");
		} else {

			if (levelManager.currentLevel == 3) {
				ScoreManager.totalCookie = ScoreManager.totalCookie - (sceneManager.cpn * 2);
				skipLevelButton.SetActive (false);
				FileBasedPrefs.SetFloat ("Total Score", ScoreManager.totalScore);
				FileBasedPrefs.SetFloat ("Total Cookie", ScoreManager.totalCookie);
				levelManager.currentLevel = 4;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
				SceneManager.LoadScene ("Game");
			}

		}
	}

	public void Load2()
	{
		//Debug.Log ("Loading level: " + levelManager.currentLevel);
		levelLoaded = true;
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		Spawner.waitTime = 0.8f;
		levelManager.levelSet = true;
		levelManager.greyLevel = false;
		levelManager.blueLevel = true;
		levelManager.scoresSet = true;
		levelManager.startNext = false;
		levelManager.startScore = 550;
		levelManager.endScore = 1488;
		Spawner.nextMilestone = 925;
		ScoreManager.pointsPerSecond = 2;
		Spawner.spawnSpeedMultiplier = 2;
		ScoreManager.currentScore = levelManager.startScore;
		ScoreManager.totalScore = FileBasedPrefs.GetFloat ("Total Score");
		ScoreManager.totalCookie = FileBasedPrefs.GetFloat ("Total Cookie");
		ScoreManager.winnerScreen = true;
	}

	public void Load3()
	{
		//Debug.Log ("Loading level: " + levelManager.currentLevel);
		levelLoaded = true;
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		Spawner.waitTime = 0.7f;
		levelManager.levelSet = true;
		levelManager.blueLevel = false;
		levelManager.greenLevel = true;
		levelManager.scoresSet = true;
		levelManager.startNext = false;
		levelManager.startScore = 1488;
		levelManager.endScore = 3597;
		Spawner.nextMilestone = 2331;
		ScoreManager.pointsPerSecond = 2;
		Spawner.spawnSpeedMultiplier = 2;
		ScoreManager.currentScore = levelManager.startScore;
		ScoreManager.totalScore = FileBasedPrefs.GetFloat ("Total Score");
		ScoreManager.totalCookie = FileBasedPrefs.GetFloat ("Total Cookie");
		ScoreManager.winnerScreen = true;
	}

	public void Load4()
	{
		//Debug.Log ("Loading level: " + levelManager.currentLevel);
		levelLoaded = true;
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		Spawner.waitTime = 0.6f;
		levelManager.levelSet = true;
		levelManager.greenLevel = false;
		levelManager.purpleLevel = true;
		levelManager.scoresSet = true;
		levelManager.startNext = false;
		levelManager.startScore = 3597;
		levelManager.endScore = 8343;
		Spawner.nextMilestone = 5495;
		ScoreManager.pointsPerSecond = 4;
		Spawner.spawnSpeedMultiplier = 4;
		ScoreManager.currentScore = levelManager.startScore;
		ScoreManager.totalScore = FileBasedPrefs.GetFloat ("Total Score");
		ScoreManager.totalCookie = FileBasedPrefs.GetFloat ("Total Cookie");
		FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
		ScoreManager.winnerScreen = true;
	}

	public void Load5()
	{
		//Debug.Log ("Loading level: " + levelManager.currentLevel);
		levelLoaded = true;
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		Spawner.waitTime = 0.5f;
		levelManager.levelSet = true;
		levelManager.purpleLevel = false;
		levelManager.violetLevel = true;
		levelManager.scoresSet = true;
		levelManager.startNext = false;
		levelManager.startScore = 8343;
		levelManager.endScore = 19022;
		Spawner.nextMilestone = 12614;
		ScoreManager.pointsPerSecond = 6;
		Spawner.spawnSpeedMultiplier = 6;
		ScoreManager.currentScore = levelManager.startScore;
		ScoreManager.totalScore = FileBasedPrefs.GetFloat ("Total Score");
		ScoreManager.totalCookie = FileBasedPrefs.GetFloat ("Total Cookie");
		FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
		ScoreManager.winnerScreen = true;
	}

	public void Load6()
	{
		//Debug.Log ("Loading level: " + levelManager.currentLevel);
		levelLoaded = true;
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		Spawner.waitTime = 0.4f;
		levelManager.levelSet = true;
		levelManager.violetLevel = false;
		levelManager.pinkLevel = true;
		levelManager.scoresSet = true;
		levelManager.startNext = false;
		levelManager.startScore = 19022;
		levelManager.endScore = 43049;
		Spawner.nextMilestone = 28632;
		ScoreManager.pointsPerSecond = 10;
		Spawner.spawnSpeedMultiplier = 10;
		ScoreManager.currentScore = levelManager.startScore;
		ScoreManager.totalScore = FileBasedPrefs.GetFloat ("Total Score");
		ScoreManager.totalCookie = FileBasedPrefs.GetFloat ("Total Cookie");
		FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
		ScoreManager.winnerScreen = true;
	}

	public void Load7()
	{
		//Debug.Log ("Loading level: " + levelManager.currentLevel);
		levelLoaded = true;
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		Spawner.waitTime = 0.275f;
		levelManager.levelSet = true;
		levelManager.pinkLevel = false;
		levelManager.goldLevel = true;
		levelManager.scoresSet = true;
		levelManager.startNext = false;
		levelManager.startScore = 43049;
		levelManager.endScore = 97110;
		Spawner.nextMilestone = 64673;
		ScoreManager.pointsPerSecond = 16;
		Spawner.spawnSpeedMultiplier = 16;
		ScoreManager.currentScore = levelManager.startScore;
		ScoreManager.totalScore = FileBasedPrefs.GetFloat ("Total Score");
		ScoreManager.totalCookie = FileBasedPrefs.GetFloat ("Total Cookie");
		FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
		ScoreManager.winnerScreen = true;
	}

	public void Load8()
	{
		//Debug.Log ("Loading level: " + levelManager.currentLevel);
		levelLoaded = true;
		//Spawner.musicMilestone = 1;
		MusicMilestones.musicMilestone = 1;
		Spawner.waitTime = 0.200f;
		Spawner.currentTime = 0.200f;
		levelManager.levelSet = true;
		levelManager.goldLevel = false;
		levelManager.whiteLevel = true;
		levelManager.scoresSet = true;
		levelManager.startNext = false;
		levelManager.startScore = 97110;
		levelManager.endScore = 218747;
		Spawner.nextMilestone = 145764;
		ScoreManager.pointsPerSecond = 24;
		Spawner.spawnSpeedMultiplier = 24;
		ScoreManager.currentScore = levelManager.startScore;
		ScoreManager.totalScore = FileBasedPrefs.GetFloat ("Total Score");
		ScoreManager.totalCookie = FileBasedPrefs.GetFloat ("Total Cookie");
		FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
		ScoreManager.winnerScreen = true;
	}

}
