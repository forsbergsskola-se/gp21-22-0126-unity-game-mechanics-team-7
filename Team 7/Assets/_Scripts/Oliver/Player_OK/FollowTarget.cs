using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour{
    [SerializeField] PositionSO targetPosition;
    [SerializeField] float aggroRange;
    [SerializeField] float moveSpeed;
    private Animator anim;

    private void Start() {
        anim = GetComponentInChildren<Animator>();
    }
    void Update(){
        var distanceToTarget=Vector3.Distance(this.transform.position, targetPosition.currentPosition);

        var directionToTarget =  targetPosition.currentPosition.x- transform.position.x;
        
        if (directionToTarget > 0 ){
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (directionToTarget < 0){
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        Debug.Log(distanceToTarget);
        if (distanceToTarget < aggroRange){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.currentPosition, moveSpeed*Time.deltaTime);
            anim.SetInteger("Walk", 1);
        }
        
        
    }


    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position,aggroRange);
    }
}
