using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPortalGun : MonoBehaviour{
    [SerializeField] PortalGun portalGun;
    void OnTriggerEnter(Collider other){
        portalGun.portalGunIsActive = true;
        Destroy(this.gameObject);
    }
}
