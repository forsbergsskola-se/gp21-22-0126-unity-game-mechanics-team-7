using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class WaterMusic : MonoBehaviour {

	[SerializeField] private SwimSwitch swim;
	[SerializeField] private FMODUnity.EventReference fmodEvent;
	private EventInstance instance;

	private void Start() {
		instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
		instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
		instance.start();
	}

	private void Update() {
		if (swim.inWater) {
			instance.setParameterByName("whter", 1);
		}
	}
}
