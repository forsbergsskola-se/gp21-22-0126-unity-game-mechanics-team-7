using UnityEngine;

public class HelicopterContollerBT : MonoBehaviour {

	public new Rigidbody rigidbody;
	[SerializeField] private float enginePower;
	[SerializeField] private float rotationForce;
	private void Update() {
		rigidbody.AddForce(transform.up * enginePower * Mathf.Clamp(Input.GetAxis("Vertical") * Time.deltaTime, 0, 1.5f));
		Debug.Log(transform.up * enginePower * Input.GetAxis("Vertical") * Time.deltaTime);
		transform.Rotate(Vector3.back * rotationForce * Input.GetAxis("Horizontal") * Time.deltaTime);
	}
}
