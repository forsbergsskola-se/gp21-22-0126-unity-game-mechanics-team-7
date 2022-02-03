using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelector : MonoBehaviour
{
	public void LoadScene1() {
		SceneManager.LoadScene(0);
	}
	
	public void LoadScene2() {
		SceneManager.LoadScene(1);
	}
}
