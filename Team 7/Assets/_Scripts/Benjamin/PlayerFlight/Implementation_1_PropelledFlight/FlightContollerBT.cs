using System.Collections;
using UnityEngine;

public class FlightContollerBT : MonoBehaviour {
	
	[SerializeField] private float enginePower;
	[SerializeField] private float rotationForce;
	private HoverControllerBT hoverControllerBT;
	private CommandContainer commandContainer;
	private new Rigidbody rigidbody;
	private Vector3 angleVeloctiy;
	private Animator anim;
	private bool canPlay = true;

	private void Start() {
		rigidbody = GetComponent<Rigidbody>();
		commandContainer = GetComponentInChildren<CommandContainer>();
		anim = GetComponentInChildren<Animator>();
		hoverControllerBT = GetComponent<HoverControllerBT>();
	}
	private void Update() {
		MoveVertically();
		Rotate();
	}
	private void Rotate() {
		// Rotates player using rigidbody
		if (hoverControllerBT.isHovering)
			return;
		angleVeloctiy = new Vector3(0, 0, rotationForce * -commandContainer.flyRotateCommand);
		Quaternion deltaRotation = Quaternion.Euler(angleVeloctiy * Time.deltaTime);
		rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
	}
	private void MoveVertically() {
		// Moves player up in the air.
		if (hoverControllerBT.isHovering)
			return;
		rigidbody.AddForce(transform.up * Mathf.Abs(commandContainer.flyCommand) * enginePower * Time.deltaTime);
		if (commandContainer.flyCommand > 0) {
			// Plays flying animation.
			anim.SetBool("jump", true);
			PlaySound();
		}
	}
	private void PlaySound() {
		if (canPlay) {
			FMODUnity.RuntimeManager.PlayOneShot("event:/ENVIRONMENT/PenguinGreeting");
			canPlay = false;
			StartCoroutine(Wait());
		}
	}
	private IEnumerator Wait() {
		yield return new WaitForSeconds(3);
		canPlay = true;
	}
}
