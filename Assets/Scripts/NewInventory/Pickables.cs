using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickables : InventoryItemBase
{
    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "test";
        }
    }

    public override void OnUse()
    {
        // COMBINE LOGIC
        base.OnUse();
    }
}
