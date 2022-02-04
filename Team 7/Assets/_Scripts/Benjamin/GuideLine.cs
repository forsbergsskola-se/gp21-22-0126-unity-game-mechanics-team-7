using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLine : MonoBehaviour {
	[SerializeField] private GameObject button;
	[SerializeField] private GameObject color;
	private void Update() {
		if (button.gameObject.GetComponent<ButtonTrigger>().buttonTriggered) {
			color.gameObject.SetActive(false);
		}
		else {
			color.gameObject.SetActive(true);
		}
	}
}
