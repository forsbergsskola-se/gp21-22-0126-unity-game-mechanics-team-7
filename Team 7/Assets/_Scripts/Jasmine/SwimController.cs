using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimController : MonoBehaviour {
    [SerializeField] private float swimHorizontalSpeed;
    [SerializeField] private float swimVerticalSpeed;

    private Vector3 _swimRotation = new(90, 90, 0);
    private Vector3 _startRotation;

    private Rigidbody _rigidbody;
    private CommandContainer commandContainer;
    
    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        commandContainer = GetComponentInChildren<CommandContainer>();

        RotateToSwimRotation();
    }

    private void FixedUpdate() {
        Swim();
    }

    private void Swim() {
        var velocity = _rigidbody.velocity;
        velocity = new Vector3(commandContainer.swimCommandVertical * swimVerticalSpeed, velocity.y, 0);
        velocity = new Vector3(commandContainer.swimCommandHorizontal * swimHorizontalSpeed, velocity.x, 0);
        _rigidbody.velocity = velocity;
    }

    private void RotateToSwimRotation() {
        _startRotation = gameObject.transform.eulerAngles;
        gameObject.transform.eulerAngles = Vector3.Lerp(_startRotation, _swimRotation, Time.time);
    }
}
