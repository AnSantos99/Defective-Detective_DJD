﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int _slots = 8;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemRemoved;

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

    public void RemoveItem(IInventoryItem item)
    {
        if (mItems.Contains(item))
        {
            mItems.Remove(item);

            item.OnDrop();

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider != null)
            {
                collider.enabled = true;       
            }

            if(ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }

        }
    }
}
