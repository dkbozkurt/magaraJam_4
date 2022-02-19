using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

namespace Game.Scripts.Player
{
    public class PlayerUpgradeBehaviour : MonoBehaviour
    {
        public enum PlayerMode
        {
            Fire,
            Ice,
            Stone
        }

        #region ModePercentages

        private float _firePercentage=0f;
        private float _ironPercentage=0;
        private float _earthPercentage=0;

        [SerializeField] private float percentageMultiplier= 50f;
        
        #endregion
        
        
        private void OnTriggerEnter(Collider other)
        {
            CheckEnemyType(other.gameObject);
        }

        private void CheckEnemyType(GameObject enemy)
        {
            switch (enemy.tag)
            {
                case "Fire":
                    _firePercentage += percentageMultiplier;
                    if (_firePercentage >= 100f) CheckIfUpgradable(1) ;
                    break;
                
                case "Ice":

                    
                    break;
                
            }

            Destroy(enemy);
            Print();

        }

        private void Print()
        {
            Debug.Log("Fire Percentage = " + _firePercentage);
        }
        private void CheckIfUpgradable(int modelIndex)
        {
            foreach (Transform model in transform.GetChild(0))
            {
                model.gameObject.SetActive(false);
            }
            
            transform.GetChild(0).GetChild(modelIndex).gameObject.SetActive(true);

        }
    }
}