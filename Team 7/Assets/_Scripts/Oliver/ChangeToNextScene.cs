using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToNextScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        Debug.Log("Loading next scene");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
