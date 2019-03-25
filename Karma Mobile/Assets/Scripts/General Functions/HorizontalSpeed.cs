using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpeed : MonoBehaviour {

	public static float outSpeed;
	public static float outDir;
	public float outDir2;

	// Use this for initialization
	void Start () {
		outSpeed = FallingScript.fallSpeed * 0.75f;
		outDir2 = outDir;
		StartCoroutine (DestroyMe ());
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3 (outDir2, 0, 0) * outSpeed;
		
	}

	IEnumerator DestroyMe ()
	{
		yield return new WaitForSeconds (6);
		Destroy (gameObject);
	}
}
