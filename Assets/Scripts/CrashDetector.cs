using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] AudioClip crashSFX;
    CircleCollider2D playerHead;
    bool hasCrashed = false;
 
    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }  
 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene(){

        SceneManager.LoadScene(0);
    }
}
