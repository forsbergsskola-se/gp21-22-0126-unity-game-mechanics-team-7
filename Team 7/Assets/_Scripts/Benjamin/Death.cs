using UnityEngine;

public class Death : MonoBehaviour {
	
	public bool isDead;
	private bool isShown;
	[SerializeField] private GameObject brokenHeart;
	[SerializeField] private GameObject deathMessage;
	private void FixedUpdate() {
		Kill();
	}
	private void Kill() {
		if (isDead) {
			transform.Translate(0, 2 * Time.deltaTime, -10 * Time.deltaTime);
			deathMessage.SetActive(true);
			if (!isShown) {
				GetComponentInChildren<PlayerInputController>().enabled = false;
				Instantiate(brokenHeart, transform.position, Quaternion.identity);
				isShown = true;
			}
		}
		else {
			deathMessage.SetActive(false);
		}
	}
}
