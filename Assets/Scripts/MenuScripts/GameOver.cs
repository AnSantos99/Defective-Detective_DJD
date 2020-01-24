using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] string gameOverScene;

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(gameOverScene);
    }
}
