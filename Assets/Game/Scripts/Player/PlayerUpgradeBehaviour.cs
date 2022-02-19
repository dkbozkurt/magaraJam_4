using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 
/// </summary>

namespace Game.Scripts.Player
{
    public class PlayerUpgradeBehaviour : MonoBehaviour
    {
        #region ModePercentages

        private float _firePercentage=0f;
        private float _icePercentage=0;
        private float _stonePercentage=0;

        [SerializeField] private ExperienceBarBehaviour expBarFire;
        [SerializeField] private ExperienceBarBehaviour expBarIce;
        [SerializeField] private ExperienceBarBehaviour expBarStone;

        [SerializeField] private float percentageMultiplier= 25f;
        
        #endregion

        [SerializeField] private HealthBarBehaviour healthBarBehaviour;
        private float damageAmount = 10f;
        [HideInInspector] public bool _isCollectable= true;
        
        
        private void OnTriggerEnter(Collider other)
        {
            CheckEnemyType(other.gameObject);
        }

        private void CheckEnemyType(GameObject enemy)
        {
            switch (enemy.tag)
            {
                case "Fire":
                    Fire();
                    break;
                
                case "Ice":
                    Ice();
                    break;
                
                case "Stone":
                    Stone();
                    break;
                
                case "Shoot":
                    healthBarBehaviour.HealthBarUpdate(-damageAmount);
                    break;
                
            }
            Destroy(enemy);
        }

        private void Fire()
        {
            if (_isCollectable)
            {
                _firePercentage += percentageMultiplier;
                expBarFire.UpdateFillAmount(_firePercentage);
                if (_firePercentage >= 100f)
                {
                    _firePercentage = 0f;
                    CheckIfUpgradable(1) ;
                }
            }
            
        }

        private void Ice()
        {
            if (_isCollectable)
            {
                _icePercentage += percentageMultiplier;
                expBarIce.UpdateFillAmount(_icePercentage);
                if (_icePercentage >= 100f)
                {
                    _icePercentage = 0f;
                    CheckIfUpgradable(2) ;
                }
            }
            
        }

        private void Stone()
        {
            if (_isCollectable)
            {
                _stonePercentage += percentageMultiplier;
                expBarStone.UpdateFillAmount(_stonePercentage);
                if (_stonePercentage >= 100f)
                {
                    _stonePercentage = 0f;
                    CheckIfUpgradable(3) ;
                }
            }
        }
        
        public void CheckIfUpgradable(int modelIndex)
        {
            foreach (Transform model in transform.GetChild(0))
            {
                model.gameObject.SetActive(false);
            }
            
            transform.GetChild(0).GetChild(modelIndex).gameObject.SetActive(true);

        }
        
        
    }
}