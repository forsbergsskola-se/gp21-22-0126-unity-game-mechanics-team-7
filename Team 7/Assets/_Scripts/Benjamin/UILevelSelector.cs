using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelector : MonoBehaviour {
	
	string masterBusString = "Bus:/";
	FMOD.Studio.Bus masterBus;

	private void Awake() {
		FMODUnity.RuntimeManager.GetBus("Bus:/").setVolume(100);
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
