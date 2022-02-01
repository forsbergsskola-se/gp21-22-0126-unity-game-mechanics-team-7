using UnityEngine;

public class WalkController : MonoBehaviour {
	
	[SerializeField] private float moveSpeed;
	private CommandContainer commandContainer;
	private new Rigidbody rigidbody;
	private Animator anim;

	private bool isLookingRight = true;

	private void Start() {
		rigidbody = GetComponent<Rigidbody>();
		commandContainer = GetComponentInChildren<CommandContainer>();
		anim = GetComponentInChildren<Animator>();
	}
	private void Update() => HandleWalking();
	private void HandleWalking() {
		rigidbody.velocity = new Vector3(commandContainer.walkCommand * moveSpeed, rigidbody.velocity.y, 0);
		RotateWhenMoving();
		// Sets animation to walk only when moving.
		anim.SetInteger("Walk", rigidbody.velocity.x != 0 ? 1 : 0);
	}

	void RotateWhenMoving(){
		if (commandContainer.walkCommand > 0 ){
			transform.rotation = new Quaternion(0, 0, 0, 0);
		}
		else if (commandContainer.walkCommand < 0){
			transform.rotation = new Quaternion(0, 180, 0, 0);
		}
	}
}
