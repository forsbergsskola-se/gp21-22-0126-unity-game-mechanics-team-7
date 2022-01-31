using UnityEngine;


// Controls Abilities
public class AbilityController : MonoBehaviour {
	
	private void Update() {
		// Enable Walk 
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			EnableWalk();
			EnableJump();
			DisableFly();
		}
		// Enable Fly
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			EnableFly();
			DisableWalk();
			DisableJump();
		}
	}

	private void EnableWalk() {
		GetComponent<PlayerWalkController>().enabled = true;
	}
	private void DisableWalk() {
		GetComponent<PlayerWalkController>().enabled = false;
	}
	private void EnableJump() {
		GetComponent<PlayerChargeJumpController>().enabled = true;
	}
	private void DisableJump() {
		GetComponent<PlayerChargeJumpController>().enabled = false;
	}
	private void EnableFly() {
		GetComponent<HelicopterContollerBT>().enabled = true;
	}
	private void DisableFly() {
		GetComponent<HelicopterContollerBT>().enabled = false;
	}
}
