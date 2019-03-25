using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms.GameCenter;
#endif
using GooglePlayGames;

public class MenuButtons : MonoBehaviour {

	private AudioSource menuSounds;
	public AudioClip buttonSound;
	public GameObject deletePanel;
	private bool deletingScores;
	private bool deletingProgress;
	private bool quittingGame;
	private bool deletingAll;
	public Text deleteText;
	public Animator mainMenuAnimations;
	public Animator tutorialAnimations;
	public Animator optionsAnimations;
	public Animator creditsAnimations;
	public Text loadingText;
	public static AsyncOperation gameLoaded;
	private float loadProgress;
	public GameObject loadBar;
	public Slider sliderValue;
	public Text totalDeathText;
	public static float totalDeaths;


	void Start () { 

		if (FileBasedPrefs.HasKey ("Total Deaths")) {
			totalDeaths = FileBasedPrefs.GetFloat ("Total Deaths");
		} else {
			totalDeaths = 0;
		}
		loadBar.SetActive (false);
		//PlayGamesPlatform.Activate ();
		loadingText.enabled = false;
		deletingAll = false;
		deletingScores = false;
		quittingGame = false;
		deletingProgress = false;
		mainMenuAnimations.enabled = false;
		tutorialAnimations.enabled = false;
		optionsAnimations.enabled = false;
		creditsAnimations.enabled = false;
		deletePanel.SetActive (false);
		menuSounds = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		totalDeathText.text = "" + totalDeaths;	
	}

	/*public void showLeaderboards ()
	{
		Social.ShowLeaderboardUI ();
	}

	public void showAchievements ()
	{
		Social.ShowAchievementsUI ();
	}*/

	public void loadOptions ()
	{
		mainMenuAnimations.enabled = true;
		mainMenuAnimations.Play ("Menu Options In Animation");
		optionsAnimations.enabled = true;
		optionsAnimations.Play ("Options In Animation");
	}

	public void LoadCredits ()
	{
		mainMenuAnimations.enabled = true;
		mainMenuAnimations.Play ("Menu Credits In Animation");
		creditsAnimations.enabled = true;
		creditsAnimations.Play ("Credits In Animation");
	}

	public void loadTutorial1 ()
	{
		mainMenuAnimations.enabled = true;
		mainMenuAnimations.Play ("Menu Tut 1");
		tutorialAnimations.enabled = true;
		tutorialAnimations.Play ("Tut 1 Animation");
	}

	public void loadTutorial2 ()
	{
		tutorialAnimations.Play ("Tut 2 Animation");
	}

	public void loadTutorial3 ()
	{
		tutorialAnimations.Play ("Tut 3 Animation");
	}

	public void OptionsToMenu ()
	{
		mainMenuAnimations.Play ("Menu Options Out Animations");
		optionsAnimations.Play ("Options Out Animation");
	}

	public void CreditsToMenu()
	{
		mainMenuAnimations.Play ("Menu Credits Out Animation");
		creditsAnimations.Play ("Credits Out Animation");
	}

	public void Tut1ToMenu ()
	{
		mainMenuAnimations.Play ("Menu Back Animation");
		tutorialAnimations.Play ("Tut 1 Menu Animation");
	}

	public void Tut2To1 ()
	{
		tutorialAnimations.Play ("Tut 2 Back Animation");
	}

	public void Tut3To2 ()
	{
		tutorialAnimations.Play ("Tut 3 Back Animation");
	}

	public void Tut3ToMenu ()
	{
		mainMenuAnimations.Play ("Menu 3 Back Animation");
		tutorialAnimations.Play ("Tut 3 Menu Animation");
	}

	public void Yep ()
	{
		menuSounds.clip = buttonSound;
		menuSounds.Play ();

		if (deletingAll) 
		{
			FileBasedPrefs.DeleteKey ("High Score");
			FileBasedPrefs.DeleteKey ("Death Count");
			FileBasedPrefs.DeleteKey ("Game Time");
			FileBasedPrefs.DeleteKey ("Total Cookie");
			FileBasedPrefs.DeleteKey ("CPN");
			FileBasedPrefs.DeleteKey ("Current Level");
			FileBasedPrefs.DeleteKey ("Total Score");
			FileBasedPrefs.DeleteKey ("Continues");
			FileBasedPrefs.DeleteKey ("Game Won");
			FileBasedPrefs.DeleteKey ("First Won");
			FileBasedPrefs.DeleteKey ("Second Won");
			FileBasedPrefs.DeleteKey ("Third Won");
			FileBasedPrefs.DeleteKey ("Fourth Won");
			FileBasedPrefs.DeleteKey ("Fifth Won");
			FileBasedPrefs.DeleteKey ("Sixth Won");
			FileBasedPrefs.DeleteKey ("Seventh Won");
			Application.Quit ();
		}

		if (quittingGame) 
		{
			Application.Quit();
		}

		if (deletingScores) 
		{
			FileBasedPrefs.DeleteKey ("HighScore");
		}

		if (deletingProgress) 
		{
			FileBasedPrefs.DeleteKey ("Current Level");
			FileBasedPrefs.DeleteKey ("Game Time");
			FileBasedPrefs.DeleteKey ("Continues");
			FileBasedPrefs.DeleteKey ("Total Score");
			FileBasedPrefs.DeleteKey ("Total Cookie");
			FileBasedPrefs.DeleteKey ("CPN");
		}

		deletePanel.SetActive (false);
	}

	public void Nope ()
	{
		deletePanel.SetActive (false);
		deletingScores = false;
		deletingProgress = false;
		quittingGame = false;
		deletingAll = false;
	}
		
	public void DeleteHighscore ()
	{
		deletingScores = true;
		deleteText.text = "Delete High Scores?";
		deletePanel.SetActive (true);
	}

	public void DeleteProgress ()
	{
		deletingProgress = true;
		deleteText.text = "Reset to Level 1?";
		deletePanel.SetActive (true);
	}

	public void DeleteAll ()
	{
		deletingAll = true;
		deleteText.text = "This will reset the entire game, are you sure?";
		deletePanel.SetActive (true);
	}

	public void LoadGame ()
	{
		loadBar.SetActive (true);
		loadingText.enabled = true;
		StartCoroutine (loadGame());
	}

	IEnumerator loadGame ()
	{
		gameLoaded = SceneManager.LoadSceneAsync ("Game");
		gameLoaded.allowSceneActivation = true;
		while (!gameLoaded.isDone) 
		{
			//Debug.Log (gameLoaded.progress);
			loadProgress = gameLoaded.progress;
			sliderValue.value = loadProgress;
			yield return null;
		}

		//gameLoaded.allowSceneActivation = true;
		//SceneManager.LoadScene ("Game");
	}

	public void QuitGame ()
	{
		quittingGame = true;
		deleteText.text = "Quit?";
		deletePanel.SetActive (true);
	}

}
