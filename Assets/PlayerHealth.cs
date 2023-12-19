using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TextMeshProUGUI munition;

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
        //DAÑO ENEMIGO
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy"))
            RecibirDaño(2);

        //CURACIÓN
        if (collision.gameObject.CompareTag("HealthPotion"))
            if (health < maxHealth)
            {
                health += 2;
                healthBar.ChangeActualHealth(health);

                audio.Play();
                Destroy(collision.gameObject);
            }

        //MUNICION
        if (collision.gameObject.CompareTag("Munition"))
        {
            municion.cantidadMunicionActual += 2;
            munition.text = municion.cantidadMunicionActual.ToString();


            audio.Play();
            Destroy(collision.gameObject);
        }
    }


    //CAMBIO DE ESCENA
    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
