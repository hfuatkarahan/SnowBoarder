using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishLine;
    [SerializeField] float loadDelay = 1f;
    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player") {
            
            finishLine.Play();
            Invoke("ReloadScene", loadDelay);
        }
        
    }

    void ReloadScene() {

        SceneManager.LoadScene(0);
    }
}
