using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiferentDialogues : MonoBehaviour
{
    public GameObject oldChick;
    public GameObject newChicks;

    public bool Scene_1 = true;
    public bool Scene_2 = false;

    public PlayerInventory pi;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Scene_1 != pi.s_1 || Scene_2 != pi.s_2)
        {
            Scene_1 = pi.s_1;
            Scene_2 = pi.s_2;
        }
        ChangeChar();
    }

    public void ChangeChar()
    {
        if (Scene_1 == false && Scene_2 == true)
        {
            oldChick.SetActive(false);
            newChicks.SetActive(true);
        }
        else
        {
            oldChick.SetActive(true);
            newChicks.SetActive(false);
        }
    }
}
