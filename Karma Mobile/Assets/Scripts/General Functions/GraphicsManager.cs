using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsManager : MonoBehaviour {

	public RawImage pauseImage;
	public RawImage playImage;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (!ArrowKeyMovement.paused) {
			pauseImage.enabled = true;
			playImage.enabled = false;
		} else 
		{
			playImage.enabled = true;
			pauseImage.enabled = false;
		}
		
	}
}
