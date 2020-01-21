using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory _Inventory;

    public void OnItemClicked()
    {
        ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

        IInventoryItem item = dragHandler.Item;

        Debug.Log("click");
        Debug.Log(item.Name);

        _Inventory.UseItem(item);


        item.OnUse();

        // activate rotation script on object until keypress
        //activate when object is clicked on inventory

    }
}
