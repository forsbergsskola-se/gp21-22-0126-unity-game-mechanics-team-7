using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class SharkSwim : MonoBehaviour {
    [SerializeField] private float swimSpeed = 4;
    [SerializeField] private PositionSO[] patrolPoints;
    
    private Rigidbody _rigidbody;
    private Vector3 _targetPosition;
    
    private int destPointIndex = 0;
    private float pointReachDistance = 3;
    private bool pointReached;
    
    private void Start() {
        _targetPosition = patrolPoints[destPointIndex].currentPosition;
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
        var distanceToPoint = Vector3.Distance(transform.position, _targetPosition);

        if (distanceToPoint < pointReachDistance) {
            pointReached = true;
        }
        
        if (pointReached) {
            NextPatrolPoint();
        }

        pointReached = false;
    }

    private void SwimToPoint() {
        Vector3 vectorDistance = _targetPosition - transform.position;

        if (vectorDistance.x <= 0) {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            _rigidbody.velocity = new Vector3(_targetPosition.x * -swimSpeed, _rigidbody.velocity.y, 0);

        } else {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            _rigidbody.velocity = new Vector3(_targetPosition.x * swimSpeed, _rigidbody.velocity.y, 0);
        }
    }

    private void NextPatrolPoint() {
        // Returns if no points have been set up
        if (patrolPoints.Length == 0)
            return;

        // Sets the target position
        _targetPosition = patrolPoints[destPointIndex].currentPosition;

        // Choose the next point in the array as the target position,
        destPointIndex = (destPointIndex + 1) % patrolPoints.Length;
    }
}
