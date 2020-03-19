using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireController : MonoBehaviour
{

    public float angleValue;
    
    IEnumerator RotateMe(Vector3 byAngles, float inTime) 
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime) 
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        
    }

    IEnumerator CheckRotate()
    {
        while (true)
        {
            if (angleValue >= 0)
            {
                angleValue += 1;
            }
            else if (angleValue < 0)
            {
                angleValue -= 1;
            }

            if (transform.rotation.z >= 90)
            {
                angleValue = -15;
            }
            else if (transform.rotation.z <= -270)
            {
                angleValue = 15;
            }
            else
            {
                StartCoroutine(RotateMe(Vector3.forward * angleValue, 0.1f));
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Start()
    {
        StartCoroutine(CheckRotate());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
            angleValue += 5;
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            
            angleValue -= 5;
            
        }
        
    }
}


