using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	[SerializeField] private GameObject button;
	[SerializeField] private GameObject door;

	private void Start() {
	}
	private void Update() {
		if (button.gameObject.GetComponent<ButtonTrigger>().buttonTriggered) {
			door.gameObject.SetActive(false);
		}
		else {
			door.gameObject.SetActive(true);
		}
	}
}
