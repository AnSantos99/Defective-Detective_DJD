using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// this class allows us to handle the hub related clicking events in the
/// inventory
/// </summary>
public class ItemClickHandler : MonoBehaviour
{
    /// <summary>
    /// gets inventory
    /// </summary>
    public Inventory _Inventory;

    /// <summary>
    /// gets keycode of item
    /// </summary>
    public KeyCode _Key;

    /// <summary>
    /// gets current item button
    /// </summary>
    private Button _button;

    void Awake()
    { 
        // get button component
        _button = GetComponent<Button>();
    }

    void Update()
    {
        // if key gets pressed
        if(Input.GetKeyDown(_Key))
        {
           // invoke the on click of the button in question
            _button.onClick.Invoke();
        }
    }
    
    /// <summary>
    /// this method let's us set the item on use
    /// </summary>
    private IInventoryItem AttachedItem

    {
        get
        {
            ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage")
                .GetComponent<ItemDragHandler>();

            return dragHandler.Item;
        }
    }

    /// <summary>
    /// this method let's us manipulate the selected item
    /// </summary>
    public void OnItemClicked()
    {
        IInventoryItem item = AttachedItem;

        if(item != null)
        {
            _Inventory.UseItem(item);

            item.OnUse();
        }
    }
}
