using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelector : MonoBehaviour {
	
	public void LoadScene1() {
		SceneManager.LoadScene(1);
	}
	
	public void LoadScene2() {
		SceneManager.LoadScene(2);
	}
}
