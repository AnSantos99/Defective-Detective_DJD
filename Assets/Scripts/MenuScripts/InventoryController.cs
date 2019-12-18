/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public List<InventoryItem> characterItems = new List<InventoryItem>();
    [SerializeField] InventoryDatabase inventoryDatabase;
    [SerializeField] UIInventory inventoryUI;

    private void Start()
    {
        GiveItem(1);
        GiveItem(0);
        GiveItem(2);
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GiveItem(int id)
    {
        InventoryItem itemToAdd = inventoryDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.Name);
    }

    public InventoryItem CheckForItem(int id)
    {
        return characterItems.Find(item => item.ID == id);
    }

    public void RemoveItem(int id)
    {
        InventoryItem itemToRemove = CheckForItem(id);
        if(itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("item removed: " + itemToRemove.Name);
        }
    }
}
*/