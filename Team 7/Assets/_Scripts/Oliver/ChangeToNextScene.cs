using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToNextScene : MonoBehaviour{
    PortalGun portalGun;
    ChargedTeleport chargedTeleport;


    void Awake(){
        portalGun = FindObjectOfType<PortalGun>();
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Debug.Log("Loading next scene");
            portalGun = other.GetComponent<PortalGun>();
            portalGun.portalGunIsActive = false;
            chargedTeleport = other.GetComponent<ChargedTeleport>();
            chargedTeleport.abilityAcquired = false;
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }
        
    }
}
