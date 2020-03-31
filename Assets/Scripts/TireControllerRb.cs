using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireControllerRb : MonoBehaviour
{
    public float torque;
    public Rigidbody rb;
    
    private float _turnValue = 0;
    private int _turnCount = 0;
    private bool _lastTurnIsLeft;

    public ButtonHandler leftButton;
    public ButtonHandler rightButton;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //Max balance speed of tire
        //rb.maxAngularVelocity =1.5f;

    }
    
    private void Update()
    {
        Balance();
    }

    private void Balance()
    {
        
        //Input fields with buttons
        if (leftButton.isDown == true) 
        {
            _turnValue = 1;
            
            if (_turnCount < 2)
            {
                if (_lastTurnIsLeft == false)
                {
                    _turnCount = 0;
                }
                _turnCount += 1;
            }

            _lastTurnIsLeft = true;
            Debug.Log("left"+_turnCount);
        }
        else if (rightButton.isDown == true)
        {
            _turnValue = -1;
            
            if (_turnCount >-2)
            {
                if (_lastTurnIsLeft == true)
                {
                    _turnCount = 0;
                }
                _turnCount -= 1;
            }

            _lastTurnIsLeft = false;
            Debug.Log("right"+_turnCount);
        }
        
        
        //Max velocity fields
        if (Mathf.Abs(_turnCount) == 2)
        {
            rb.maxAngularVelocity = 2.5f;
        }
        else if (Mathf.Abs(_turnCount) == 1)
        {
            rb.maxAngularVelocity = 1.5f;
        }
        else
        {
            rb.maxAngularVelocity = 1f;
        }
        
        
        //Check death
        if (Mathf.Abs(transform.rotation.z) >= 0.60f)
        {
            //Time.timeScale = 0;
            rb.isKinematic = true;
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
            if (_turnCount < 2)
            {
                _turnCount += 1;
            }
            
        }
        else
        {
            _turnValue = -1;
            if (_turnCount >-2)
            {
                _turnCount -= 1;
            }
        }
    }
    
    
    

}
