using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SwimBabyPenguin : MonoBehaviour {
    [SerializeField] private PositionSO playerPosition;
    [SerializeField] private float sightLength = 5;
    
    private CommandContainer _commandContainer;
    private Vector3 _followOffset = new Vector3(2, 2);

    private bool _playerFound;

    private void Start() {
        _commandContainer = GetComponent<CommandContainer>();
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
        var directionToPlayer = Vector3.Normalize(playerPosition.currentPosition - transform.position);
        _commandContainer.swimCommandHorizontal = directionToPlayer.x;
        _commandContainer.swimCommandVertical = directionToPlayer.y;
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
