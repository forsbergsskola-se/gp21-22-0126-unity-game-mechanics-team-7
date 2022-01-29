using System;
using UnityEngine;

public class CameraControllerBT : MonoBehaviour {

    public Transform player;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime;

    private void Awake() {
        offset = transform.position - player.position;
    }
    private void Update() {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
