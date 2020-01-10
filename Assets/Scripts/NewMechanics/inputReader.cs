﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inputReader : MonoBehaviour
{
    public TMP_InputField input;

    public GameObject Door;

    private Animator doorAnim;

    private GameObject view;
    private ViewController viewScript;

    void Start()
    {
        doorAnim = Door.GetComponent<Animator>();
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();
    }

    public void GetInput()
    {
        if (input.text == "yes")
        {
            Debug.Log("Correct!");
            input.text = "";
            doorAnim.SetBool("DoorOpen", true);
            viewScript.passwordCorrect = true;
            viewScript.ToggleInputPanel(false);
            
        }

        else
        {
            Debug.Log("Incorrect!!");
        }
    }
}
