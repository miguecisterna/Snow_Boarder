using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboardParticles : MonoBehaviour
{
   [SerializeField] ParticleSystem snowParticles;
   
      void OnCollisionEnter2D(Collision2D other)
        {
            var main = snowParticles.main;

            if(other.gameObject.CompareTag("Ground"))
            {
                snowParticles.Play();
                main.loop = true;
            }
        }

        void OnCollisionExit2D(Collision2D other) 
        {
           var main = snowParticles.main;
           if(other.gameObject.CompareTag("Ground"))
           {
              main.loop = false;

           }  
        }

}
