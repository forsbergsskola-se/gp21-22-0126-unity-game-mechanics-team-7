using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterContollerBT : MonoBehaviour {

	public new Rigidbody rigidbody;
	[SerializeField] private float enginePower;
	[SerializeField] private float rotationForce;
	private void Update() {
		rigidbody.AddForce(transform.up * enginePower * Input.GetAxis("Vertical") * Time.deltaTime);
		transform.Rotate(Vector3.back * rotationForce * Input.GetAxis("Horizontal") * Time.deltaTime);
	}
}
