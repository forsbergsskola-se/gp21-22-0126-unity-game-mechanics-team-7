using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToSwimSwitch : MonoBehaviour {
	[SerializeField] GameObject Seafloor;
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.GetComponent<FlightContollerBT>().enabled = false;
			other.GetComponent<HoverControllerBT>().enabled = false;
			other.GetComponent<Rigidbody>().useGravity = true;
			Seafloor.SetActive(true);
		}
	}
}
