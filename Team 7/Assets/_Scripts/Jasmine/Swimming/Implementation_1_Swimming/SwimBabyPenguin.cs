using UnityEngine;

public class SwimBabyPenguin : MonoBehaviour {
    [SerializeField] private PositionSO playerPosition;
    [SerializeField] private float sightLength = 5;
    
    private CommandContainer _commandContainer;

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
            //If player has picked up penguin
            SwimAfterPlayer();
        }
    }

    private void SwimAfterPlayer() {
        //Gets the normalized direction to swim in
        var directionToPlayer = Vector3.Normalize(playerPosition.currentPosition - transform.position);
       
        //Swims towards the position
        _commandContainer.swimCommandHorizontal = directionToPlayer.x;
        _commandContainer.swimCommandVertical = directionToPlayer.y;
    }

    private void LookForPlayer() {
        //Raycast to find player
        Physics.Raycast(transform.position, Vector3.up, out RaycastHit hit, sightLength);
        if (hit.rigidbody != null) {
            if (hit.collider.gameObject.CompareTag("Player")) {
                _playerFound = true;
            }
        }
    }
}
