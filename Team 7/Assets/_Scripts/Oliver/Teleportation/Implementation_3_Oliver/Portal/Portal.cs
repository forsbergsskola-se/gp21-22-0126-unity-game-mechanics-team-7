using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnityResonance;
using UnityEngine;

public class Portal : MonoBehaviour{
    [SerializeField] PortalSO oppositePortal;
    [SerializeField] PortalSO thisPortal;
    [SerializeField] float portalCooldown;

    

    void OnTriggerEnter(Collider other){
        if (oppositePortal.isActive && thisPortal.isActive){
            other.gameObject.transform.position = oppositePortal.portalPosition.currentPosition;
            FMODUnity.RuntimeManager.PlayOneShot("event:/PORTALS/Portal", thisPortal.portalPosition.currentPosition);
            StartCoroutine(PortalCooldown());
        }
    }

    IEnumerator PortalCooldown(){
        oppositePortal.isActive = false;
        thisPortal.isActive = false;
        yield return new WaitForSeconds(portalCooldown);
        oppositePortal.isActive = true;
        thisPortal.isActive = true;
    }
}
