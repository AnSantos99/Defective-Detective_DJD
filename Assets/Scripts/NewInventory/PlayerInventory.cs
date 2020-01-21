using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;

    //private IInventoryItem item;

    private IInventoryItem mCurrentItem = null;

    private void Start()
    {
        //item = null;

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
