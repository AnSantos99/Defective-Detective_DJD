using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordInteractable : InventoryItemBase
{
    private GameObject view;
    private ViewController viewScript;

    void Start()
    {
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();
    }

    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "passwordReader";
        }
    }

    public override void OnUse()
    {
        if (viewScript.passwordCorrect == false)
            viewScript.ToggleInputPanel(false);
    }

  
    
}
