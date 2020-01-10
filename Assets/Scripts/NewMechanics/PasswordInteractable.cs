using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordInteractable : MonoBehaviour
{
    private GameObject view;
    private ViewController viewScript;

    void Start()
    {
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();
    }

    void OnTouch()
    {   if(viewScript.passwordCorrect == false)
            viewScript.ToggleInputPanel(false);
    }

    void UnTouch()
    {
        viewScript.ToggleInputPanel(true);
    }
    
}
