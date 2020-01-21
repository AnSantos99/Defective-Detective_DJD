using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;

    public GameObject Hand;

    //private IInventoryItem item;

    private IInventoryItem mCurrentItem = null;

    private void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;

    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;       

        goItem.SetActive(true);

        goItem.GetComponent<RotateObject>().enabled = true;

        goItem.transform.parent = Hand.transform;
        goItem.transform.localPosition = (item as InventoryItemBase).PickPosition;
        goItem.transform.localEulerAngles = (item as InventoryItemBase).PickRotation;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        //IInventoryItem item = other.GameObject.FindGameObjectWithTag("Pickable");

        //GameObject Collide = other.GetComponent.FindWithTag("Pickable");


        IInventoryItem item = other.GetComponent<IInventoryItem>();

        IInventoryItem currentItem = null;

        if (item != null && other.tag == "Pickable")
        {
            inventory.AddItem(item);
            Debug.Log("ouch");
        }

        
    }
}
