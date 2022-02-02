using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {

	private CommandContainer commandContainer;
	private float flyInput;
	private float flyRotateInput;
	private bool hoverInputOn;
	private bool hoverInputOff;

	private float swimVerticalInput;
	private float swimHorizontalInput;
	
	private float walkInput;
	private bool jumpInputDown;
	private bool jumpInputUp;
	private bool jumpInput;
	
	private bool teleportBehindTargetInput;
	private bool chargedTeleportInput;
	private bool chargedTeleportDownInput;
	private bool chargedTeleportUpInput;

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
		hoverInputOn = Input.GetButtonDown("Jump");
		hoverInputOff = Input.GetButtonUp("Jump");
		
		//Teleportation
		teleportBehindTargetInput = Input.GetKey(KeyCode.E);
		chargedTeleportInput = Input.GetKey(KeyCode.LeftShift);
		chargedTeleportDownInput = Input.GetKeyDown(KeyCode.LeftShift);
		chargedTeleportUpInput = Input.GetKeyUp(KeyCode.LeftShift);
		
		//Swimming
		swimHorizontalInput = Input.GetAxis("Horizontal");
		swimVerticalInput = Input.GetAxis("Vertical");
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
		commandContainer.hoverCommandOn = hoverInputOn;
		commandContainer.hoverCommandOff = hoverInputOff;
		
		//Teleportation
		commandContainer.teleportBehindTargetCommand = teleportBehindTargetInput;
		commandContainer.chargedTeleportCommand = chargedTeleportInput;
		commandContainer.chargedTeleportDownCommand = chargedTeleportDownInput;
		commandContainer.chargedTeleportUpCommand = chargedTeleportUpInput;
		
		
		//Swimming
		commandContainer.swimCommandHorizontal = swimHorizontalInput;
		commandContainer.swimCommandVertical = swimVerticalInput;
	}
}
