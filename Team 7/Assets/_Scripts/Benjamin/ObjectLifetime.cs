using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifetime : MonoBehaviour {
    
    [SerializeField] private float lifeTime;
    private float elapsedTime;
   
    private void Start() {
        elapsedTime = 0;
    }
    private void Update() {
        elapsedTime += Time.deltaTime;

        if (lifeTime < elapsedTime) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            Destroy(gameObject);
        }
    }
}
