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
	public bool hoverCommandOn;
	public bool hoverCommandOff;
	
	//Teleporting
	public bool teleportBehindTargetCommand;
	public bool chargedTeleportCommand;
	public bool chargedTeleportDownCommand;
	public bool chargedTeleportUpCommand;
	
	//Swimming
	public float swimCommandHorizontal;
	public float swimCommandVertical;
}
