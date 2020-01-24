using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// this class let's us make a specific item key that can be picked up and used
/// to open a door
/// </summary>
public class KeyPickable : InventoryItemBase
{
    /// <summary>
    /// get door animator for toggle
    /// </summary>
    public Animator doorAnim;

    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "key";
        }
    }

    /// <summary>
    /// open the door when used
    /// </summary>
    public override void OnUse()
    {

       doorAnim.SetBool("DoorOpen", true);    
        
    }
}
