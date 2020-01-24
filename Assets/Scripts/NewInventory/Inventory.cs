using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class sets the inventory for the player with the limited slot number
/// and handles events to add and use
/// </summary>
public class Inventory : MonoBehaviour
{
    /// <summary>
    /// sets maxnumber of slots
    /// </summary>
    private const int _slots = 8;

    /// <summary>
    /// gets list of items in inventory
    /// </summary>
    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    /// <summary>
    /// check for event of item was added
    /// </summary>
    public event EventHandler<InventoryEventArgs> ItemAdded;

    /// <summary>
    /// check for event of item was used
    /// </summary>
    public event EventHandler<InventoryEventArgs> ItemUsed;

    /// <summary>
    /// method to use item and set new event
    /// </summary>
    /// <param name="item">current item</param>
    public void UseItem(IInventoryItem item)
    {
        if(ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));
        }
    }

    /// <summary>
    /// this method lets us add an item to our inventory 
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(IInventoryItem item)
    {
        // check for available slots
        if (mItems.Count < _slots)
        {
            // get item collider
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            // disable item collider
            if(collider.enabled)
            {
                collider.enabled = false;

                // add item to inventory 
                mItems.Add(item);

                // execute on pickup action
                item.OnPickup();

                // create new event
                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
