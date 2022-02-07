using System.Collections;
using FMOD.Studio;
using UnityEngine;

public class FlightContollerBT : MonoBehaviour {
	
	[SerializeField] private float enginePower;
	[SerializeField] private float rotationForce;
	private HoverControllerBT hoverControllerBT;
	private CommandContainer commandContainer;
	private new Rigidbody rigidbody;
	private Vector3 angleVeloctiy;
	private Animator anim;
	
	private EventInstance instance;
	[SerializeField] private FMODUnity.EventReference fmodEvent;

	private void Start() {
		rigidbody = GetComponent<Rigidbody>();
		commandContainer = GetComponentInChildren<CommandContainer>();
		anim = GetComponentInChildren<Animator>();
		hoverControllerBT = GetComponent<HoverControllerBT>();
		
		instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
		instance.start();
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
		var force = Mathf.Abs(commandContainer.flyCommand) * enginePower * Time.deltaTime;
		rigidbody.AddForce(transform.up * force);
		if (commandContainer.flyCommand > 0) {
			// Plays flying animation.
			anim.SetBool("jump", true);
			PlaySound(commandContainer.flyCommand);
			Debug.Log(commandContainer.flyCommand);
		}
	}
	private void PlaySound(float force) {
		instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
		instance.setParameterByName("velosty",force * 100);
	}
}
