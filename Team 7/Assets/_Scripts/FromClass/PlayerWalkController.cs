using UnityEngine;

public class PlayerWalkController : MonoBehaviour {
	
	[SerializeField] private float moveSpeed;
	private CommandContainer commandContainer;
	private new Rigidbody rigidbody;
	Animator anim;

	bool isLookingRight = true;

	private void Start() {
		rigidbody = GetComponent<Rigidbody>();
		commandContainer = GetComponentInChildren<CommandContainer>();
		anim = GetComponentInChildren<Animator>();
	}
	private void Update() => HandleWalking();
	private void HandleWalking() {
		rigidbody.velocity = new Vector3(commandContainer.walkCommand * moveSpeed, rigidbody.velocity.y, 0);
		if (commandContainer.walkCommand > 0 && !isLookingRight){
			transform.Rotate(0,180,0);
			isLookingRight = true;
		}
		else if (commandContainer.walkCommand < 0 && isLookingRight){
			transform.Rotate(0,180,0);
			isLookingRight = false;
		}
		// Sets animation to walk only when moving.
		anim.SetInteger("Walk", rigidbody.velocity.x != 0 ? 1 : 0);
	}
}
