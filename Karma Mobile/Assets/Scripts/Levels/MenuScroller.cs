using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScroller : MonoBehaviour {

	public float scrollSpeed;
	public Scene thisScene;

	void Start ()
	{
		thisScene = SceneManager.GetActiveScene ();
	}

	void Update () {

		if (thisScene.name == "Main Menu") {
			scrollSpeed = 0.1f;
		}

		if (thisScene.name == "Game") {
			scrollSpeed = (FallingScript.regSpeed * 1.5f);
		}

		Vector2 offset = new Vector2 (0, Time.time * scrollSpeed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;

		
	}
}
