using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireControllerRb : MonoBehaviour
{
    public float torque;
    public Rigidbody rb;
    
    private float _turnValue = 0;

    public ButtonHandler leftButton;
    public ButtonHandler rightButton;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //Max balance speed of tire
        rb.maxAngularVelocity = 1.5f;

    }
    
    private void Update()
    {
        Balance();
    }

    private void Balance()
    {
        
        // //Input fields with buttons
        // if (leftButton.isDown == true) 
        // {
        //     _turnValue = 1;
        // }
        // else if (rightButton.isDown == true)
        // {
        //     _turnValue = -1;
        // }

        if (Mathf.Abs(transform.rotation.z) >= 0.60f)
        {
            //rb.isKinematic = true;
            Time.timeScale = 0;
        }
        else
        {
            rb.AddTorque(transform.forward * (torque * _turnValue));
        }
    }


    public void DetermineMovePosition(bool isLeft)
    {
        if (isLeft == true)
        {
            _turnValue = 1;
        }
        else
        {
            _turnValue = -1;
        }
    }

}
