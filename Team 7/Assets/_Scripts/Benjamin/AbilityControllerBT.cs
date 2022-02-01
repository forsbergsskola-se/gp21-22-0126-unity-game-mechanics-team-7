using UnityEngine;


// Controls Abilities
public class AbilityControllerBT : MonoBehaviour {
	
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
		GetComponent<WalkController>().enabled = true;
	}
	private void DisableWalk() {
		GetComponent<WalkController>().enabled = false;
	}
	private void EnableJump() {
		GetComponent<PlayerChargeJumpController>().enabled = true;
	}
	private void DisableJump() {
		GetComponent<PlayerChargeJumpController>().enabled = false;
	}
	private void EnableFly() {
		GetComponent<FlightContollerBT>().enabled = true;
	}
	private void DisableFly() {
		GetComponent<FlightContollerBT>().enabled = false;
	}
}
