using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    [SerializeField] float scrollSpeed;

    void Update (){
         float offset = Time.time * scrollSpeed;
         GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
     
     }
}
