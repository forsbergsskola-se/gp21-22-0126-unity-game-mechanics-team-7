using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleportOrb : MonoBehaviour{
   ChargedTeleport chargedTeleport;


   void OnTriggerEnter(Collider other){
      if (!other.CompareTag("Player")){
         return;
      }
      else{
        chargedTeleport = other.GetComponent<ChargedTeleport>();
        chargedTeleport.abilityAcquired = true;
      }
   }
}
