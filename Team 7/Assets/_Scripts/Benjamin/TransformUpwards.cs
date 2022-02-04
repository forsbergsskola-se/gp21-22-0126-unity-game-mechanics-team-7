using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformUpwards : MonoBehaviour {
	private void FixedUpdate() {
		transform.Translate(Vector3.up * 5 * Time.deltaTime); 
	}

}
