using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour {

	public static bool greyLevel;
	public static bool blueLevel;
	public static bool greenLevel;
	public static bool purpleLevel;
	public static bool violetLevel;
	public static bool pinkLevel;
	public static bool goldLevel;
	public static bool whiteLevel;
	public static float startScore;
	public static float scorePer;
	public static float adjCurrent;
	public static float endScore;
	public static bool scoresSet;
	public static float adjEnd;
	public static bool startNext;
	public static bool levelSet;
	public Text deathText;
	public static float currentLevel;
	public static float firstWon;
	public static float secondWon;
	public static float thirdWon;
	public static float fourthWon;
	public static float fifthWon;
	public static float sixthWon;
	public static float seventhWon;
	public static float gameWon;
	public bool hasWon;
	public static Text targetScoreText;
	public Text levelText;


	void Awake () {

		startNext = false;

		targetScoreText = GameObject.Find ("Target Score Text").GetComponent<Text> ();

		if (FileBasedPrefs.HasKey ("First Won")) {
			firstWon = FileBasedPrefs.GetFloat ("First Won");
		}

		if (FileBasedPrefs.HasKey ("Second Won")) {
			secondWon = FileBasedPrefs.GetFloat ("Second Won");
		}

		if (FileBasedPrefs.HasKey ("Third Won")) {
			thirdWon = FileBasedPrefs.GetFloat ("Third Won");
		}

		if (FileBasedPrefs.HasKey ("Fourth Won")) {
			fourthWon = FileBasedPrefs.GetFloat ("Fourth Won");
		}

		if (FileBasedPrefs.HasKey ("Fifth Won")) {
			fifthWon = FileBasedPrefs.GetFloat ("Fifth Won");
		}

		if (FileBasedPrefs.HasKey ("Sixth Won")) {
			sixthWon = FileBasedPrefs.GetFloat ("Sixth Won");
		}

		if (FileBasedPrefs.HasKey ("Seventh Won")) {
			seventhWon = FileBasedPrefs.GetFloat ("Seventh Won");
		}

		if (FileBasedPrefs.HasKey ("Game Won")) {
			gameWon = FileBasedPrefs.GetFloat ("Game Won");
		}

		if (!FileBasedPrefs.HasKey ("Current Level"))
			{
				greyLevel = true;
				scoresSet = false;
				blueLevel = false;
				greenLevel = false;
				purpleLevel = false;
				violetLevel = false;
				pinkLevel = false;
				goldLevel = false;
				whiteLevel = false;
				endScore = 550f;
				startScore = 0f;
				Debug.Log ("End Score is: " + endScore);
				startNext = false;
				levelSet = false;
			}




	}

	void Update () {

		levelText.text = "Level: " + currentLevel;

		targetScoreText.text = "Target Score is: " + endScore;

		if (ScoreManager.winnerScreen || PlayerHealth.isDead || Spawner.hardMode) {
			levelText.enabled = false;
			targetScoreText.enabled = false;
		} else 
		{
			levelText.enabled = true;
			targetScoreText.enabled = true;
		}

		if (gameWon == 1) {
			hasWon = true;
		}
			

		if (!levelSet && greyLevel && !scoresSet && Spawner.greyWinner && ScoreManager.finalAdd) {
			Debug.Log ("Setting up blueLevel!");
			StartCoroutine (blueSet ());
			scoresSet = true;

		}

		if (!levelSet && blueLevel && !scoresSet && Spawner.blueWinner && ScoreManager.finalAdd) {
			Debug.Log ("Setting up greenLevel!");
			StartCoroutine (greenSet ());
			scoresSet = true;
		}

		if (!levelSet && greenLevel && !scoresSet && Spawner.greenWinner && ScoreManager.finalAdd) {
			Debug.Log ("Setting up purpleLevel!");
			StartCoroutine (purpleSet ());
			scoresSet = true;
		}

		if (!levelSet && purpleLevel && !scoresSet && Spawner.purpleWinner && ScoreManager.finalAdd) {
			Debug.Log ("Setting up violetLevel!");
			StartCoroutine (violetSet ());
			scoresSet = true;
		}

		if (!levelSet && violetLevel && !scoresSet && Spawner.violetWinner && ScoreManager.finalAdd) {
			Debug.Log ("Setting up pinkLevel!");
			StartCoroutine (pinkSet ());
			scoresSet = true;
		}

		if (!levelSet && pinkLevel && !scoresSet && Spawner.pinkWinner && ScoreManager.finalAdd) {
			Debug.Log ("Setting up goldLevel!");
			StartCoroutine (goldSet ());
			scoresSet = true;
		}

		if (!levelSet && goldLevel && !scoresSet && Spawner.goldWinner && ScoreManager.finalAdd) {
			Debug.Log ("Setting up whiteLevel!");
			StartCoroutine (whiteSet ());
			scoresSet = true;
		}

		if(!levelSet && whiteLevel && !scoresSet && Spawner.whiteWinner && ScoreManager.finalAdd) {
			Debug.Log ("Congratulations!");
			scoresSet = true;
		}


			
	}
		
		
	IEnumerator blueSet ()
	{
		yield return new WaitForSeconds (3);
		Debug.Log ("Blue Level Set!");
		currentLevel = 2;
		FileBasedPrefs.SetFloat ("Current Level", currentLevel);
		Debug.Log ("Saved Level is: " + currentLevel);
		PlayerHealth.faderValue = 0f;
		Spawner.waitTime = 0.8f;
		greyLevel = false;
		blueLevel = true;
		levelSet = true;
		targetScoreText.enabled = true;
		//sceneManager.nextLevelButton.SetActive (true);
		//sceneManager.saveButton.SetActive (true);
	}



	IEnumerator greenSet ()
	{
		yield return new WaitForSeconds (3);
		Debug.Log ("Green Level Set!");
		currentLevel = 3;
		FileBasedPrefs.SetFloat ("Current Level", currentLevel);
		Debug.Log ("Saved Level is: " + currentLevel);
		PlayerHealth.faderValue = 0f;
		Spawner.waitTime = 0.7f;
		blueLevel = false;
		greenLevel = true;
		levelSet = true;
		targetScoreText.enabled = true;
		//sceneManager.nextLevelButton.SetActive (true);
		//sceneManager.saveButton.SetActive (true);
	}

	IEnumerator purpleSet ()
	{
		yield return new WaitForSeconds (3);
		currentLevel = 4;
		FileBasedPrefs.SetFloat ("Current Level", currentLevel);
		Debug.Log ("Saved Level is: " + currentLevel);
		Debug.Log ("Purple Level Set!");
		PlayerHealth.faderValue = 0f;
		Spawner.waitTime = 0.6f;
		greenLevel = false;
		purpleLevel = true;
		levelSet = true;
		targetScoreText.enabled = true;
		//sceneManager.nextLevelButton.SetActive (true);
		//sceneManager.saveButton.SetActive (true);
	}

	IEnumerator violetSet ()
	{
		yield return new WaitForSeconds (3);
		currentLevel = 5;
		FileBasedPrefs.SetFloat ("Current Level", currentLevel);
		Debug.Log ("Saved Level is: " + currentLevel);
		Debug.Log ("Violet Level Set!");
		PlayerHealth.faderValue = 0f;
		Spawner.waitTime = 0.5f;
		purpleLevel = false;
		violetLevel = true;
		levelSet = true;
		targetScoreText.enabled = true;
		//sceneManager.nextLevelButton.SetActive (true);
		//sceneManager.saveButton.SetActive (true);
	}

	IEnumerator pinkSet ()
	{
		yield return new WaitForSeconds (3);
		currentLevel = 6;
		FileBasedPrefs.SetFloat ("Current Level", currentLevel);
		Debug.Log ("Saved Level is: " + currentLevel);
		Debug.Log ("Pink Level Set!");
		PlayerHealth.faderValue = 0f;
		Spawner.waitTime = 0.4f;
		violetLevel = false;
		pinkLevel = true;
		levelSet = true;
		targetScoreText.enabled = true;
		//sceneManager.nextLevelButton.SetActive (true);
		//sceneManager.saveButton.SetActive (true);
	}

	IEnumerator goldSet ()
	{
		yield return new WaitForSeconds (3);
		currentLevel = 7;
		FileBasedPrefs.SetFloat ("Current Level", currentLevel);
		Debug.Log ("Saved Level is: " + currentLevel);
		Debug.Log ("Gold Level Set!");
		PlayerHealth.faderValue = 0f;
		Spawner.waitTime = 0.275f;
		pinkLevel = false;
		goldLevel = true;
		levelSet = true;
		targetScoreText.enabled = true;
		//sceneManager.nextLevelButton.SetActive (true);
		//sceneManager.saveButton.SetActive (true);
	}

	IEnumerator whiteSet ()
	{
		yield return new WaitForSeconds (3);
		currentLevel = 8;
		FileBasedPrefs.SetFloat ("Current Level", currentLevel);
		Debug.Log ("Saved Level is: " + currentLevel);
		Debug.Log ("White Level Set!");
		PlayerHealth.faderValue = 0f;
		Spawner.waitTime = 0.2f;
		goldLevel = false;
		whiteLevel = true;
		levelSet = true;
		targetScoreText.enabled = true;
		//sceneManager.nextLevelButton.SetActive (true);
		//sceneManager.saveButton.SetActive (true);
	}



		
}

