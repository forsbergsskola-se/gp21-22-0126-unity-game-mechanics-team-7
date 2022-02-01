using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimController : MonoBehaviour {
    private Vector3 _swimRotation = new(90, 90, 0);
    private Vector3 _startRotation;

    private void Start() {
        RotateToSwimRotation();
    }

    private void RotateToSwimRotation() {
        _startRotation = gameObject.transform.eulerAngles;
        gameObject.transform.eulerAngles = Vector3.Lerp(_startRotation, _swimRotation, Time.time);
    }
}
