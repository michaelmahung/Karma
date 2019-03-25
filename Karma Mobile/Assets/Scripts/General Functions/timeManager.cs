using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour {

	public static float gameTime;
	public bool timeShown;
	public Text gameTimeText;
	public float timer;

	// Use this for initialization
	void Awake () {
		
		StartCoroutine (gameTimer());

		if (FileBasedPrefs.HasKey ("Game Time")) 
		{
			gameTime = FileBasedPrefs.GetFloat ("Game Time");
		} 
			
	}
	
	// Update is called once per frame
	void Update () {
		timer = gameTime;
		if (ScoreManager.gameWinner) {
			StopAllCoroutines ();
			FileBasedPrefs.DeleteKey ("Game Time");
			gameTimeText.text = "Total Game Time: " + gameTime + " Seconds.";
			gameTimeText.enabled = true;
		} else 
		{
			gameTimeText.enabled = false;
		}

	}

	IEnumerator gameTimer ()
	{
		gameTime = gameTime + 1;
		yield return new WaitForSeconds (1);
		StartCoroutine (gameTimer ());
	}
}
