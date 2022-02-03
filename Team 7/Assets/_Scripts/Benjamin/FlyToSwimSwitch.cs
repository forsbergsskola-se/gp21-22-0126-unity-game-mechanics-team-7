using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToSwimSwitch : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
		GetComponent<FlightContollerBT>().enabled = false;
		GetComponent<HoverControllerBT>().enabled = false;
		GetComponent<SwimController>().enabled = true;
	}
}
