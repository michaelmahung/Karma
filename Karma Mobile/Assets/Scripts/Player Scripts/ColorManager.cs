using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour {

	public Color greyColor;
	public Color blueColor;
	public Color greenColor;
	public Color redColor;
	public Color purpleColor;
	public Color orangeColor;
	public Color pinkColor;
	public Color goldColor;
	public Color whiteColor;
	public Color block1;
	public Color block2;
	public Color block3;
	public Color block4;
	public Color block5;
	public Color block6;
	public Color block7;
	public Color block8;
	public Color block9;
	public float lerpValue;
	public float lerpIncrement;
	public float lerpDuration;
	public float lerpSmoothness;
	public AudioClip whiteWait;
	public bool colorsStarted;
	public bool finalLerping;
	public Light blockColor;
	public Color startColor;
	public Color endColor;
	public Color lightStart;
	public Color lightEnd;
	//public static Color block1;
	//public static Color block2;
	public float blockValue;

	void Start ()
	{
		greyColor = new Color (255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
		blueColor = new Color (15 / 255.0f, 74 / 255.0f, 225 / 255.0f);
		greenColor = new Color (16 / 255.0f, 156 / 255.0f, 0 / 255.0f);
		redColor = new Color (238 / 255.0f, 34 / 255.0f, 34 / 255.0f);
		purpleColor = new Color (145 / 255.0f, 0 / 255.0f, 255 / 255.0f);
		orangeColor = new Color (255 / 255.0f, 113 / 255.0f, 0 / 255.0f);
		pinkColor = new Color (255 / 255.0f, 48 / 255.0f, 255 / 255.0f);
		goldColor = new Color (240 / 255.0f, 212 / 255.0f, 0 / 255.0f);
		whiteColor = new Color (255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
		block1 = new Color (255 / 255.0f, 0 / 255.0f, 0 / 255.0f);
		block2 = new Color (255 / 255.0f, 90 / 255.0f, 0 / 255.0f);
		block3 = new Color (255 / 255.0f, 0 / 255.0f, 0 / 255.0f);
		block4 = new Color (0 / 255.0f, 200 / 255.0f, 0 / 255.0f);
		block5 = new Color (180 / 255.0f, 255 / 255.0f, 0 / 255.0f);
		block6 = new Color (80 / 255.0f, 0 / 255.0f, 255 / 255.0f);
		block7 = new Color (0 / 255.0f, 140 / 255.0f, 130 / 255.0f);
		block8 = new Color (155 / 255.0f, 0 / 255.0f, 225 / 255.0f);
		block9 = new Color (0 / 255.0f, 255 / 255.0f, 255 / 255.0f);
		finalLerping = false;
		colorsStarted = false;
	}

	void Update ()
	{

		if (levelManager.currentLevel == 1) 
		{
			lightStart = block1;
			lightEnd = block2;
			PlayerHealth.startColor = greyColor;
			PlayerHealth.endColor = blueColor;
		}

		if (levelManager.currentLevel == 2) 
		{
			lightStart = block2;
			lightEnd = block3;
			PlayerHealth.startColor = blueColor;
			PlayerHealth.endColor = greenColor;
		}

		if (levelManager.currentLevel == 3) 
		{
			lightStart = block3;
			lightEnd = block4;
			PlayerHealth.startColor = greenColor;
			PlayerHealth.endColor = redColor;
		}

		if (levelManager.currentLevel == 4) 
		{
			lightStart = block4;
			lightEnd = block5;
			PlayerHealth.startColor = redColor;
			PlayerHealth.endColor = purpleColor;
		}

		if (levelManager.currentLevel == 5) 
		{
			lightStart = block5;
			lightEnd = block6;
			PlayerHealth.startColor = purpleColor;
			PlayerHealth.endColor = orangeColor;
		}

		if (levelManager.currentLevel == 6) 
		{
			lightStart = block6;
			lightEnd = block7;
			PlayerHealth.startColor = orangeColor;
			PlayerHealth.endColor = pinkColor;
		}

		if (levelManager.currentLevel == 7) 
		{
			lightStart = block7;
			lightEnd = block8;
			PlayerHealth.startColor = pinkColor;
			PlayerHealth.endColor = goldColor;
		}

		if (levelManager.currentLevel == 8 && !colorsStarted) 
		{
			lightStart = block8;
			lightEnd = Color.red;
			PlayerHealth.startColor = goldColor;
			PlayerHealth.endColor = whiteColor;
		}

		levelManager.adjEnd = levelManager.endScore - levelManager.startScore;
		levelManager.adjCurrent = ScoreManager.currentScore - levelManager.startScore;

		if (levelManager.adjCurrent < ScoreManager.currentScore - levelManager.startScore) {
			levelManager.adjCurrent = ScoreManager.currentScore - levelManager.startScore;
		}

		if (levelManager.adjEnd < levelManager.adjEnd - levelManager.startScore) {
			levelManager.adjEnd = levelManager.adjEnd - levelManager.startScore;
		}

		levelManager.scorePer = levelManager.adjCurrent / levelManager.adjEnd;

		PlayerHealth.faderValue = levelManager.scorePer;



		if (!colorsStarted)
		{
			blockColor.color = Color.Lerp(lightStart, lightEnd, levelManager.scorePer);
		}


		if (colorsStarted) 
		{
			blockColor.color = Color.Lerp(lightStart, lightEnd, lerpValue);
		}


		if (BGMAudio.hardReady && levelManager.whiteLevel && !colorsStarted && Spawner.hardMode) 
		{
			lightStart = Color.red;
			lightEnd = block2;
			lerpValue = 0;
			colorsStarted = true;
			StartCoroutine (finalColors ());
		}
		/*if (finalLerping) 
		{
			lerpValue = (Time.time / lerpTime);
		}*/
	}

	IEnumerator finalColors ()
	{
		yield return new WaitForSeconds (whiteWait.length);
		Debug.Log ("Starting Hard Mode Color Fade!");
		lerpValue = 0;
		lerpIncrement = lerpSmoothness / lerpDuration;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}

		lightStart = block2;
		lightEnd = block3;
		lerpValue = 0;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}

		lightStart = block3;
		lightEnd = block4;
		lerpValue = 0;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}

		lightStart = block4;
		lightEnd = block5;
		lerpValue = 0;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}

		lightStart = block5;
		lightEnd = block6;
		lerpValue = 0;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}

		lightStart = block6;
		lightEnd = block7;
		lerpValue = 0;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}

		lightStart = block7;
		lightEnd = block8;
		lerpValue = 0;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}

		lightStart = block8;
		lightEnd = block9;
		lerpValue = 0;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}

		lightStart = block9;
		lightEnd = block1;
		lerpValue = 0;
		while (lerpValue < 1) 
		{
			lerpValue += lerpIncrement;
			yield return new WaitForSeconds(lerpSmoothness);
		}


	}



}
