using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour {

	public Camera shakeCamera;
	public static float shake;
	public float shakeAmount;
	public float decreaseFactor;
	public Vector3 startPosition;


	void LateUpdate ()
	{
		if (shake > 0) {
			shakeCamera.transform.localPosition = Random.insideUnitCircle * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
		} else {
			shake = 0.0f;
			shakeCamera.transform.localPosition = startPosition;
		}

		if (PlayerHealth.oneShot) {
			shake = 2.5f;
		}

		if (PlayerHealth.corrupt) {
			shake = 2.5f;
		}

		if (PlayerHealth.murdered) {
			shake = 2.5f;
		}

		if (PlayerHealth.damaged) {
			shake = 0.5f;
		}

		if (PlayerHealth.healing) {
			shake = 0;
		}


	}
}
