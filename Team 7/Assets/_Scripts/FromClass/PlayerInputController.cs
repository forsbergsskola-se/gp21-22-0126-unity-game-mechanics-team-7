using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {
	private CommandContainer commandContainer;
	private float walkInput;
	private float flyInput;
	private float flyRotateInput;
	private bool jumpInputDown;
	private bool jumpInputUp;
	private bool jumpInput;
	private bool hoverInput;
	 bool teleportBehindTargetInput;
	 bool chargedTeleportInput;
	 bool chargedTeleportUpInput;

	private void Start() {
		commandContainer = GetComponent<CommandContainer>();
	}
	private void Update() {
		GetInput();
		SetCommands();
	}
	private void GetInput() {
		//Movement
		walkInput = Input.GetAxis("Horizontal");
		//Jumping
		jumpInputDown = Input.GetButtonDown("Jump");
		jumpInputUp = Input.GetButtonUp("Jump");
		jumpInput = Input.GetButton("Jump");
		//Flying
		flyInput = Input.GetAxis("Vertical");
		flyRotateInput = Input.GetAxis("Horizontal");
		hoverInput = Input.GetButtonDown("Jump");
		//Teleportation
		teleportBehindTargetInput = Input.GetKey(KeyCode.E);
		chargedTeleportInput = Input.GetKey(KeyCode.LeftShift);
		chargedTeleportUpInput = Input.GetKeyUp(KeyCode.LeftShift);
	}

	private void SetCommands() {
		//Movement
		commandContainer.walkCommand = walkInput;
		//Jumpingc
		commandContainer.jumpCommandDown = jumpInputDown;
		commandContainer.jumpCommandUp = jumpInputUp;
		commandContainer.jumpCommand = jumpInput;
		//Flying
		commandContainer.flyCommand = flyInput;
		commandContainer.flyRotateCommand = flyRotateInput;
		commandContainer.hoverCommand = hoverInput;
		//Teleportation
		commandContainer.teleportBehindTargetCommand = teleportBehindTargetInput;
		commandContainer.chargedTeleportCommand = chargedTeleportInput;
		commandContainer.chargedTeleportUpCommand = chargedTeleportUpInput;
	}
}