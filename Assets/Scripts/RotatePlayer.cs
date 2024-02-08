using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    bool canMove=true;
    [SerializeField] float torqueAmount;
    [SerializeField] float boostSpeed=30f;
    [SerializeField] float baseSpeed=10f;

    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        surfaceEffector2D=FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlyr();
            RespToBoost();
        }
    }

    private void RotatePlyr()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    public void DisableControls()
    {
        canMove=false;
    }
    void RespToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed=boostSpeed;
        }
        else
        surfaceEffector2D.speed=baseSpeed;
    }
}
