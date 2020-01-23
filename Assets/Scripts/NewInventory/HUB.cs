using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUB : MonoBehaviour
{ 
    public Inventory Inventory;

    public GameObject MessagePanel;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
           
            Image image = imageTransform.GetComponent<Image>();
           
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                itemDragHandler.Item = e.Item;

                break;
            }
                  

       
            }         
        
    }

    public void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        foreach(Transform slot in inventoryPanel)
        {
  
            Transform imageTransform = slot.GetChild(0).GetChild(0);
           

            Image image = imageTransform.GetComponent<Image>();
         

            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if(itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;
            }          
        }
    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true); 
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
}
