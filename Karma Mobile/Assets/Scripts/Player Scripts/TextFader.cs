using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFader : MonoBehaviour {

	float duration = 1.5f;
	float ratio = 0;

	void Start ()
	{
		StartCoroutine (imDead());
	}

	void Update () {

		TextMesh textMesh;

		textMesh = GetComponent<TextMesh> ();

		Color myColor = textMesh.color;
		ratio += 0.04f;
		transform.localPosition += new Vector3 (0, 0.01f, 0);
		myColor.a = Mathf.Lerp (1, 0, ratio);
		textMesh.color = myColor;
	}

	IEnumerator imDead ()
	{
		yield return new WaitForSeconds (duration);
		Destroy (gameObject);
	}
}
