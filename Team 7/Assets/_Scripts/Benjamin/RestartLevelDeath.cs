using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelDeath : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("KillableNPC")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
