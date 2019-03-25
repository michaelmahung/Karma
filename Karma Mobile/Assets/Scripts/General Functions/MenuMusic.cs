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

public class MenuMusic : MonoBehaviour {

	public Scene currentScene;
	public AudioSource mainMenu;
	public bool musicPlaying;
	private static MenuMusic instance;
	public static float winnerChanges;
	public Text MenuK;
	public Text MenuA;
	public Text MenuR;
	public Text MenuM;
	public Text MenuA2;
	public Color KColor;
	public Color32 AColor;
	public Color32 RColor;
	public Color32 MColor;
	public Color32 A2Color;
	public RawImage winnerIcon;
	private bool hasFaded;
	public RectTransform playButton;
	public RectTransform optionsButton;
	public RectTransform tutorialButton;
	public RectTransform creditsButton;
	public RectTransform quitButton;

	// Use this for initialization
	void Start () {

		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
		
		currentScene = SceneManager.GetActiveScene ();

		if (FileBasedPrefs.HasKey ("First Won")) 
		{
			winnerChanges = FileBasedPrefs.GetFloat ("First Won") + FileBasedPrefs.GetFloat ("Second Won")
				+ FileBasedPrefs.GetFloat ("Third Won") + FileBasedPrefs.GetFloat ("Fourth Won") + FileBasedPrefs.GetFloat ("Fifth Won")
				+ FileBasedPrefs.GetFloat ("Sixth Won") + FileBasedPrefs.GetFloat ("Seventh Won") + FileBasedPrefs.GetFloat ("Game Won");
		}

		//Debug.Log ("Winner Change Score is: " + winnerChanges);

		if (winnerChanges == 0)
		{
			MenuK.enabled = false;
			MenuA.enabled = false;
			MenuR.enabled = false;
			MenuM.enabled = false;
			MenuA2.enabled = false;
			playButton.localPosition = new Vector3 (0, 165, 0);
			optionsButton.localPosition = new Vector3 (0, 85, 0);
			tutorialButton.localPosition = new Vector3 (0, 0, 0);
			creditsButton.localPosition = new Vector3 (0, -85, 0);
			quitButton.localPosition = new Vector3 (0, -170, 0);
		}

		if (winnerChanges != 8) 
		{
			winnerIcon.enabled = false;
		}

		if (winnerChanges > 0) 
		{
			MenuK.enabled = true;
			MenuA.enabled = true;
			MenuR.enabled = true;
			MenuM.enabled = true;
			MenuA2.enabled = true;
			playButton.localPosition = new Vector3 (-125, 165, 0);
			optionsButton.localPosition = new Vector3 (-35, 85, 0);
			tutorialButton.localPosition = new Vector3 (65, 0, 0);
			creditsButton.localPosition = new Vector3 (155, -85, 0);
			quitButton.localPosition = new Vector3 (250, -170, 0);
				
		}

		if (winnerChanges == 1)
		{
			MenuK.color = Color.black;
			MenuA.color = Color.black;
			MenuR.color = Color.black;
			MenuM.color = Color.black;
			MenuA2.color = Color.black;
		}

		if (winnerChanges == 2) 
		{
			MenuK.color = Color.black;
			MenuA.color = Color.black;
			MenuR.color = Color.black;
			MenuM.color = Color.black;
			MenuA2.color = new Color (185/255.0f, 214/255.0f, 224/255.0f);
		}

		if (winnerChanges == 3) 
		{
			MenuK.color = Color.black;
			MenuA.color = Color.black;
			MenuR.color = Color.black;
			MenuM.color = new Color (203/255.0f, 255/255.0f, 207/255.0f);
			MenuA2.color = new Color (185/255.0f, 214/255.0f, 224/255.0f);
		}

		if (winnerChanges == 4) 
		{
			MenuK.color = Color.black;
			MenuA.color = Color.black;
			MenuR.color = new Color (255/255.0f, 215/255.0f, 215/255.0f);
			MenuM.color = new Color (203/255.0f, 255/255.0f, 207/255.0f);
			MenuA2.color = new Color (185/255.0f, 214/255.0f, 224/255.0f);
		}

		if (winnerChanges == 5) 
		{
			MenuK.color = Color.black;
			MenuA.color = new Color (247/255.0f, 209/255.0f, 255/255.0f);
			MenuR.color = new Color (255/255.0f, 215/255.0f, 215/255.0f);
			MenuM.color = new Color (203/255.0f, 255/255.0f, 207/255.0f);
			MenuA2.color = new Color (185/255.0f, 214/255.0f, 224/255.0f);
		}

		if (winnerChanges == 6) 
		{
			MenuK.color = new Color (253/255.0f, 249/255.0f, 202/255.0f);
			MenuA.color = new Color (247/255.0f, 209/255.0f, 255/255.0f);
			MenuR.color = new Color (255/255.0f, 215/255.0f, 215/255.0f);
			MenuM.color = new Color (203/255.0f, 255/255.0f, 207/255.0f);
			MenuA2.color = new Color (185/255.0f, 214/255.0f, 224/255.0f);
		}

		if (winnerChanges == 7) {
			MenuK.color = new Color (255/255.0f, 255/255.0f, 100/255.0f);
			MenuA.color = new Color (242/255.0f, 175/255.0f, 255/255.0f);
			MenuR.color = new Color (255/255.0f, 170/255.0f, 170/255.0f);
			MenuM.color = new Color (163/255.0f, 255/255.0f, 169/255.0f);
			MenuA2.color = new Color (135/255.0f, 201/255.0f, 224/255.0f);
		} 

		if (winnerChanges == 8) {
			winnerIcon.enabled = true;
			MenuK.color = new Color (255/255.0f, 255/255.0f, 100/255.0f);
			MenuA.color = new Color (242/255.0f, 175/255.0f, 255/255.0f);
			MenuR.color = new Color (255/255.0f, 170/255.0f, 170/255.0f);
			MenuM.color = new Color (163/255.0f, 255/255.0f, 169/255.0f);
			MenuA2.color = new Color (135/255.0f, 201/255.0f, 224/255.0f);
			Social.ReportProgress (LeaderboardManager.achiev9, 100.0f, (bool success) => {
			});
		} 

		if (instance == null) {
			instance = this;
		} else 
		{
			Destroy (this.gameObject);
			return;
		}


		if (currentScene.name != "Game") {
			DontDestroyOnLoad (this.gameObject);
		} else {Destroy (this.gameObject);
		}

		musicPlaying = false;



	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentScene.name == "Game") {
			Destroy (this.gameObject);
		}

		if (!musicPlaying) 
		{
			mainMenu.Play ();
			musicPlaying = true;
		}
	}
}
