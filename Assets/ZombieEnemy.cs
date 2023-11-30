using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZomEnemy : MonoBehaviour
{
   // NavMeshAgent agent;

    public float speed = 2.5f;
    public float rotateSpeed = 0.0030f;
    public Transform target;
    public Rigidbody2D rb;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        //agent.updateRotation = false;
        //agent.updateUpAxis = false;   
    }

    
    void Update()
    {
        if (!target) GetTarget();
        else Rotation();
        


        //agent.SetDestination(target.position);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void Rotation()
    {
        Vector2 targetDirection = target.position - transform.position;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion qua = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, qua, rotateSpeed);

    }

    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
