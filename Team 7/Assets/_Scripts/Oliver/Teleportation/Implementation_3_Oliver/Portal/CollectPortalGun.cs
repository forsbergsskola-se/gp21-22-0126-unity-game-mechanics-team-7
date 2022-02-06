using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPortalGun : MonoBehaviour{
    [SerializeField] PortalGun portalGun;
    void OnTriggerEnter(Collider other){
        portalGun.portalGunIsActive = true;
        FMODUnity.RuntimeManager.PlayOneShot("event:/PORTALS/PortalGunPickup");
        Destroy(this.gameObject);
    }
}
