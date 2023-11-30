using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MoveZombie : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;   
    }

  
    void Update()
    {
        if (!target) GetTarget();

        agent.SetDestination(target.position);
    }

    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
