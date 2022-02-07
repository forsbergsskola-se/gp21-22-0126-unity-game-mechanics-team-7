using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SwimBabyPenguin : MonoBehaviour {
    [SerializeField] private PositionSO playerPosition;
    [SerializeField] private float sightLength = 5;
    [SerializeField] private float swimSpeed;
    
    private CommandContainer _commandContainer;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _followOffset = new Vector3(2, 2);

    private Random _random = new Random();
    private bool _playerFound;

    private void Start() {
        _commandContainer = GetComponentInChildren<CommandContainer>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (!_playerFound) {
            LookForPlayer();
        }
    }

    private void FixedUpdate() {
        if (_playerFound) {
            SwimAfterPlayer();
        }
    }

    private void SwimAfterPlayer() {
        _animator.SetBool("jump", true);
        Vector3 direction = playerPosition.currentPosition - transform.position;
        _rigidbody.velocity = direction.normalized * swimSpeed;
        //_rigidbody.MovePosition(transform.position + direction * Time.deltaTime * swimSpeed);
    }

    private void LookForPlayer() {
        Physics.Raycast(transform.position, Vector3.up, out RaycastHit hit, sightLength);
        if (hit.rigidbody != null) {
            if (hit.collider.gameObject.CompareTag("Player")) {
                _playerFound = true;
            }
        }
    }
}
