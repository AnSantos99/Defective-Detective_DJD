using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class allows us to show a game over scene when the player hits a 
/// trigger set on a collider
/// </summary>
public class GameOver : MonoBehaviour
{
    /// <summary>
    /// the game over panel
    /// </summary>
    public GameObject gameOver;

    void OnTriggerEnter()
    {
        // set active panel
        gameOver.SetActive(true);

        // set active cursor
        Cursor.visible = gameOver.activeInHierarchy;

        // stop time
        Time.timeScale = 0;
    }
}
