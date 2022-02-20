using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string destinationTag = "Player";
    [Range(0.0F, 10.0F)]
    public float stopDistance = 1f;

    [Range(0.0F, 20.0F)]
    public float speed = 3.5f;

    public float _timer = 0F;
    public float attackCoolDown = 5F;
    public bool attackAvailable = false;

    private GameObject goalGameObject;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goalGameObject = GameObject.FindGameObjectWithTag(destinationTag).gameObject;


    }

    // Update is called once per frame
    void Update()
    {

        agent.stoppingDistance = stopDistance;
        agent.speed = speed;
        agent.destination = goalGameObject.transform.position;

        if (!attackAvailable)
        {
            _timer += Time.deltaTime;

            if (_timer >= attackCoolDown)
            {
                _timer = 0f;
                attackAvailable = true;
            }

        }

        if (this.gameObject.transform.position.y <= -5F)
        { Destroy(this.gameObject); }

    }

    void Attack()
    {
        if (attackAvailable)
        {
            Debug.Log("attacked to " + goalGameObject.name);
            attackAvailable = false;

        }
    }
}
