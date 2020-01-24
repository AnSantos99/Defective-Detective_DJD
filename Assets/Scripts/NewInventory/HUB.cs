using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUB : MonoBehaviour
{ 
    /// <summary>
    /// this gets the player's inventory to show current items on hub
    /// </summary>
    public Inventory Inventory;

    /// <summary>
    /// this sets the messages every time the player is near item
    /// </summary>
    public GameObject MessagePanel;

    
    void Start()
    {
        // check for event changes
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    /// <summary>
    /// this will allow us to check for an event where an item is added to the
    /// inventory
    /// </summary>
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        // gets the inventory panel
        Transform inventoryPanel = transform.Find("InventoryPanel");

        // finds all slots in panel
        foreach (Transform slot in inventoryPanel)
        {

            // gets slot images
            Transform imageTransform = slot.GetChild(0).GetChild(0);
           
            Image image = imageTransform.GetComponent<Image>();
           
            // gets a handler to click on items
            ItemDragHandler itemDragHandler = 
                imageTransform.GetComponent<ItemDragHandler>();

            // checks if slot is empty and sets image
            if(!image.enabled)
            {
                // enable image with new item
                image.enabled = true;
                image.sprite = e.Item.Image;

                itemDragHandler.Item = e.Item;

                break;
            }
                  

       
            }         
        
    }

    /// <summary>
    /// this method allows us to show the message panel interactive text
    /// </summary>
    /// <param name="text"></param>
    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true); 
    }

    /// <summary>
    /// this method allows us to disable the message interactive text
    /// </summary>
    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
}
