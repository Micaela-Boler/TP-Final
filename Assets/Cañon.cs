using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public Bullet bulletPrefab;
    [SerializeField] Transform spawn;

    [SerializeField] Camera cam;

    void Update()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;

        transform.up = direction;

        if(Input.GetMouseButtonDown(0))
        {
            Bullet projectile = Instantiate(bulletPrefab, spawn.position, transform.rotation);
            projectile.LaunchBullet(transform.up);
        } 
    }
}
