using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] string StartMenuScene;
    [SerializeField] string GameOverMenuScene;
    [SerializeField] string GameWonMenuScene;


    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(StartMenuScene, LoadSceneMode.Additive);
    }
}
