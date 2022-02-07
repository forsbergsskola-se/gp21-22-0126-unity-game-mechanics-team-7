using UnityEngine;

public class PlayerImmediateJumpController : MonoBehaviour {
    
    [SerializeField] private float jumpForce;
    private GroundChecker groundChecker;
    private CommandContainer commandContainer;
    private new Rigidbody rigidbody;
    private Animator anim;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        commandContainer = GetComponentInChildren<CommandContainer>();
        groundChecker = GetComponent<GroundChecker>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update() => HandleImmediateJump();
    private void HandleImmediateJump() {
        if (commandContainer.jumpCommandDown && groundChecker.IsGrounded) {
            rigidbody.AddForce(Vector3.up * jumpForce);
            anim.SetBool("jump", true);
        }
    }
}
