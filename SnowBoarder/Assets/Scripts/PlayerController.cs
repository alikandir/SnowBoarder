using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostAmount = 30f;
    [SerializeField] float baseSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

     void RespondToBoost()
    { if (Input.GetKey(KeyCode.UpArrow))
     {
        surfaceEffector2D.speed = boostAmount;
     }
     else 
     {
        surfaceEffector2D.speed = baseSpeed;
     }
        
    }

     void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torqueAmount);
        }
    }
}
