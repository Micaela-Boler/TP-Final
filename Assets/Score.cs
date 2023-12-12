using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int puntos;
    [SerializeField] TextMeshProUGUI puntosInterfaz;

    private new AudioSource audio;



    void Start()
    {
        audio = GetComponent<AudioSource>();

        updateScore();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coleccionable"))
        {
            puntos++;
            updateScore();

            audio.Play();
            Destroy(collision.gameObject);
        }
    }
    
    

    void updateScore()
    {
        puntosInterfaz.text = puntos.ToString();
    }
}
