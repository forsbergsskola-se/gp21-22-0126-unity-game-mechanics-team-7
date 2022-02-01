using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour{
    [SerializeField] PositionSO targetPosition;
    [SerializeField] float aggroRange;
    [SerializeField] float moveSpeed;


    void Update(){
        var distanceToTarget=Vector3.Distance(this.transform.position, targetPosition.currentPosition);

        Debug.Log(distanceToTarget);
        if (distanceToTarget < aggroRange){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.currentPosition, moveSpeed*Time.deltaTime);
        }
    }
}
