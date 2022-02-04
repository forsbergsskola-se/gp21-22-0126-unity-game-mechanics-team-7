using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Geiser : MonoBehaviour {
    [SerializeField] private float rayCastSphereRadius = 3f;
    private float powerRange = 10f;
    private float geiserForce = 70f;
    
    private bool canErupt = true;
    private bool objectFoundInArea;

    private RaycastHit hit;

    private void FixedUpdate() {
        objectFoundInArea = Physics.SphereCast(transform.position, rayCastSphereRadius, transform.up, out hit, powerRange);
        
        if (objectFoundInArea && canErupt) {
            if (hit.collider.gameObject.CompareTag("Player")) {
                hit.rigidbody.AddForce(transform.up * geiserForce, ForceMode.Impulse);
                StartCoroutine(GeiserActivity());
            }
        }
    }

    private IEnumerator GeiserActivity() {
        canErupt = false;
        yield return new WaitForSeconds(2);
        canErupt = true;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * powerRange);
        Gizmos.DrawWireSphere(transform.position + transform.up * hit.distance, rayCastSphereRadius);
    }
}
