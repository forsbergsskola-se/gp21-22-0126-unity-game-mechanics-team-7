using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelector : MonoBehaviour {
	
	private void Awake() {
		FMODUnity.RuntimeManager.GetBus("Bus:/").setVolume(1);
	}
	public void LoadScene1() {
		FMODUnity.RuntimeManager.GetBus("Bus:/").setVolume(0);
		SceneManager.LoadScene(1);
	}
	
	public void LoadScene2() {
		FMODUnity.RuntimeManager.GetBus("Bus:/").setVolume(0);
		SceneManager.LoadScene(2);
	}
}
