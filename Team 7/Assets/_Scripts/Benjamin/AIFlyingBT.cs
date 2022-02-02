using System;
using UnityEngine;

public class AIFlyingBT : MonoBehaviour {

    [SerializeField] private PositionSO targetPosition;
    [SerializeField] float sightRange;
    private CommandContainer commandContainer;

    private void Start() {
        commandContainer = GetComponent<CommandContainer>();
    }

    private void Update() {
        LookForPlayer();
    }
    private void LookForPlayer() {
        var distanceToPlayer = Vector3.Distance(targetPosition.currentPosition, transform.position);
        if (distanceToPlayer < sightRange) {
            MoveToPlayer();
        }
    }
    private void MoveToPlayer() {
        var directionToPlayer = Vector3.Normalize(targetPosition.currentPosition - transform.position);
        directionToPlayer.Normalize();
        var horizontalDirectionToPlayer = Mathf.Sin(directionToPlayer.x);
        Debug.Log(horizontalDirectionToPlayer);
        commandContainer.walkCommand = horizontalDirectionToPlayer;
    }
}
