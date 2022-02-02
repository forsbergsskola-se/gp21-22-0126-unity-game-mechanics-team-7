using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Position", menuName = "Essentials/Position")]
public class PositionSO : ScriptableObject{
    public Vector3 currentPosition;
    public Vector3 offsetPosition;
}
