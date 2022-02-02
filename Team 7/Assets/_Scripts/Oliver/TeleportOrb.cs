using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOrb : MonoBehaviour{
    
    [SerializeField] PositionSO positionSo;
    
    Rigidbody rigidbody;
    public bool isInsideEntity;

    void Awake(){
        rigidbody = GetComponent<Rigidbody>();
    }
    void OnEnable(){
        transform.position = positionSo.currentPosition;
        isInsideEntity = false;
        Debug.Log(this + "I am awake");
    }

    void OnTriggerEnter(Collider other){
        if (!other.CompareTag("Player")){
           Debug.Log("Entered Collider");
                   isInsideEntity = true; 
        }
        
    }

    // void OnTriggerStay(Collider other){
    //     if(other != null){}
    //     
    //     
    // }

    void OnTriggerExit(Collider other){
        Debug.Log("Left Collider");
        isInsideEntity = false;
    }
}
