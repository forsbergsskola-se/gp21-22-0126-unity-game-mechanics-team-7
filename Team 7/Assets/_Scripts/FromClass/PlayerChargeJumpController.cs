using UnityEngine;

public class PlayerChargeJumpController : MonoBehaviour
{
    [SerializeField] private float minimumJumpForce;
    [SerializeField] private float maximumJumpForce;
    [SerializeField] private float chargeTime;

    private float jumpCharge;
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
    private void Update() => HandleChargeJump();
    // Increases jump charge after time.
    private void HandleChargeJump() {
        if (commandContainer.jumpCommand && groundChecker.IsGrounded) {
            jumpCharge += Time.deltaTime / chargeTime;
        }
        // Releases jump and related charge stored.
        if (commandContainer.jumpCommandUp && groundChecker.IsGrounded) {
            var jumpForce = Mathf.Lerp(minimumJumpForce, maximumJumpForce, jumpCharge);
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumpCharge = 0f;
            // Plays jump animation.
            anim.SetBool("jump", true);
        }
    }
}
