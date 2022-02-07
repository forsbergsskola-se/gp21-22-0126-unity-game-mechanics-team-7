using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class SharkSwim : MonoBehaviour {
    [SerializeField] private float swimHorizontalSpeed;
    [SerializeField] private float swimVerticalSpeed;
    [SerializeField] private PositionSO[] patrollingPoints;
    private Rigidbody _rigidbody;
    private Vector3 _targetPosition;
    private Random _random = new Random();
    private bool _targetPosReached;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _targetPosition = RandomizeNextPoint();
    }
    
    private void Update() {
        Swim();
    }
    
    private void Swim() {
        Vector3 currentPosition = transform.position;

        if (currentPosition == _targetPosition) {
            _targetPosition = RandomizeNextPoint();
        }

        Vector3.Lerp(currentPosition, _targetPosition, swimHorizontalSpeed);

        /*float verticalDifference = currentPosition.y - _targetPosition.y;
        float horizontalDifference = currentPosition.x - _targetPosition.x;

        var velocity = _rigidbody.velocity;
        velocity = new Vector3(verticalDifference * swimVerticalSpeed, velocity.y, 0);
        velocity = new Vector3(horizontalDifference * swimHorizontalSpeed, velocity.x, 0);
        
        _rigidbody.velocity = velocity;*/
    }

    private Vector3 RandomizeNextPoint() {
        int randomPoint = _random.Next(0, patrollingPoints.Length);
        return patrollingPoints[randomPoint].currentPosition;
    }
}
