/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryItem Item;
    private Image spriteImg;
    private UIItem selectedItem;
    private Tooltip tooltip;

    private void Awake()
    {
        spriteImg = GetComponent<Image>();
        UpdateItem(null);
        //selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        //tooltip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
     }

    public void UpdateItem(InventoryItem item)
    {
        Item = item;
        if(Item != null)
        {
            spriteImg.color = Color.white;
            spriteImg.sprite = Item.Image;
        }

        else
        {
            spriteImg.color = Color.clear;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Item != null)
        {
            if(selectedItem.Item != null)
            {
                InventoryItem clone = new InventoryItem(selectedItem.Item);
                selectedItem.UpdateItem(Item);
                UpdateItem(clone);
            }

            else
            {
                selectedItem.UpdateItem(Item);
                UpdateItem(null);
            }
        }

        else if(selectedItem.Item != null)
        {
            UpdateItem(selectedItem.Item);
            selectedItem.UpdateItem(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item != null)
            tooltip.GenerateTooltip(Item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //tooltip.gameObject.SetActive(false);
    }
}
*/