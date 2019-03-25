using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


	public GameObject UIPanel;
	// Use this for initialization
	void Start () {
		UIPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerHealth.isDead || ScoreManager.winnerScreen) {
			UIPanel.SetActive (true);
		} else {
			UIPanel.SetActive (false);
		}
			
	}
}
