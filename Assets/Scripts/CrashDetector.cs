using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D playerHead;

    [SerializeField] float respawnTime = 2f;
    [SerializeField] ParticleSystem crashParticles;

    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;


    void Start() 
    {
       playerHead = GetComponent<CircleCollider2D>();  
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
       if(other.gameObject.CompareTag("Ground")&& playerHead.IsTouching(other.collider)&& !hasCrashed)
       {
           FindObjectOfType<PlayerController>().DisableControl();
           crashParticles.Play();
           GetComponent<AudioSource>().PlayOneShot(crashSFX);
           Debug.Log("I hit my friggin Head!");
           Invoke("PlayerRespawn", respawnTime); 
           hasCrashed = true;
       }   
    }

    void PlayerRespawn()
    {
        SceneManager.LoadScene(0);
    }
}
