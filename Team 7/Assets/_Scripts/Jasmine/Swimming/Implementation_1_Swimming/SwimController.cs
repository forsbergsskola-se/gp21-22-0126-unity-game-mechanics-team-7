using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SwimController : MonoBehaviour {
    [SerializeField] private float swimHorizontalSpeed;
    [SerializeField] private float swimVerticalSpeed;
    private Animator anim;

    private Rigidbody _rigidbody;
    private CommandContainer _commandContainer;
    
    private float _currentAngle;
    
    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _commandContainer = GetComponentInChildren<CommandContainer>();
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate() {
        Swim();
    }

    private void Swim() {
        
        //Testa här om de går att ha på samma rad kod
        _rigidbody.velocity = new Vector3(_commandContainer.swimCommandHorizontal * swimHorizontalSpeed, _commandContainer.swimCommandVertical * swimVerticalSpeed, 0);
        
        FaceSwimmingDirection();

        anim.SetBool("jump", true);
    }

    private void FaceSwimmingDirection() {
        float targetAngle = Mathf.Atan2(_commandContainer.swimCommandVertical, _commandContainer.swimCommandHorizontal) * Mathf.Rad2Deg;
        _currentAngle = Mathf.LerpAngle(targetAngle, _currentAngle, Time.deltaTime);

        if (_commandContainer.swimCommandHorizontal != 0 || _commandContainer.swimCommandVertical != 0) {
            transform.rotation = Quaternion.Euler(-_currentAngle + 90, 90, 0);
        }
    }
}
