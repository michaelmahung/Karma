using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour {

	public SpriteRenderer iconColor;
	public GameObject player;
	public SpriteRenderer thisIcon;
	public float frameTime;
	public static float currentFrameTime;
	public Vector3 extraScale;

	void Start ()
	{
		/*leftIcon.SetActive (false);
		middleIcon.SetActive (false);
		rightIcon.SetActive (false);*/
		//frameTime = 
		iconColor = GetComponent<SpriteRenderer> ();
	}
		

	void Update () 
	{

		iconColor.transform.localScale = ArrowKeyMovement.currentScale + extraScale;

		currentFrameTime += Time.deltaTime;
		if (currentFrameTime > frameTime) {
			currentFrameTime = frameTime;
		}

		float perc = currentFrameTime / frameTime;

		iconColor.color = PlayerHealth.playerColor.color;
	
		if (player.transform.position == this.transform.parent.position && perc <= frameTime) {
			iconColor.enabled = true;
		} else {iconColor.enabled = false;
		}
	}
}
