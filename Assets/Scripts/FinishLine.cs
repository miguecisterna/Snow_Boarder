﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float reloadTime = 2f;
    [SerializeField] ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other) 
    {
      if(other.tag == "Player")
      { 
        finishEffect.Play(); 
        GetComponent<AudioSource>().Play();
        Debug.Log("You finished!");
        Invoke("ReloadScene",reloadTime);
      }    
    }

    void ReloadScene()
    {
      SceneManager.LoadScene(0);
    }

}
