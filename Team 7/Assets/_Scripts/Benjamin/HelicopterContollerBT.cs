using System;
using UnityEngine;

public class HelicopterContollerBT : MonoBehaviour {
	
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

		switch (commandContainer.hoverCommand) {
			case true when !isHovering:
				rigidbody.velocity = Vector3.zero;
				rigidbody.useGravity = false;
				isHovering = true;
				break;
			case true when isHovering:
				rigidbody.useGravity = true;
				isHovering = false;
				break;
		}
		if (isHovering) {
			rigidbody.velocity = new Vector3(commandContainer.walkCommand * 5, 0, 0);
			anim.SetBool("jump", true);
		}
		else {
			Rotate();
		}
	}
	private void Rotate() {
		angleVeloctiy = new Vector3(0, 0, rotationForce * -commandContainer.flyRotateCommand);
		Quaternion deltaRoation = Quaternion.Euler(angleVeloctiy * Time.deltaTime);
		rigidbody.MoveRotation(rigidbody.rotation * deltaRoation);
		// transform.Rotate(Vector3.back * commandContainer.flyRotateCommand * rotationForce * Time.deltaTime);
	}
	private void MoveVertically() {
		if (!isHovering) {
			rigidbody.AddForce(transform.up * Mathf.Clamp(commandContainer.flyCommand, 0, 1) * enginePower * Time.deltaTime);
			if (commandContainer.flyCommand > 0) {
				anim.SetBool("jump", true);
			}
		}
	}
}
