using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("VIDA")]
    [SerializeField] float health;
    [SerializeField] float maxHealth;

    [Header("BARRA DE VIDA")]
    [SerializeField] Health healthBar;

    [Header("MUNICION")]
    public Cañon municion;

    private new AudioSource audio;



    void Start()
    {
        health = maxHealth;
        healthBar.StartHealth(health);


        audio = GetComponent<AudioSource>();
    }



    public void RecibirDaño(float damage)
    {
        health -= damage;

        healthBar.ChangeActualHealth(health);

        if (health <= 0)
        {
            ChangeScene(2);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy"))
            RecibirDaño(2);

        if (collision.gameObject.CompareTag("HealthPotion"))
            if (health < maxHealth)
            {
                health += 2;
                healthBar.ChangeActualHealth(health);

                audio.Play();
                Destroy(collision.gameObject);
            }


        if (collision.gameObject.CompareTag("Munition"))
        {
            municion.cantidadMunicionActual += 2;


            audio.Play();
            Destroy(collision.gameObject);
        }
    }



    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
