using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotFollow : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        transform.parent = null;
    }

    private void Update()
    {
        transform.position = target.position;
    }
}
