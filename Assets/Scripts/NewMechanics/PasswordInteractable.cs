using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class allows us to access the interactable password as an inventory 
/// item for manipulation as an interactable
/// </summary>
public class PasswordInteractable : InventoryItemBase
{
    /// <summary>
    /// get the viewcontroller and script to show on panel
    /// </summary>
    private GameObject view;
    private ViewController viewScript;

    void Start()
    {
        // get the view manager from the scene
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();
    }


    /// <summary>
    /// set the name of the password reader
    /// </summary>
    public override string Name
    {
        get
        {
            return "passwordReader";
        }
    }

    /// <summary>
    /// when using, check for input
    /// </summary>
    public override void OnUse()
    {
        if (viewScript.passwordCorrect == false)
            viewScript.ToggleInputPanel(false);
    }

  
    
}
