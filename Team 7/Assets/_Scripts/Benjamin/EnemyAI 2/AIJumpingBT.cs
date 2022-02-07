using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIJumpingBT : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] private LayerMask playerAbove;
    private CommandContainer commandContainer;
    
    private void Start() {
        commandContainer = GetComponent<CommandContainer>();
    }

    private void Update() {
        LookForPlayer();
    }
    private void LookForPlayer() {
        var ray = new Ray(transform.position, Vector3.up);
        if (Physics.Raycast(ray, sightRange,playerAbove)) {
            Jump();
        }

        // var distanceToPlayer = Vector3.Distance(targetPosition.currentPosition, transform.position);
        // Debug.Log(distanceToPlayer);
        // if (distanceToPlayer < sightRange) {
        //     Jump();
        // }
    }
    private void Jump() {
        commandContainer.jumpCommandDown = true;
    }
}
