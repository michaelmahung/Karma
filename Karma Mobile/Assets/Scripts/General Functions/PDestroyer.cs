using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDestroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Coin") {
			Destroy (other.gameObject);
		}

	}
}
