using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDialogues : MonoBehaviour
{
    public GameObject[] objectPool;
    private int currentIndex = 0;

    public GameObject SceneManag_1;
    public GameObject SceneManag_2;

    public bool Scene_1 = true;
    public bool Scene_2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandomDialog();
    }

    public void RandomDialog()
    {
        if(Scene_1 == true)
        {
            SceneManag_1.SetActive(true);
            int newIndex = Random.Range(0, objectPool.Length);
            objectPool[currentIndex].SetActive(false);
            currentIndex = newIndex;
            objectPool[currentIndex].SetActive(true);
        }

        if (Scene_2 == true)
        {
            SceneManag_2.SetActive(true);
            int newIndex = Random.Range(0, objectPool.Length);
            objectPool[currentIndex].SetActive(false);
            currentIndex = newIndex;
            objectPool[currentIndex].SetActive(true);
        }
    }
}
