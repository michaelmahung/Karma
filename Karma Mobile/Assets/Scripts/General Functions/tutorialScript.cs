using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tutorialScript : MonoBehaviour {

	public Image thisImage;
	public AudioSource tutorialAudio;
	public AudioClip randomClip;
	public AudioClip[] clips;
	public Color[] colors;
	public Color randomColor;

	// Use this for initialization
	void Start () {
		tutorialAudio = gameObject.GetComponent<AudioSource> ();
		tutorialAudio.volume = 0.4f;
	}

	
	// Update is called once per frame
	public void Pressed ()
	{
		
		//Debug.Log ("Playing Random Sound and setting Color!");
		int clipPicked = Random.Range (0, clips.Length);
		randomClip = clips [clipPicked];
		tutorialAudio.clip = randomClip;
		tutorialAudio.Play ();
		int colorPicked = Random.Range (0, colors.Length);
		randomColor = colors [colorPicked];
		thisImage.color = randomColor;

	}
}
