using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelDeath : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			FMODUnity.RuntimeManager.GetBus("Bus:/").setVolume(0);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
