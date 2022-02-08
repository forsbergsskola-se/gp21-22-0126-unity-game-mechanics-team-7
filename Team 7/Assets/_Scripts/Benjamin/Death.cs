using System;
using UnityEngine;

public class Death : MonoBehaviour {
	
	public bool isDead;
	private bool isShown;
	private Rigidbody rigidbody;
	[SerializeField] private GameObject brokenHeart;
	[SerializeField] private GameObject deathMessage;
	
	private void FixedUpdate() {
		Kill();
	}
	private void Kill() {
		if (isDead) {
			transform.Translate(0, -20 * Time.deltaTime, -30 * Time.deltaTime);
			deathMessage.SetActive(true);
			if (!isShown) {
				// GetComponentInChildren<CommandContainer>().enabled = false;
				Instantiate(brokenHeart, transform.position, Quaternion.identity);
				isShown = true;
			}
		}
		else {
			deathMessage.SetActive(false);
		}
	}
}
