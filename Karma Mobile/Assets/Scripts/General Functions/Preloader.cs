using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour 
{
	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 3f; //Minimum time of the scene
	public AsyncOperation menuLoaded;

	private void Start()
	{
		menuLoaded = SceneManager.LoadSceneAsync ("Main Menu");
		menuLoaded.allowSceneActivation = false;

		fadeGroup = FindObjectOfType<CanvasGroup> ();

		fadeGroup.alpha = 1;

		//Preload game here

		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else
			loadTime = Time.time;
	}
		

	private void Update()
	{
		if (Time.time < minimumLogoTime) 
		{
			fadeGroup.alpha = 1 - Time.time;
		}
		if (Time.time > minimumLogoTime && loadTime != 0) 
		{
			fadeGroup.alpha = Time.time - minimumLogoTime;
			if (fadeGroup.alpha >= 1)
			{
				menuLoaded.allowSceneActivation = true;
			}
		}
	}
}

