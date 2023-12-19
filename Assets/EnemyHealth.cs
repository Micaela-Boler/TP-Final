using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [Header("VIDA")]
    [SerializeField] float health;
    [SerializeField] float maxHealth;

    [Header("COLECCIONABLES")]
    [SerializeField] GameObject randomDrop;
    public GameObject[] obstacles;
    int randomIndex;

    [Header("ANIMACION")]
    Animator animator;



    void Start()
    {
        health = maxHealth;


        animator = GetComponent<Animator>();
    }


    private void RecibirDaño(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            EnemyDrop();
            Destroy(gameObject);
        }
    }


    private void EnemyDrop()
    {
        randomIndex = Random.Range(0, obstacles.Length);
        randomDrop = obstacles[randomIndex];

        Instantiate(randomDrop, transform.position, Quaternion.identity);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            RecibirDaño(1);


        if (collision.gameObject.CompareTag("Player"))
            animator.SetBool("PlayerCollision", true);
    }
}
