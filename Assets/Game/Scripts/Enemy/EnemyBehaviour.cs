using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 
/// </summary>
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float stopDistance = 8f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private  float _timer = 0F;
    [SerializeField] private  float attackCoolDown = 5f;
    [SerializeField] private  bool attackAvailable = false;
    private string destinationTag = "Player";
    
    private GameObject _goalGameObject;
    NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _goalGameObject = GameObject.FindGameObjectWithTag(destinationTag).gameObject;
        AssignRandomTag();
    }
    
    void Update()
    {
        EnemyWalkBehaviour();
        Attack();
        
        if (gameObject.transform.position.y <= -5F)
        { Destroy(gameObject); }

    }

    private void AssignRandomTag()
    {
        int randomElement = Random.Range(1, 4);

        if (randomElement == 1)
        {
            gameObject.tag = "Fire";
        }
        else if (randomElement == 2)
        {
            gameObject.tag = "Ice";
        }
        else if (randomElement == 3)
        {
            gameObject.tag = "Stone";
        }
    }

    private void EnemyWalkBehaviour()
    {
        agent.stoppingDistance = stopDistance;
        agent.speed = speed;
        agent.destination = _goalGameObject.transform.position;
    }
    private void Attack()
    {
        if (!attackAvailable)
        {
            _timer += Time.deltaTime;

            if (_timer >= attackCoolDown)
            {
                _timer = 0f;
                attackAvailable = true;
            }

        }
        if (attackAvailable)
        {
            Debug.Log("attacked to " + _goalGameObject.name);
            attackAvailable = false;

        }
    }
}
