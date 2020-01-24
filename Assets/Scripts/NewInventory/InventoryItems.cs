using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// interface that defines an item from inventory
/// </summary>
public interface IInventoryItem
    {
        string Name { get; }

        Sprite Image { get; }

        void OnPickup();

        void OnUse();

    }

/// <summary>
/// inventory event
/// </summary>
public class InventoryEventArgs : EventArgs
    {
        public InventoryEventArgs(IInventoryItem item)
        {
            Item = item;
        }
   
        public IInventoryItem Item;    
}

