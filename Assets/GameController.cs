using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Score score;
    public PlayerHealth changeScene;


    void Update()
    {
        if (score.puntos == 10)
            changeScene.ChangeScene(3);
    }
}
