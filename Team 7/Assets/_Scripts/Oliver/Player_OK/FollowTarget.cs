using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour{
    [SerializeField] PositionSO targetPosition;
    [SerializeField] PortalSO portalOne;
    [SerializeField] PortalSO portalTwo;
    [SerializeField] float aggroRange;
    [SerializeField] float moveSpeed;


    void Update(){
        var distanceToTarget=Vector3.Distance(this.transform.position, targetPosition.currentPosition);

        var directionToTarget =  targetPosition.currentPosition.x- transform.position.x;

        var distanceToPortalOne =  portalOne.portalPosition.currentPosition - transform.position;
        var distanceFromPortalOneToTarget = targetPosition.currentPosition - portalOne.portalPosition.currentPosition;
        var portalOnePath = distanceToPortalOne + distanceFromPortalOneToTarget;
        
        var distanceToPortalTwo =  portalTwo.portalPosition.currentPosition - transform.position;
        var distanceFromPortalTwoToTarget = targetPosition.currentPosition - portalTwo.portalPosition.currentPosition;
        var portalTwoPath = distanceToPortalTwo + distanceFromPortalTwoToTarget;
        
        var shortestPath = Mathf.Min(distanceToTarget, Mathf.Abs(portalOnePath.magnitude), Mathf.Abs(portalTwoPath.magnitude));
       
        
        
        Debug.Log("Shortest path:" + shortestPath);

        Vector3 bestPath = transform.position;
        if (distanceToTarget <= shortestPath){
             Debug.Log("Standard distance" + distanceToTarget);
            bestPath = targetPosition.currentPosition;
        }
        else if (Mathf.Abs(portalOnePath.magnitude) <= shortestPath){
            Debug.Log("portalOnePath" + portalOnePath.magnitude);
            bestPath = portalOnePath;
        }
        else if (Mathf.Abs(portalTwoPath.magnitude) <= shortestPath){
            Debug.Log("portalTwoPath" + portalTwoPath.magnitude);
            bestPath = portalTwoPath;
        }
        
        
        
        if (directionToTarget > 0 ){
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (directionToTarget < 0){
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if (bestPath.magnitude < aggroRange){
            
            transform.position = Vector3.MoveTowards(transform.position, bestPath, moveSpeed*Time.deltaTime);
        }
        
        
    }


    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position,aggroRange);
    }
}
