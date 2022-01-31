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
      Debug.Log(Vector3.Dot(transform.right,targetTransform.right ));
      
      if (Vector3.Dot(transform.right,targetTransform.right) < 0){
         transform.position = targetTransform.position - teleportOffset;
      }
      else if (Vector3.Dot(transform.right,targetTransform.right) > 0){
         transform.position = targetTransform.position + teleportOffset;
         transform.Rotate(0,180,0);
      }


      StartCoroutine(StartTeleportTimer());
   }

   IEnumerator StartTeleportTimer(){

      canTeleport = false;
      yield return new WaitForSeconds(teleportCooldown);
      canTeleport = true;
   }


  
}
