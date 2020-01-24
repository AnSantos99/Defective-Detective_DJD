using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class let's us get a generic type of item for our inventory
/// </summary>
public class InventoryItemBase : MonoBehaviour, IInventoryItem
{
    /// <summary>
    /// the name of the item
    /// </summary>
    public virtual string Name
    {
        get
        {
            return "base_item";
        }
    }

    /// <summary>
    /// the icon for the item in inventory
    /// </summary>
    public Sprite _Image;
    
    public Sprite Image
    {
        get { return _Image; }
    }

    /// <summary>
    /// base for overrides
    /// </summary>
    public virtual void OnUse()
    {

    }

    /// <summary>
    /// set object to inactive when picked up
    /// </summary>
    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
