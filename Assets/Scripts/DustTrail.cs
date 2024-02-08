using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem trail;
    CapsuleCollider2D board;
    [SerializeField] AudioClip slideSFX;

    void Start()
    {
        board=GetComponent<CapsuleCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Platform" && board.IsTouching(other.collider))
        {
            trail.Play();
            GetComponent<AudioSource>().PlayOneShot(slideSFX);
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        trail.Stop();
        GetComponent<AudioSource>().Stop();
    }
}
