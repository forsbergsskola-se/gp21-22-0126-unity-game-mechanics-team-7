using UnityEngine;

public class GroundChecker : MonoBehaviour {

	public bool IsGrounded { get; private set; }
	[SerializeField] private float groundCheckRadius = 0.5f;
	[SerializeField] private float groundCheckLength = 1f;
	[SerializeField] private LayerMask groundLayers;
	private void Update() => CheckIfGrounded();
	private void CheckIfGrounded() {
		var ray = new Ray(transform.position, Vector3.down);
		IsGrounded = Physics.SphereCast(ray, groundCheckRadius, groundCheckLength, groundLayers);
	}

	private void OnDrawGizmos() {
		Gizmos.DrawSphere(transform.position + Vector3.down * groundCheckLength, groundCheckRadius);
	}
}
