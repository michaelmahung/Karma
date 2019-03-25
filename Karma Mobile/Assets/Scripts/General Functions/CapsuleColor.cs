using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleColor : MonoBehaviour {

	public SpriteRenderer thisColor;

	void Start ()
	{
		thisColor = GetComponent<SpriteRenderer> ();
	}

	void Update () {

		thisColor.color = PlayerHealth.playerColor.color;
		
	}
}
