using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class HealthBarBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private float _maxHealth = 100f;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = 99f;
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z -2f);

        
    }
    
    public void HealthBarUpdate(float healAmount)
    {
        _currentHealth += healAmount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if (_currentHealth <= 0f)
        {
            _currentHealth = 0f;
            // Die();
        }

            transform.GetChild(0).localScale = new Vector3(_currentHealth / _maxHealth,
            transform.GetChild(0).localScale.y,
            transform.GetChild(0).localScale.z);
    }
}
