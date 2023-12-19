using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cañon : MonoBehaviour
{

    [Header("SPAWN DE BALAS")]
    public Bullet bulletPrefab;
    [SerializeField] Transform spawn;


    [Header("MUNICION")]
    public int cantidadMunicionActual;
    [SerializeField] int cantidadMunicionMax = 50;
    [SerializeField] TextMeshProUGUI munition;


    [Header("CAMARA")]
    [SerializeField] Camera cam;

    [Header("ANIMACIÓN")]
    Animator animator;



    private void Start()
    {
        animator = GetComponent<Animator>();

        cantidadMunicionActual = cantidadMunicionMax;
        UpdateText();
    }



    void Update()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
       
        transform.up = direction;


        if (Input.GetMouseButtonDown(0) && cantidadMunicionActual > 0)
        {
            Shoot();
            

            animator.SetBool("PlayerShoot", true);
        }
        else
            animator.SetBool("PlayerShoot", false);
    }



    public void Shoot()
    {
        Bullet projectile = Instantiate(bulletPrefab, spawn.position, transform.rotation);
        projectile.LaunchBullet(transform.up);

        cantidadMunicionActual--;
        UpdateText();
    }


    void UpdateText()
    {
        munition.text = cantidadMunicionActual.ToString();
    }
}


