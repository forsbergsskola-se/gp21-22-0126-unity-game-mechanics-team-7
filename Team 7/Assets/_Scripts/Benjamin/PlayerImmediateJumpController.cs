using UnityEngine;

public class PlayerImmediateJumpController : MonoBehaviour {
    
    [SerializeField] private float jumpForce;
    private GroundChecker groundChecker;
    private CommandContainer commandContainer;
    private new Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        commandContainer = GetComponentInChildren<CommandContainer>();
        groundChecker = GetComponent<GroundChecker>();
    }
    void Update() => HandleImmediateJump();
    private void HandleImmediateJump() {
        if (commandContainer.jumpCommandDown && groundChecker.IsGrounded) {
            rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
