using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// this class let's us drag the icons belonging to the different objects
/// inside our hub for inventory
/// </summary>
public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    /// <summary>
    /// get item
    /// </summary>
    public IInventoryItem Item { get; set; }

    /// <summary>
    /// when dragging the icon receive mouse position for new mouse
    /// </summary>
    /// <param name="eventData"></param>
   public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// when dropping the icon set it back to the start place
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }
}
