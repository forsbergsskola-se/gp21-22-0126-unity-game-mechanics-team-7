using System;
using UnityEngine;

public class CameraControllerBT : MonoBehaviour {

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime;
    [SerializeField] private Transform player;


    private void Awake() {
        // Sets offset - distance between camera and player.
        offset = transform.position - player.position;
    }
    private void Update() {
        Vector3 targetPosition = player.position + offset;
        // Smoothly moves camera to the player when the player moves.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
