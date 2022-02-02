using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour{
    [SerializeField] PositionSO oppositePortal;
   // [SerializeField] Portal oppositePortal;

    void OnTriggerEnter(Collider other){
        other.gameObject.transform.position = oppositePortal.currentPosition;
        
    }
}
