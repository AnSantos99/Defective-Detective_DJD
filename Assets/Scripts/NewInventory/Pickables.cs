using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// this class let's us set a basic Pickable object for later changing methods
/// </summary>
public class Pickables : InventoryItemBase
{
    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "base";
        }
    }

    public override void OnUse()
    {
        base.OnUse();
    }
}
