using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {

	public GameObject [] list1;
	public GameObject [] list2;
	public GameObject [] list3;
	public GameObject [] list4;
	public GameObject [] list5;
	public Vector3[] menuLocations;
	public float menuWait;
	public GameObject [] currentSpawns;


	// Use this for initialization
	void Start () {

		StartCoroutine (menuSpawner ());
		
	}
	
	// Update is called once per frame
	void Update () {

		if (MenuMusic.winnerChanges < 2) {
			FallingScript.menuSpeed = 0.065f;
			currentSpawns = list1;
			menuWait = 8;
		}

		if (MenuMusic.winnerChanges == 2 || MenuMusic.winnerChanges == 3) {
			FallingScript.menuSpeed = 0.065f;
			currentSpawns = list2;
			menuWait = 7;
		}

		if (MenuMusic.winnerChanges == 4 || MenuMusic.winnerChanges == 5) {
			FallingScript.menuSpeed = 0.065f;
			currentSpawns = list3;
			menuWait = 6;
		}

		if (MenuMusic.winnerChanges == 6 || MenuMusic.winnerChanges == 7) {
			FallingScript.menuSpeed = 0.065f;
			currentSpawns = list4;
			menuWait = 5;
		}

		if (MenuMusic.winnerChanges == 8) {
			FallingScript.menuSpeed = 0.065f;
			currentSpawns = list5;
			menuWait = 4;
		}
		
	}

	public void spawnMenu()
	{
		transform.position = menuLocations [Random.Range (0, menuLocations.Length)];
		int s = Random.Range (0, currentSpawns.Length);

		Instantiate (currentSpawns [s],
			transform.position,
			Quaternion.identity);
	}

	IEnumerator menuSpawner ()
	{
		yield return new WaitForSeconds (menuWait);
		spawnMenu ();
		StartCoroutine (menuSpawner());
	}
}
