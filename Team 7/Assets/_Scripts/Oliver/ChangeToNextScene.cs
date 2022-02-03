using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToNextScene : MonoBehaviour{

    [SerializeField] PortalGun portalGun;


    void Awake(){
        portalGun = FindObjectOfType<PortalGun>();
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Debug.Log("Loading next scene");
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
            portalGun.portalGunIsActive = false;

        }
        
    }
}
