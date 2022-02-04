using UnityEngine;

public class ChargeJump : MonoBehaviour
{
    [SerializeField] private float minimumJumpForce;
    [SerializeField] private float maximumJumpForce;
    [SerializeField] private float chargeTime;
    [SerializeField] private float maxTimeSinceGrounded;

    private float jumpCharge;
    private float timeSinceGrounded;
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
    private void HandleChargeJump(){
        timeSinceGrounded -= Time.deltaTime;
        if (groundChecker.IsGrounded){
            timeSinceGrounded = maxTimeSinceGrounded;
        }
        if (commandContainer.jumpCommand && timeSinceGrounded > 0) {
            jumpCharge += Time.deltaTime / chargeTime;
        }
        // Releases jump and related charge stored.
        if (commandContainer.jumpCommandUp && timeSinceGrounded > 0){
            timeSinceGrounded = 0;
            var jumpForce = Mathf.Lerp(minimumJumpForce, maximumJumpForce, jumpCharge);
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumpCharge = 0f;
            // Plays jump animation.
            anim.SetBool("jump", true);
        }
    }
}