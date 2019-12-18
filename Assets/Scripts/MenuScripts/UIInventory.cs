/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> UIItems = new List<UIItem>();
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Transform slotPanel;
    [SerializeField]  int numberOfSlotsInInventory = 16;

    private void Awake()
    {
        for(int i = 0; i < numberOfSlotsInInventory; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            UIItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    public void UpdateSlot(int slot, InventoryItem item)
    {
        UIItems[slot].UpdateItem(item);
    }
    
    public void AddNewItem(InventoryItem item)
    {
        UpdateSlot(UIItems.FindIndex(i => i.Item == null), item);
    }

    public void RemoveItem(InventoryItem item)
    {
        UpdateSlot(UIItems.FindIndex(i => i.Item == item), null);
    }
}
*/