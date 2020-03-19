using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMove : MonoBehaviour
{
    public List<Transform> movePositionList;
    private int _currentPathId = 0;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,movePositionList[_currentPathId].position,10*Time.deltaTime);
        
        
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
