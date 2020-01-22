using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;

    public GameObject Hand;

    public GameObject GoItem;

    private bool RotActive;

    //private IInventoryItem item;

    private IInventoryItem mCurrentItem = null;

    private void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
        RotActive = true;

    }

    public void Activate(bool rotActive)
    {
        RotActive= rotActive;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || !RotActive)
        {
            GoItem.SetActive(false);

            GoItem.GetComponent<RotateObject>().enabled = true;

            RotActive = true;
        }
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

        GoItem = goItem;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {

        IInventoryItem item = other.GetComponent<IInventoryItem>();

        IInventoryItem currentItem = null;

        if (item != null && other.tag == "Pickable")
        {
            inventory.AddItem(item);
            Debug.Log("ouch");
        }

        
    }
}
