using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inputReader : MonoBehaviour
{

    //public ViewController view;

    public TMP_InputField input;

    public void GetInput()
    {
        if (input.text == "yes")
        {
            Debug.Log("Correct!");
            input.text = "";
        }

        else
        {
            Debug.Log("Incorrect!!");
        }
    }
}
