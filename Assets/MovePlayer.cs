using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float horizontal;
    float vertical;
    public int speed;

    Vector2 movement;

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical );
        movement.Normalize();

        transform.Translate(movement * Time.deltaTime * speed);
    }
}
