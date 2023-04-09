using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
   [SerializeField] float delayTimeCrash = 0.5f;
   [SerializeField] ParticleSystem crashEffect;
   [SerializeField] AudioClip crashSFX;
   bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.tag == "Ground" && !hasCrashed)
        {  hasCrashed = true;
           crashEffect.Play();
           FindObjectOfType<PlayerController>().DisableControls();
           GetComponent<AudioSource>().PlayOneShot(crashSFX);
           Invoke("ReloadScene", delayTimeCrash);
        }
    }
    void ReloadScene()
    {
         SceneManager.LoadScene(0);
    }
}
