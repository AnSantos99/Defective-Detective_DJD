using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryToggler : InventoryItemBase
{
    private GameObject view;

    private ViewController viewScript;



    public GameObject InventoryComponents;

    void Start()
    {
      
    }

    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "zamazonKit";
        }
    }

    public override void OnUse()
    {
        //inventory.GetComponent<HUB>().enabled = true;
        //viewScript.InventoryIsActive = true;
    }
}
