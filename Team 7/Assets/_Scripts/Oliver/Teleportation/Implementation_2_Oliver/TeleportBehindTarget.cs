using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportBehindTarget : MonoBehaviour{
   [SerializeField] float teleportRange;
   [SerializeField] float teleportCooldown;
   [SerializeField] Vector3 teleportOffset;
   [SerializeField] CommandContainer commandContainer;
   [SerializeField] LayerMask targetMask;
   [SerializeField] bool isAi;


   private bool canTeleport = true;
   
   void Awake(){
      commandContainer = GetComponentInChildren<CommandContainer>();
   }


   void Update(){

      if (isAi && canTeleport){
         DetectTargetThenTeleport();
      }
      else
      if (commandContainer.teleportBehindTargetCommand&& canTeleport){
         DetectTargetThenTeleport();
         // var targetPosition = hit.transform.right;
         // Debug.Log(Vector3.Dot(targetPosition, transform.right));
      }
   }

   void DetectTargetThenTeleport(){
      RaycastHit hit;
      Debug.DrawRay(transform.position, transform.right * teleportRange, Color.red);
      if (Physics.Raycast(transform.position, transform.right, out hit, teleportRange, targetMask)){
         Teleport(hit);
      }
   }

   void Teleport(RaycastHit target){
var targetTransform = target.transform;
      Debug.Log(Vector3.Dot(transform.right,targetTransform.right ));
      var dotProduct = Vector3.Dot(transform.right, targetTransform.right);
      var distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

      var tempTeleportOffset = teleportOffset;
      Debug.Log(distanceToTarget);
      var isBehindTarget = false;
      if (distanceToTarget < 0){
         isBehindTarget = true;
         
      }
      else if (distanceToTarget > 0){
         isBehindTarget = false;
         tempTeleportOffset = new Vector3(-teleportOffset.x,teleportOffset.y,teleportOffset.z);
      }
      
      if (dotProduct < 0){

         transform.position = targetTransform.position + tempTeleportOffset;
         
         //transform.position = new Vector3(targetTransform.position.x + dotProduct* 5, transform.position.y, transform.position.z);
         transform.Rotate(0,180,0);
      }
      else if (dotProduct > 0){
        // transform.position = new Vector3(targetTransform.position.x + dotProduct* 5, transform.position.y, transform.position.z);
         transform.position = targetTransform.position + tempTeleportOffset;
      }


      StartCoroutine(StartTeleportTimer());
   }

   IEnumerator StartTeleportTimer(){

      canTeleport = false;
      yield return new WaitForSeconds(teleportCooldown);
      canTeleport = true;
   }


  
}
