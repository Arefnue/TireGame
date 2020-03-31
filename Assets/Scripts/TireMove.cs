using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMove : MonoBehaviour
{
    public List<Transform> movePositionList;
    private int _currentPathId = 0;
    public int speed;
    private int _speedContainer;
    private int _turboSpeed;
    public ButtonHandler turboButton;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _speedContainer = speed;
        _turboSpeed = speed * 2;
    }

    private void Update()
    {
        if (turboButton.isDown == true)
        {
            speed = _turboSpeed;
            _rb.isKinematic = true;
        }
        else if(turboButton.isUp == true)
        {
            speed = _speedContainer;
            _rb.isKinematic = false;
        }
        
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,movePositionList[_currentPathId].position,speed*Time.deltaTime);
        
        
        if (transform.position == movePositionList[_currentPathId].position)
        {
            _currentPathId += 1;
        }
    
        if (_currentPathId >= movePositionList.Count)
        {
            Debug.Log("Stop");
            _currentPathId = movePositionList.Count;
        }
    }
    
    
}
