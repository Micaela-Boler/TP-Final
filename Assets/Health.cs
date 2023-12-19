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

   
    //Establece el valor m�ximo del slider
    public void ChangeHealthMax (float MaxHealth = 10)
    {
        healthSlider.maxValue = MaxHealth;
    }

    //Cambia el valor del slider por el actual
    public void ChangeActualHealth (float ActualHealth) 
    { 
        healthSlider.value = ActualHealth;
    }

    //El valor inicial y maximo del slider es igual a la cantidad de vida actual
    public void StartHealth (float ActualHealth)
    {
        ChangeActualHealth(ActualHealth);
        ChangeHealthMax(ActualHealth);
    }
}
