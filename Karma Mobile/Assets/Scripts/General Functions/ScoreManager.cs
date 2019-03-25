using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public float startingScore;
	public static float currentScore;
	public static float scoreMultiplier;
	public float highScore;
	public Text scoreText;
	public Text highScoreText;
	public Text tailgateText;
	public static Text cpText;
	public static Text totalCp;
	public bool scoreIncreasing;
	public static float healPoints;
	public static float pointsPerSecond;
	public static float tailgateBonus;
	public static float murderTrailBonus;
	public static float scaledBonus;
	public static float oneShotBonus;
	public static float osScaled;
	public static float hpps;
	public float tgps;
	public static float ospps;
	public static float pps;
	public static float totalScore;
	public bool scoreAdded = false;
	public Text deathText;
	public static bool finalAdd;
	public static float cookiePoints;
	public static float totalCookie;
	public static bool ppsIncreasing;
	public static bool winnerScreen;
	public static bool gameWinner;
	public float exponent;
	public float previousAdd;
	public Text bonusAddText;
	public bool startAdd;
	public bool addStarted;
	public static float pointLoss;
	public static float originalScore;
	public static float increasedMult;
	public static float multIncrease;
	public static float doubleMult;
	public Text scoreMultText;
	public static float dodgeBonus;

	void Awake () {
		//PlayerPrefs.DeleteAll ();
	}


	void Start () {
		dodgeBonus = 0;
		multIncrease = 1;
		startAdd = false;
		bonusAddText.enabled = false;
		gameWinner = false;
		cpText = GameObject.Find ("Cp Earned").GetComponent<Text>();
		totalCp = GameObject.Find ("Total Cp").GetComponent<Text>();
		if (FileBasedPrefs.HasKey ("HighScore")) {
			highScore = FileBasedPrefs.GetFloat ("HighScore");
		} else {highScore = 0f;
		}
		healPoints = 0;
		totalScore = 0;
		pointsPerSecond = 2f;
		murderTrailBonus = 0;
		tgps = 0;
		finalAdd = false;
		scoreAdded = false;
		currentScore = 0;
		deathText.enabled = false;
		tailgateBonus = 0f;
		cookiePoints = 0f;
		StartCoroutine (AddTailgate());
		scoreIncreasing = true;
		if (FileBasedPrefs.HasKey ("Total Score")) {
			totalScore = FileBasedPrefs.GetFloat ("Total Score");
		} else {totalScore = 0f;
		}

		if (FileBasedPrefs.HasKey ("Total Cookie")) {
			totalCookie = FileBasedPrefs.GetFloat ("Total Cookie");
		} else {totalCookie = 0f;
		}
	}


	void Update () {

		hpps = 10 * increasedMult;

		pps = pointsPerSecond * increasedMult;

        exponent = Mathf.Pow(0.9825f, PlayerHealth.healthPer);
        scoreMultiplier = 5.91f * (0.9825f * exponent);

        increasedMult = (scoreMultiplier * multIncrease) * doubleMult;

        scoreMultText.text = "x " + Mathf.Round(increasedMult * 2) * 0.5f;

        pointLoss = Mathf.Round(originalScore - currentScore);

        		highScoreText.text = "High Score: " + (int)highScore;
		tailgateText.text = "Bonus: " +  (int)(tailgateBonus + healPoints);
		totalCp.text = "Total Bonus Points: " + (int)totalCookie;

        if (gameWinner && winnerScreen) 
		{
			highScoreText.enabled = true;
			scoreText.enabled = true;
			totalCp.enabled = false;
			tailgateText.enabled = false;
			cpText.enabled = false;
		}

		if (!gameWinner && winnerScreen) {
			highScoreText.enabled = true;
			cpText.enabled = true;
			totalCp.enabled = true;
			scoreText.enabled = false;
			tailgateText.enabled = false;
		} 

		if (!gameWinner && !winnerScreen)
		{
			cpText.enabled = false;
			highScoreText.enabled = false;
			totalCp.enabled = false;
			scoreText.enabled = true;
			tailgateText.enabled = true;
		}

		if (!PlayerHealth.isDead && Spawner.spawnsStarted) {
			scoreAdded = false;
			ppsIncreasing = true;
			scoreIncreasing = true;
		} else {scoreAdded = true;
				ppsIncreasing = false;
				scoreIncreasing = false;
		}

		if (currentScore >= levelManager.endScore || Spawner.healTime) {
			ppsIncreasing = false;
		}

		if (Spawner.hardMode || PlayerHealth.isDead) {
			ppsIncreasing = false;
		}

		if (PlayerHealth.isDead) {
			highScoreText.enabled = true;
			totalCp.enabled = true;
			cpText.enabled = false;
			scoreText.enabled = false;
			tailgateText.enabled = false;
			levelManager.targetScoreText.enabled = false;
			scoreIncreasing = false;
		}

		if (PlayerHealth.isDead && sceneManager.cookieAdded) {
			scoreText.text = "Total Final Score: " + Mathf.Round (totalScore);
			scoreText.enabled = true;
			highScoreText.enabled = true;
		} else 
		{
			scoreText.text = "Score: " + Mathf.Round (currentScore);
		}

		if (PlayerHealth.tailgating) {
			startAdd = true;
			tgps = 5f;
		} else { tgps = 0f;
		}

		if (PlayerHealth.healing == true) {
			startAdd = true;
		} 

		if (PlayerHealth.murderTrail) {
			murderTrailBonus = scaledBonus;
		} else {
			murderTrailBonus = 0f;
		}

		if (PlayerHealth.osTrail) {
			oneShotBonus = osScaled;
		} else {
			oneShotBonus = 0f;
		}

		if (startAdd && !addStarted && !Spawner.hardMode && !winnerScreen) 
		{
			StartCoroutine (AddTailgate ());
		}

		if (Spawner.healTime && !ppsIncreasing && originalScore > currentScore) 
		{
			bonusAddText.color = Color.red;
			bonusAddText.text = "- " + pointLoss;
			bonusAddText.enabled = true;
		}

		if (Spawner.healTime && !ppsIncreasing && originalScore < currentScore) 
		{
			bonusAddText.color = Color.green;
			bonusAddText.text = "+ " + pointLoss;
			bonusAddText.enabled = true;
		}

		if (!Spawner.healTime && !ppsIncreasing)
		{
			bonusAddText.enabled = false;
		}

		if (scoreIncreasing && PlayerHealth.healing)
		{
			healPoints += (hpps * Time.deltaTime) * (Spawner.spawnSpeedMultiplier * 4);
		}

		if (scoreIncreasing && PlayerHealth.murderTrail) 
		{
			murderTrailBonus += ((murderTrailBonus * Time.deltaTime) * (Spawner.spawnSpeedMultiplier * 20)) * (increasedMult * 3);
		}

		if (scoreIncreasing && PlayerHealth.osTrail) 
		{
			oneShotBonus += ((oneShotBonus * Time.deltaTime) * (Spawner.spawnSpeedMultiplier * 20)) * (increasedMult * 6);
		}

		if (scoreIncreasing) {
			tailgateBonus += (((tgps * Time.deltaTime) * (increasedMult)*2.25f) * (Spawner.spawnSpeedMultiplier * 6f) + murderTrailBonus + (oneShotBonus));
		}

		if (scoreIncreasing && ppsIncreasing) {
			currentScore += ((pps * Time.deltaTime)) * Spawner.spawnSpeedMultiplier;
		}

		if (Spawner.greyWinner && !PlayerHealth.isDead && !finalAdd && levelManager.greyLevel) {
			finalAdd = true;
			StartCoroutine (FinishingTouches ());
		}

		if (Spawner.blueWinner && !PlayerHealth.isDead && !finalAdd && levelManager.blueLevel) {
			finalAdd = true;
			StartCoroutine (FinishingTouches ());
		}

		if (Spawner.greenWinner && !PlayerHealth.isDead && !finalAdd && levelManager.greenLevel) {
			finalAdd = true;
			StartCoroutine (FinishingTouches ());
		}

		if (Spawner.purpleWinner && !PlayerHealth.isDead && !finalAdd && levelManager.purpleLevel) {
			finalAdd = true;
			StartCoroutine (FinishingTouches ());
		}

		if (Spawner.violetWinner && !PlayerHealth.isDead && !finalAdd && levelManager.violetLevel) {
			finalAdd = true;
			StartCoroutine (FinishingTouches ());
		}

		if (Spawner.pinkWinner && !PlayerHealth.isDead && !finalAdd && levelManager.pinkLevel) {
			finalAdd = true;
			StartCoroutine (FinishingTouches ());
		}

		if (Spawner.goldWinner && !PlayerHealth.isDead && !finalAdd && levelManager.goldLevel) {
			finalAdd = true;
			StartCoroutine (FinishingTouches ());
		}

		if (Spawner.whiteWinner && !PlayerHealth.isDead && !finalAdd && levelManager.whiteLevel) {
			finalAdd = true;
			StartCoroutine (FinishingTouches ());
		}

		if (currentScore > highScore) 
		{
			highScore = currentScore;
			FileBasedPrefs.SetFloat ("HighScore", highScore);
		}

		if (sceneManager.lifeButtonPressed) 
		{
			cpText.text = "Next Life = " + sceneManager.cpn + " BP";
		} else {cpText.text = "Earned: " + cookiePoints + " Bonus Points!";}
	}

	IEnumerator FinishingTouches ()
	{
			yield return new WaitForSeconds (2.99f);
			Spawner.hardMode = false;
			winnerScreen = true;
			cpText.enabled = true;
			totalCp.enabled = true;
			totalScore = tailgateBonus + currentScore;
			FileBasedPrefs.SetFloat ("Game Time", timeManager.gameTime);
			FileBasedPrefs.SetFloat ("Total Score", totalScore);
			currentScore = totalScore;
			scoreIncreasing = false;
			cookiePoints = Mathf.Round (currentScore - levelManager.endScore);
			if (cookiePoints < 0) {
				cookiePoints = 0;
			}
			totalCookie = totalCookie + cookiePoints;
			FileBasedPrefs.SetFloat ("Total Cookie", totalCookie);
			if (Spawner.whiteWinner && levelManager.whiteLevel) {
				totalScore = tailgateBonus + currentScore + totalCookie;
				totalCookie = 0;
				currentScore = totalScore;

			}
			if (Spawner.whiteWinner && levelManager.whiteLevel) {
				winnerScreen = true;
				gameWinner = true;
				deathText.enabled = true;
				deathText.text = "Times Reborn: " + PlayerHealth.deathCount;
			} else {
				levelManager.startScore = levelManager.endScore;
				levelManager.endScore = Mathf.Round ((((levelManager.startScore * 1.5f) + 100f) * 1.5f) + 100f);
				ScoreManager.currentScore = levelManager.startScore;
				levelManager.scorePer = 0;
			}
			tailgateBonus = 0f;
			healPoints = 0f; 

	}


	public void addTailgate ()
	{
		
		if (!scoreAdded && ppsIncreasing && !PlayerHealth.isDead && !Spawner.hardMode) {
			previousAdd = Mathf.Round(tailgateBonus + healPoints);
			totalScore = tailgateBonus + currentScore + healPoints;
			currentScore = totalScore;
			healPoints = 0f;
			tailgateBonus = 0f;
			scoreAdded = (true);
		}
	}

	IEnumerator AddTailgate ()
	{
		if (Spawner.healTime) {
			addStarted = false;
			scoreAdded = false;
			StopCoroutine (AddTailgate ());
		} else 
		{
			addStarted = true;
			yield return new WaitForSeconds (3);
			scoreAdded = false;
			addTailgate ();
			if (previousAdd <= 0 && ppsIncreasing) 
			{
				bonusAddText.text = "+ " + previousAdd;
				bonusAddText.color = Color.red;
			}

			if (previousAdd > 0 && ppsIncreasing) 
			{
				bonusAddText.text = "+ " + previousAdd;
				bonusAddText.color = Color.green;
			}

			if (!PlayerHealth.isDead && !Spawner.hardMode && ppsIncreasing) 
			{
				bonusAddText.enabled = true;
				yield return new WaitForSeconds (1.5f);
				bonusAddText.enabled = false;
			}
			addStarted = false;
			StopCoroutine (AddTailgate ());

		}
	


			
	}

}