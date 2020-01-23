using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;

    public GameObject Hand;

    public GameObject GoItem;

    private bool RotActive;

    public ViewController vc;

    public HUB hub;

    public GameObject Elmo;

    public Transform tPosition, tRotation;

    private IInventoryItem mCurrentItem = null;

    RandomDialogues rD;

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
        if (Input.GetKeyDown(KeyCode.R) || !RotActive && GoItem != null)
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
       

        if (item.Name == "passwordReader")
        {
            item.OnUse();
            goItem = null;
        }

        if (item.Name == "book")
        {
            vc.ToggleInventory(true);
            GoItem = goItem;
        }

        else
        {

            goItem.SetActive(true);
            goItem.GetComponent<RotateObject>().enabled = true;
            goItem.transform.parent = Hand.transform;
            goItem.transform.localPosition = (item as InventoryItemBase).PickPosition;
            goItem.transform.localEulerAngles = (item as InventoryItemBase).PickRotation;

            GoItem = goItem;
        }

        
       
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        hub.OpenMessagePanel("");

    }

    void OnTriggerExit(Collider other)
    { 
        hub.CloseMessagePanel();
    }

    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();

        IInventoryItem currentItem = null;


        if (item != null && other.tag == "ZamazonKit")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                vc.ToggleKit(false);
                vc.InventoryIsActive = true;
                Instantiate(Elmo, tPosition, tRotation);

                //change of 'scene'
                if(rD.Scene_1 == true)
                {
                    rD.Scene_1 = false;
                    rD.Scene_2 = true;
                }
            }
        }

        if(vc.InventoryIsActive == true) 
        { 
            if (item != null && other.tag == "Pickable")
            {
                hub.OpenMessagePanel("");
            
                if (Input.GetKeyDown(KeyCode.F))
                {
                    inventory.AddItem(item);
                    item.OnPickup();
                }
            }

            if (item != null && other.tag == "Touchable")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    hub.OpenMessagePanel("");
                    item.OnUse();
                }
            }

        }

    }
}
