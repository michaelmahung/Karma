using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAnimator : MonoBehaviour {

	public Animator deathPanel;
	public Animator tokenPanel;
	public static bool animPlayed;
	public static bool panelPlayed;
	public static float tokensLeft;
	public GameObject tokenButton;
	public GameObject tokensLeftObject;
	public Text tokensLeftText;
	public AudioSource menuSounds2;
	public AudioClip spendTokenSound2;


	void Start () {
		tokenButton.SetActive (false);
		panelPlayed = false;
		tokenPanel.enabled = true;
		deathPanel.enabled = false;
		if (FileBasedPrefs.HasKey ("Tokens Left")) {
			tokensLeft = FileBasedPrefs.GetFloat ("Tokens Left");
		}

		if (!FileBasedPrefs.HasKey ("Tokens Left")) {
			tokensLeft = 4;
		}
	}

	void Update () {

		tokensLeftText.text = "x " + tokensLeft;


		if (PlayerHealth.isDead || ScoreManager.winnerScreen) {
			tokensLeftObject.SetActive (true);
		} else {
			tokensLeftObject.SetActive (false);
		}

		if (PlayerHealth.isDead && !panelPlayed || ScoreManager.winnerScreen && !panelPlayed) 
		{
			panelIn ();
		}

		if (sceneManager.heartsLeft < 2.5f) {
			tokenButton.SetActive (true);
		} else {
			tokenButton.SetActive (false);
		}

		if (sceneManager.cookieAdded) {
			tokenButton.SetActive (false);
		}
	}

	public void panelIn ()
	{
		deathPanel.enabled = true;
		deathPanel.Play ("Death Panel");
		panelPlayed = true;
	}

	public void tokenPanelIn ()
	{
		if (tokensLeft <= 0) 
		{
			tokenPanel.Play ("IAP Panel In");
			deathPanel.Play ("Death Panel Out");
		}

		if (tokensLeft > 0 && sceneManager.heartsLeft < 2.5f) 
		{
			menuSounds2.clip = spendTokenSound2;
			menuSounds2.Play ();
			tokensLeft -= 1;
			FileBasedPrefs.SetFloat ("Tokens Left", tokensLeft);
			sceneManager.heartsLeft += 1;
			FileBasedPrefs.SetFloat ("Continues", sceneManager.heartsLeft);
		}
	}

	public void tokenPanelOut ()
	{
		tokenPanel.Play ("IAP Panel Out");
		deathPanel.Play ("Death Panel In");
	}
		

}
