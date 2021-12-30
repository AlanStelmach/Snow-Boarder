using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float time = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {   
            FindObjectOfType<PlayerController>().DisableControles();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", time);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
