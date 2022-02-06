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
      var directionToTarget = transform.position - targetTransform.position;
      if (directionToTarget.x < 0){
         //Target is to the right
         if (targetTransform.rotation.y > 0){
            //Target is looking left 
            teleportOffset = new Vector3(3, 0, 0);
            transform.Rotate(0,180,0);
            transform.position = targetTransform.position + teleportOffset;
         }
         else if (targetTransform.rotation.y < 1){
            //Target is looking right
            teleportOffset = new Vector3(-3, 0, 0);
            transform.position = targetTransform.position + teleportOffset;
         }
         
      }
      else if (directionToTarget.x > 0){
         //Target is to the left
         if (targetTransform.rotation.y > 0){
            //Target is looking left 
            teleportOffset = new Vector3(3, 0, 0);
            transform.position = targetTransform.position + teleportOffset;
            
         }
         else if (targetTransform.rotation.y < 1){
            //Target is looking right
            teleportOffset = new Vector3(-3, 0, 0);
            transform.Rotate(0,180,0);
            transform.position = targetTransform.position + teleportOffset;
         }
      }

      StartCoroutine(StartTeleportTimer());
   }

   IEnumerator StartTeleportTimer(){

      canTeleport = false;
      yield return new WaitForSeconds(teleportCooldown);
      canTeleport = true;
   }


  
}
