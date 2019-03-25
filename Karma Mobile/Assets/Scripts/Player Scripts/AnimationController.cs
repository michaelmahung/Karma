using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	public Animator anim;
	public bool deathPlayed;

	// Use this for initialization
	void Start () {
		deathPlayed = false;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerHealth.isDead == (true) && !deathPlayed) {
			deathPlayed = true;
			anim.Play ("Death Anim");
		}
	}
}
