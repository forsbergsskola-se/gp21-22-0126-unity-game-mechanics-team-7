using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Portal", menuName = "Portal")]
public class PortalSO : ScriptableObject{
    [SerializeField] public PositionSO portalPosition;
    public bool isActive = true;

    void OnEnable(){
        isActive = true;
    }
}
