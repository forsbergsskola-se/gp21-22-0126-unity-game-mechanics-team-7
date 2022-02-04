using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
	
	public bool isDead;
	[SerializeField] private GameObject deathMessage;
	private void FixedUpdate() {
		if (isDead) {
			transform.Translate(0, 2 * Time.deltaTime, -10 * Time.deltaTime);
			deathMessage.SetActive(true);
		}
		else {
			deathMessage.SetActive(false);
		}
	}
}
