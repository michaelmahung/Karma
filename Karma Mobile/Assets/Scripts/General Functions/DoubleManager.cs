using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleManager : MonoBehaviour {

	public Animator doubleAnim;
	public GameObject doubleHolder;
	public bool doubleOut;
	public bool doubleChecker;
	public bool dMult;


	// Use this for initialization
	void Start () {
		dMult = false;
		doubleHolder.SetActive (true);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (dMult) {
			ScoreManager.doubleMult = 2;
		} else {
			ScoreManager.doubleMult = 1;
		}

		doubleChecker = PlayerMovement.doubledLanes;

		if (HorizontalSpawner.horiSpawning && !doubleOut && !PlayerHealth.isDead) {
			doubleHolder.SetActive (true);
			StartCoroutine (doubleActivator ());
		}

		if (!HorizontalSpawner.horiSpawning && doubleOut && !PlayerHealth.isDead) {
			StopCoroutine (doubleActivator ());
			StartCoroutine (doubleDeactivate ());
		}

		if (PlayerHealth.isDead && doubleOut) {
			StopCoroutine (doubleActivator ());
			StopCoroutine (doubleDeactivate ());
			doubleOut = false;
			doubleAnim.Play ("Double Out Anim");
			if (PlayerMovement.player.transform.position == PlayerMovement.left2Position) {
				PlayerMovement.player.transform.position = PlayerMovement.leftPosition;
			}

			if (PlayerMovement.player.transform.position == PlayerMovement.middle2Position) {
				PlayerMovement.player.transform.position = PlayerMovement.middlePosition;
			}

			if (PlayerMovement.player.transform.position == PlayerMovement.right2Position) {
				PlayerMovement.player.transform.position = PlayerMovement.rightPosition;
			}
		}
		
	}

	IEnumerator doubleActivator ()
	{
		dMult = true;
		doubleOut = true;
		doubleAnim.Play ("Double In Anim");
		StopCoroutine (doubleActivator ());
		yield break;
	}

	IEnumerator doubleDeactivate ()
	{
		doubleOut = false;
		yield return new WaitForSeconds (2.5f);
		dMult = false;
		if (!doubleOut) {
			doubleAnim.Play ("Double Out Anim");
			if (PlayerMovement.player.transform.position == PlayerMovement.left2Position) {
				PlayerMovement.player.transform.position = PlayerMovement.leftPosition;
			}

			if (PlayerMovement.player.transform.position == PlayerMovement.middle2Position) {
				PlayerMovement.player.transform.position = PlayerMovement.middlePosition;
			}

			if (PlayerMovement.player.transform.position == PlayerMovement.right2Position) {
				PlayerMovement.player.transform.position = PlayerMovement.rightPosition;
			}
		} else {
		}
		StopCoroutine (doubleDeactivate ());
		yield break;
	}
}
