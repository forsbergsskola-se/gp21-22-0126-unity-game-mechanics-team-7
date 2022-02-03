using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimSwitch : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.GetComponent<SwimController>().enabled = true;
		}
	}
}
