using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {
	private CommandContainer commandContainer;
	private float walkInput;
	private float flyInput;
	private float flyRotate;
	private bool jumpInputDown;
	private bool jumpInputUp;
	private bool jumpInput;

	private void Start() {
		commandContainer = GetComponent<CommandContainer>();
	}
	private void Update() {
		GetInput();
		SetCommands();
	}
	private void GetInput() {
		walkInput = Input.GetAxis("Horizontal");
		jumpInputDown = Input.GetButtonDown("Jump");
		jumpInputUp = Input.GetButtonUp("Jump");
		jumpInput = Input.GetButton("Jump");
		flyInput = Input.GetAxis("Vertical");
		flyRotate = Input.GetAxis("Horizontal");
	}

	private void SetCommands() {
		commandContainer.walkCommand = walkInput;
		commandContainer.jumpCommandDown = jumpInputDown;
		commandContainer.jumpCommandUp = jumpInputUp;
		commandContainer.jumpCommand = jumpInput;
		commandContainer.flyCommand = flyInput;
		commandContainer.flyRotateCommand = flyRotate;
	}
}
