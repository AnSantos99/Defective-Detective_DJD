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
    private const int _slots = 8;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemUsed;

    public void UseItem(IInventoryItem item)
    {
        if(ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));
        }
    }

    public void AddItem(IInventoryItem item)
    {
        if (mItems.Count < _slots)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if(collider.enabled)
            {
                collider.enabled = false;

                mItems.Add(item);

                item.OnPickup();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
