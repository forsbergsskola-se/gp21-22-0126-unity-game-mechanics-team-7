using System;
using UnityEngine;

public class HelicopterContollerBT : MonoBehaviour {
	
	[SerializeField] private float enginePower;
	[SerializeField] private float rotationForce;
	private CommandContainer commandContainer;
	private new Rigidbody rigidbody;
	private bool isHovering;

	private void Start() {
		rigidbody = GetComponent<Rigidbody>();
		commandContainer = GetComponentInChildren<CommandContainer>();
	}
	private void FixedUpdate() {
		VerticalMovement();
		Rotation();

		if (Input.GetKeyDown(KeyCode.Space) && !isHovering) {
			rigidbody.velocity = Vector3.zero;
			rigidbody.useGravity = false;
			isHovering = true;
		}
		else if(Input.GetKeyDown(KeyCode.Space) && isHovering) {
			rigidbody.useGravity = true;
			isHovering = false;
		}
	}
	private void Rotation() {
		transform.Rotate(Vector3.back * commandContainer.flyRotateCommand * rotationForce * Time.deltaTime);
	}
	private void VerticalMovement() {
		if (!isHovering) {
			rigidbody.AddForce(transform.up * commandContainer.flyCommand * enginePower * Time.deltaTime);
		}
	}
}
