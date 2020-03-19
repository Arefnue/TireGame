using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TireHit : MonoBehaviour
{
    public TextMeshProUGUI hitCountText;
    private bool _isHit;
    private int _hitCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (_isHit != true)
            {
                _isHit = true;

                _hitCount += 1;
                other.gameObject.SetActive(false);
                hitCountText.text = _hitCount.ToString();

            }
            
            
        }
    }


    private void LateUpdate()
    {
        _isHit = false;
    }
}
