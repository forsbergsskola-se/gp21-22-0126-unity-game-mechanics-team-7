using UnityEngine;

public class SwimShark : MonoBehaviour {
    [SerializeField] private float swimSpeed = 4;
    [SerializeField] private PositionSO[] patrolPoints;
    
    private Rigidbody _rigidbody;
    private Vector3 _targetPointPosition;
    
    private int _destPointIndex = 0;
    private float _reachDistance = 3;
    private bool _pointReached;
    
    private void Start() {
        //Sets the target position to the patrol point of index 0
        _targetPointPosition = patrolPoints[_destPointIndex].currentPosition;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        SwimPatrol();
    }

    private void SwimPatrol() {
        DecidePoint();
        SwimToPoint();
    }

    private void DecidePoint() {
        var distanceToPoint = Vector3.Distance(transform.position, _targetPointPosition);

        //If close enough to target point position
        if (distanceToPoint < _reachDistance) {
            _pointReached = true;
        }
        
        if (_pointReached) {
            NextPatrolPoint();
        }

        _pointReached = false;
    }

    private void SwimToPoint() {
        Vector3 vectorDistance = _targetPointPosition - transform.position;

        //Turns the shark to the swim direction and sets velocity towards the target point position
        if (vectorDistance.x <= 0) {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            _rigidbody.velocity = new Vector3(_targetPointPosition.x * -swimSpeed, _rigidbody.velocity.y, 0);

        } else {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            _rigidbody.velocity = new Vector3(_targetPointPosition.x * swimSpeed, _rigidbody.velocity.y, 0);
        }
    }

    private void NextPatrolPoint() {
        //Returns if no points have been set up in inspector
        if (patrolPoints.Length == 0) {
            return;
        }

        //Sets the target point position
        _targetPointPosition = patrolPoints[_destPointIndex].currentPosition;

        //Choose the next point in the array as the next target point position
        _destPointIndex = (_destPointIndex + 1) % patrolPoints.Length;
    }
}
