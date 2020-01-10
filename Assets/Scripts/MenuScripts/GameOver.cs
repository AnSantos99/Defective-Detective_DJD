using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    void OnTriggerEnter()
    {
        gameOver.SetActive(true);
        Cursor.visible = gameOver.activeInHierarchy;
        Time.timeScale = 0;
    }
}
