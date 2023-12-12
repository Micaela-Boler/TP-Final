using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]

    NavMeshAgent agent;
    [SerializeField] Transform target;

    public float rotateSpeed = 0.1f;


    [Header("Shoot")]

    public Bullet bulletPrefab;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;

    public Transform firingPoint;
    public float fireRate;
    float timeToFire;
    
    Animator animator;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;


        animator = GetComponent<Animator>();
    }



    void Update()
    {
        // Encuentra al jugador y gira hacia él
        if (!target) GetTarget();
        else Rotation();

        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) <= distanceToStop)
            {
                agent.SetDestination(transform.position); // Deja de seguir al jugador

                EnemyShoot();
                animator.SetBool("EnemyShoot", true);

            }
            else
            {
                agent.SetDestination(target.position); // Sigue al jugador
                animator.SetBool("EnemyShoot", false);
            }
        }
    }



    private void EnemyShoot()
    {
        if (timeToFire <= 0f) 
        {
            Bullet projectile = Instantiate(bulletPrefab, firingPoint.position, transform.rotation);
            projectile.LaunchBullet(transform.up);

            timeToFire = fireRate; // Resetea el tiempo de disparo
        }
        else { timeToFire -= Time.deltaTime; }
    }


    public void GetTarget()
    {
        // Busca al jugador
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void Rotation()
    {
        //Enemigo rota hacia el jugador
        Vector2 targetDirection = target.position - transform.position;

        //Suavizar la rotación
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion qua = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, qua, rotateSpeed);
    }
}
