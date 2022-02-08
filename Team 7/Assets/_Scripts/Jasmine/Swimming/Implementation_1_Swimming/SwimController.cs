using UnityEngine;

public class SwimController : MonoBehaviour {
    [SerializeField] private float swimHorizontalSpeed;
    [SerializeField] private float swimVerticalSpeed;
    
    private Animator _animator;
    private Rigidbody _rigidbody;
    private CommandContainer _commandContainer;
    
    private float _currentAngle;
    
    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _commandContainer = GetComponentInChildren<CommandContainer>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate() {
        Swim();
    }

    private void Swim() {
        //Moves depending on the vertical and horizontal input from player
        _rigidbody.velocity = new Vector3(_commandContainer.swimCommandHorizontal * swimHorizontalSpeed, _commandContainer.swimCommandVertical * swimVerticalSpeed, 0);
        
        FaceSwimmingDirection();

        //Jump animation is used for swimming since we don't have a swimming animation
        _animator.SetBool("jump", true);
    }

    private void FaceSwimmingDirection() {
        //Gets the angle from inputs
        var targetAngle = Mathf.Atan2(_commandContainer.swimCommandVertical, _commandContainer.swimCommandHorizontal) * Mathf.Rad2Deg;
        
        //Lerps from current angle to target angle
        _currentAngle = Mathf.LerpAngle(targetAngle, _currentAngle, Time.deltaTime);

        //If there are no inputs player stands vertical
        if (_commandContainer.swimCommandHorizontal != 0 || _commandContainer.swimCommandVertical != 0) {
            transform.rotation = Quaternion.Euler(-_currentAngle + 90, 90, 0);
        }
    }
}
