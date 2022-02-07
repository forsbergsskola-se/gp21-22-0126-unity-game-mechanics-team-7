using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SwimController : MonoBehaviour {
    [SerializeField] private float swimHorizontalSpeed;
    [SerializeField] private float swimVerticalSpeed;
    [SerializeField] private Animator anim;

    private Rigidbody _rigidbody;
    private CommandContainer commandContainer;
    
    private float _currentAngle;
    
    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        commandContainer = GetComponentInChildren<CommandContainer>();
    }

    private void FixedUpdate() {
        Swim();
    }

    private void Swim() {
        var velocity = _rigidbody.velocity;
        
        //Testa här om de går att ha på samma rad kod
        velocity = new Vector3(commandContainer.swimCommandVertical * swimVerticalSpeed, velocity.y, 0);
        velocity = new Vector3(commandContainer.swimCommandHorizontal * swimHorizontalSpeed, velocity.x, 0);
        
        FaceSwimmingDirection();
        _rigidbody.velocity = velocity;

        anim.SetBool("jump", true);
    }

    private void FaceSwimmingDirection() {
        float targetAngle = Mathf.Atan2(commandContainer.swimCommandVertical, commandContainer.swimCommandHorizontal) * Mathf.Rad2Deg;
        _currentAngle = Mathf.LerpAngle(targetAngle, _currentAngle, Time.deltaTime);

        if (commandContainer.swimCommandHorizontal != 0 || commandContainer.swimCommandVertical != 0) {
            transform.rotation = Quaternion.Euler(-_currentAngle + 90, 90, 0);
        }
    }
}
