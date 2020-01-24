using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// this class lets us toggle the inventory on and off using the zamazon kit
/// </summary>
public class InventoryToggler : InventoryItemBase
{
    /// <summary>
    /// get the viewcontroller and script
    /// </summary>
    private GameObject view;

    private ViewController viewScript;

    // set name
    public override string Name
    {
        get
        {
            return "zamazonKit";
        }
    }

    public override void OnUse()
    {
       
    }
}
