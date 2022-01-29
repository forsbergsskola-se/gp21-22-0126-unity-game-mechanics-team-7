using UnityEngine;

public class HelicopterContollerBT : MonoBehaviour {

	public new Rigidbody rigidbody;
	private bool isHovering;
	[SerializeField] private float enginePower;
	[SerializeField] private float rotationForce;
	private void Update() {
		VerticalMovement();
		Rotation();

		if (Input.GetKeyDown(KeyCode.Space) && !isHovering) {
			rigidbody.velocity = Vector3.zero;
			rigidbody.useGravity = false;
			isHovering = true;
		}
		else if(Input.GetKeyDown(KeyCode.Space) && isHovering) {
			rigidbody.useGravity = true;
			isHovering = false;
		}
	}
	private void Rotation() {
		transform.Rotate(Vector3.back * rotationForce * Input.GetAxis("Horizontal") * Time.deltaTime);
	}
	private void VerticalMovement() {
		if (!isHovering) {
			rigidbody.AddForce(transform.up * enginePower * Mathf.Clamp(Input.GetAxis("Vertical") * Time.deltaTime, 0, 1.5f));
		}
	}
}
