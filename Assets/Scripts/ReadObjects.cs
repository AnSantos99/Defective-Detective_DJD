using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadObjects : MonoBehaviour
{
    //public GameObject displayImage;
    private GameObject view;
    private ViewController viewScript;



    void Start()
    {
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();
    }

    void OnTouch()
    {       
        viewScript.ToggleInputPanel(false);
    }

    void UnTouch()
    {
        viewScript.ToggleInputPanel(true);
    }
}
