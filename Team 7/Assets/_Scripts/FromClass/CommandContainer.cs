using UnityEngine;

// Contains generic commands for both player AND NPCs
public class CommandContainer : MonoBehaviour {

	//Moving
	public float walkCommand;
	//Flying
	public float flyCommand;
	public float flyRotateCommand;
	//Jumping
	public bool jumpCommand;
	public bool jumpCommandDown;
	public bool jumpCommandUp;
	//Hovering
	public bool hoverCommand;
	//Teleporting
	public bool teleportBehindTargetCommand;
	public bool chargedTeleportCommand;
}
