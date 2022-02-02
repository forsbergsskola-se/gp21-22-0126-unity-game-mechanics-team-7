using System;
using UnityEngine;

public class FlightContollerBT : MonoBehaviour {
	
	[SerializeField] private float enginePower;
	[SerializeField] private float rotationForce;
	private CommandContainer commandContainer;
	private new Rigidbody rigidbody;
	private bool isHovering = false;
	private Vector3 angleVeloctiy;
	private Animator anim;

	private void Start() {
		rigidbody = GetComponent<Rigidbody>();
		commandContainer = GetComponentInChildren<CommandContainer>();
		anim = GetComponentInChildren<Animator>();
	}
	private void Update() {
		MoveVertically();
		HoverSelector();
	}
	private void HoverSelector() {
		// Switches the flight mode from basic flight to hover when space is pressed.
		if (commandContainer.hoverCommandOn) {
			rigidbody.velocity = Vector3.zero;
			rigidbody.useGravity = false;
			isHovering = true;
		}
		else if (commandContainer.hoverCommandOff) {
			rigidbody.useGravity = true;
			isHovering = false;
		}
		
		if (isHovering) {
			// Hover movement.
			rigidbody.velocity = new Vector3(commandContainer.walkCommand * 5, 0, 0);
			// Plays flying animation.
			anim.SetBool("jump", true);
		}
		else {
			Rotate();
		}
	}
	private void Rotate() {
		// Rotates player using rigidbody
		angleVeloctiy = new Vector3(0, 0, rotationForce * -commandContainer.flyRotateCommand);
		Quaternion deltaRotation = Quaternion.Euler(angleVeloctiy * Time.deltaTime);
		rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
	}
	private void MoveVertically() {
		// Moves player up in the air.
		if (isHovering)
			return;
		rigidbody.AddForce(transform.up * Mathf.Clamp(commandContainer.flyCommand, 0, 1) * enginePower * Time.deltaTime);
		if (commandContainer.flyCommand > 0) {
			// Plays flying animation.
			anim.SetBool("jump", true);
		}
	}
}
