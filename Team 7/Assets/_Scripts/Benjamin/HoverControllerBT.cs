using System;
using UnityEngine;

public class HoverControllerBT : MonoBehaviour {
	
	[SerializeField] private float enginePower;
	[SerializeField] private float rotationForce;
	private CommandContainer commandContainer;
	private new Rigidbody rigidbody;
	public bool isHovering = false;
	private Animator anim;
	private GroundChecker groundChecker;

	private void Start() {
		rigidbody = GetComponent<Rigidbody>();
		groundChecker = GetComponent<GroundChecker>();
		commandContainer = GetComponentInChildren<CommandContainer>();
		anim = GetComponentInChildren<Animator>();
	}
	private void Update() {
		HoverSelector();
	}
	private void HoverSelector() {
		// Switches the flight mode from basic flight to hover when space is pressed.
		if (commandContainer.hoverCommandOn && !groundChecker.IsGrounded) {
			rigidbody.velocity = Vector3.zero;
			rigidbody.useGravity = false;
			isHovering = true;
		}
		else if (commandContainer.hoverCommandOff) {
			rigidbody.useGravity = true;
			isHovering = false;
		}

		if (!isHovering)
			return;
		// Hover movement.
		rigidbody.rotation = Quaternion.identity;
		rigidbody.velocity = new Vector3(commandContainer.walkCommand * 5, 0, 0);
		// Plays flying animation.
		anim.SetBool("jump", true);

	}
}
