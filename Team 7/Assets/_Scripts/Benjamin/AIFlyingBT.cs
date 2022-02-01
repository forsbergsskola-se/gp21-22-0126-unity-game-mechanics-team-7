using UnityEngine;

public class AIFlyingBT : MonoBehaviour {
    private CommandContainer commandContainer;
    private Transform player;

    private void Start() { 
        commandContainer = GetComponentInChildren<CommandContainer>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        var directionToPlayer = Vector3.Normalize(player.position - transform.position);
        directionToPlayer.Normalize();
        var horizontalDirectionToPlayer = Mathf.Sin(directionToPlayer.x);
        commandContainer.walkCommand = horizontalDirectionToPlayer;
    }
}
