using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Slider healthSlider;



    void Start()
    {
        healthSlider = GetComponent<Slider>();
    }

   

    public void ChangeHealthMax (float MaxHealth = 10)
    {
        healthSlider.maxValue = MaxHealth;
    }

    public void ChangeActualHealth (float ActualHealth) 
    { 
        healthSlider.value = ActualHealth;
    }

    public void StartHealth (float ActualHealth)
    {
        ChangeActualHealth(ActualHealth);
        ChangeHealthMax(ActualHealth);
    }
}
