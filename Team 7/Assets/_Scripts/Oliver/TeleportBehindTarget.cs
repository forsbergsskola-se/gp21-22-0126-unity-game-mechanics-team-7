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


   bool canTeleport = true;
   
   void Awake(){
      commandContainer = GetComponentInChildren<CommandContainer>();
   }


   void Update(){

      if (commandContainer.teleportBehindTargetCommand&& canTeleport){
         RaycastHit hit;
         Debug.DrawRay(transform.position,transform.right * teleportRange, Color.red);
         if (Physics.Raycast(transform.position, transform.right, out hit, teleportRange, targetMask)){
          Teleport(hit); 
         }
         // var targetPosition = hit.transform.right;
         // Debug.Log(Vector3.Dot(targetPosition, transform.right));


      }
   }

   void Teleport(RaycastHit target){
var targetTransform = target.transform;
      Debug.Log(Vector3.Dot(transform.right,targetTransform.forward ));
      var dotProduct = Vector3.Dot(transform.right, targetTransform.forward);
      var distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

      var tempTeleportOffset = teleportOffset;
      Debug.Log(distanceToTarget);
      var isBehindTarget = false;
      if (distanceToTarget < 0){
         isBehindTarget = true;
         
      }
      else if (distanceToTarget > 0){
         isBehindTarget = false;
         tempTeleportOffset = -teleportOffset;
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
