using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class ExperienceBarBehaviour : MonoBehaviour
{
    private Image expBar;
    
    private float _maxFillAmount = 100f;
    private void Start()
    {
        expBar =transform.GetChild(1).gameObject.GetComponent<Image>();
    }

    public void UpdateFillAmount(float increaseAmount)
    {

        expBar.fillAmount = increaseAmount / _maxFillAmount;
    }
    
}
