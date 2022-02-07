using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Geiser : MonoBehaviour {
    [SerializeField] private float rayCastSphereRadius = 3f;
    [SerializeField] private float range = 10f;
    [SerializeField] private float geiserForce = 220f;
    [SerializeField] private float eruptionDuration = 2.5f;
    [SerializeField] private float reposeInterval = 2f;

    [SerializeField] private ParticleSystem bubbles;
    
    
    private bool canErupt = true;
    private bool objectFoundInArea;

    private RaycastHit hit;

    private void Start() {
        StartCoroutine(Eruption());
    }

    private void FixedUpdate() {
        objectFoundInArea = Physics.SphereCast(transform.position, rayCastSphereRadius, transform.up, out hit, range);
        
        if (objectFoundInArea && canErupt) {
            if (hit.collider.gameObject.CompareTag("Player")) {
                hit.rigidbody.AddForce(transform.up * geiserForce, ForceMode.Force);
            }
        }
    }

    private IEnumerator Eruption() {
        while (true) {
            bubbles.Play();
            canErupt = true;
            yield return new WaitForSeconds(eruptionDuration);
            bubbles.Stop();
            canErupt = false;
            yield return new WaitForSeconds(reposeInterval);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * range);
        Gizmos.DrawWireSphere(transform.position + transform.up * hit.distance, rayCastSphereRadius);
    }
}
