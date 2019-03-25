using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	// Use this for initialization

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Destroyer") {
			Destroy (gameObject);
		}
			
	}

}
