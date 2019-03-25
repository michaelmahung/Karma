using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour {

	public RawImage heart1;
	public RawImage heart2;
	public RawImage heart3;
	public RawImage heartDed1;
	public RawImage heartDed2;
	public RawImage heartDed3;
	public RawImage halfHeart1;
	public RawImage halfHeart2;
	public RawImage halfHeart3;
	
	// Update is called once per frame
	void Update () {


		if (sceneManager.heartsLeft > 3)
		{
			sceneManager.heartsLeft = 3;
		}

		if (sceneManager.heartsLeft == 3) 
		{
			heart1.enabled = true;
			heart2.enabled = true;
			heart3.enabled = true;
			heartDed1.enabled = false;
			heartDed2.enabled = false;
			heartDed3.enabled = false;
			halfHeart1.enabled = false;
			halfHeart2.enabled = false;
			halfHeart3.enabled = false;
		}

		if (sceneManager.heartsLeft == 2.5f) 
		{
			heart1.enabled = false;
			heart2.enabled = true;
			heart3.enabled = true;
			heartDed1.enabled = true;
			heartDed2.enabled = false;
			heartDed3.enabled = false;
			halfHeart1.enabled = true;
			halfHeart2.enabled = false;
			halfHeart3.enabled = false;
		}

		if (sceneManager.heartsLeft == 2) 
		{
			heart1.enabled = false;
			heart2.enabled = true;
			heart3.enabled = true;
			heartDed1.enabled = true;
			heartDed2.enabled = false;
			heartDed3.enabled = false;
			halfHeart1.enabled = false;
			halfHeart2.enabled = false;
			halfHeart3.enabled = false;
		}

		if (sceneManager.heartsLeft == 1.5f) 
		{
			heart1.enabled = false;
			heart2.enabled = false;
			heart3.enabled = true;
			heartDed1.enabled = true;
			heartDed2.enabled = true;
			heartDed3.enabled = false;
			halfHeart1.enabled = false;
			halfHeart2.enabled = true;
			halfHeart3.enabled = false;
		}

		if (sceneManager.heartsLeft == 1) 
		{
			heart1.enabled = false;
			heart2.enabled = false;
			heart3.enabled = true;
			heartDed1.enabled = true;
			heartDed2.enabled = true;
			heartDed3.enabled = false;
			halfHeart1.enabled = false;
			halfHeart2.enabled = false;
			halfHeart3.enabled = false;
		}

		if (sceneManager.heartsLeft == 0.5f) 
		{
			heart1.enabled = false;
			heart2.enabled = false;
			heart3.enabled = false;
			heartDed1.enabled = true;
			heartDed2.enabled = true;
			heartDed3.enabled = true;
			halfHeart1.enabled = false;
			halfHeart2.enabled = false;
			halfHeart3.enabled = true;
		}

		if (sceneManager.heartsLeft <= 0) 
		{
			heart1.enabled = false;
			heart2.enabled = false;
			heart3.enabled = false;
			heartDed1.enabled = true;
			heartDed2.enabled = true;
			heartDed3.enabled = true;
			halfHeart1.enabled = false;
			halfHeart2.enabled = false;
			halfHeart3.enabled = false;
		}
		
	}
}
