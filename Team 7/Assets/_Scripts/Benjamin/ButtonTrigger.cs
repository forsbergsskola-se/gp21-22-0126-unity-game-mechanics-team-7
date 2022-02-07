using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

	[SerializeField] private GameObject button;
	public bool buttonTriggered;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			button.SetActive(false);
			buttonTriggered = true;
			FMODUnity.RuntimeManager.PlayOneShot("event:/ITEMS/PressurePad");
		}	
	}
	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			button.SetActive(true);
			buttonTriggered = false;
			FMODUnity.RuntimeManager.PlayOneShot("event:/ITEMS/PressurePad");
		}
	}
}
