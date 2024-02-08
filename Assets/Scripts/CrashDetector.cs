using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    bool ok=false;
    CircleCollider2D head;
    [SerializeField] float delay=3;
    [SerializeField] ParticleSystem hit;
    [SerializeField] AudioClip crashSFX;
    void Start()
    {
        head = GetComponent<CircleCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Platform" && head.IsTouching(other.collider) && ok==false)
        {
            hit.Play();
            FindObjectOfType<RotatePlayer>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("LoadScene",delay);
            ok=true;
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
