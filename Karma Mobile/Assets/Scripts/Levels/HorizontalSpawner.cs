using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpawner : MonoBehaviour {

	public Vector3 [] spawnPositions2;
	public GameObject[] horiSpawns;
	public static bool horiSpawning;
	public Vector3 posPicked;
	public static float spawnsLeft;
	public float warningWait;

	// Use this for initialization
	void Start () {

		spawnsLeft = 0;
		horiSpawning = false;
		posPicked = new Vector3 (11, -2.25f, 0);
		
	}
	
	// Update is called once per frame
	void Update () {

		warningWait = Spawner.waitTime * 6;

		if (spawnsLeft > 0 && !horiSpawning) 
		{
			horiSpawning = true;
			StartCoroutine (SpawnHori ());
		}

		if (spawnsLeft >= Powerups.horiMax) {
			spawnsLeft = Powerups.horiMax;
		}

		if (Spawner.healTime) {
			horiSpawning = false;
			spawnsLeft = 0;
		}
			
	}

	IEnumerator SpawnHori ()
	{
		if (spawnsLeft > 0) 
		{
			transform.position = spawnPositions2 [Random.Range (0, spawnPositions2.Length)];

			posPicked = transform.position;

			if (posPicked.x > 0) {
				HorizontalSpeed.outDir = -1;
			} else {

				if (posPicked.x < 0) {
					HorizontalSpeed.outDir = 1;
				}
			}

			Instantiate (horiSpawns [0],
			transform.position,
				Quaternion.identity);

			yield return new WaitForSeconds (warningWait);

			Instantiate (horiSpawns [1],
			transform.position,
			Quaternion.identity);

			spawnsLeft -=1;
			//Debug.Log ("Hori Spawns Left: " + spawnsLeft);

			if (spawnsLeft > 0) {

				yield return new WaitForSeconds (warningWait);
				StartCoroutine (SpawnHori ());
			} else {

				if (spawnsLeft <= 0) {
					horiSpawning = false;
					StopCoroutine (SpawnHori ());
				}
			}
		}
			
	}
}
