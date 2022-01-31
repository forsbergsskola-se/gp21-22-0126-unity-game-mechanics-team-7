using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimController : MonoBehaviour
{
    // Start is called before the first frame update
    //PSEUDO CODE
    /*
    If in water disable other controllers
    Turn player so he is horizontal
    W = up in water
    A = left
    S = down in water
    D = right
    
    Changing where penguin is facing when switching direction
    Would like to add slight rotation to player on up and then to get a nicer swim
    Maybe need to disable locked rotation??
    Should water detection be in it's own script?
    
    Add force to then counteract the force from underwater currents
    Need to be bigger than underwater current so you can get out by swimming
    
    Can't walk on seafloor for now
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
