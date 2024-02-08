using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay = 3;
    [SerializeField] ParticleSystem finish;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Player")
        {
            finish.Play();
            GetComponent<AudioSource>().Play();
            Invoke("LoadScene",delay);
        }   
    }
     void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
