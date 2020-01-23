using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyPickable : InventoryItemBase
{
    public Animator doorAnim;

    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "key";
        }
    }

    public override void OnUse()
    {

       doorAnim.SetBool("DoorOpen", true);
        
        
    }
}
