using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour{
    [SerializeField] Portal bluePortal;
    [SerializeField] Portal redPortal;
    [Min(0)][SerializeField] float portalGunRange;
    [SerializeField] CommandContainer commandContainer;
    [SerializeField] LayerMask targetMask;

    public bool portalGunIsActive;


    Camera camera;

    GameObject bluePortalGameObject;
    GameObject redPortalGameObject;


    void Awake(){
        camera = Camera.main;
        bluePortalGameObject = bluePortal.gameObject;
        redPortalGameObject = redPortal.gameObject;
    }

    void FixedUpdate(){
        if (portalGunIsActive){
            if (commandContainer.spawnPortalOneCommand){
                SpawnPortalAtCursor(bluePortalGameObject);
            }
            else if (commandContainer.spawnPortalTwoCommand){
                SpawnPortalAtCursor(redPortalGameObject);
            }
        }
        
    }

    void SpawnPortalAtCursor(GameObject portal){
        RaycastHit hit;
        var point = camera.ScreenToWorldPoint(Input.mousePosition);
        point = new Vector3(point.x, point.y, 0);
        var distanceToPoint = point - transform.position;
        Debug.DrawRay(transform.position, point.normalized * portalGunRange, Color.red);

        if (Physics.Raycast(transform.position, distanceToPoint.normalized, out hit, portalGunRange, targetMask)){
            Debug.Log(hit);
            portal.transform.position = hit.point;
            portal.transform.right = hit.normal;
        }
    }
}
