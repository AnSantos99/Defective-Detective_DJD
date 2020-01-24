using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class let's us control our current player's inventory
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    /// <summary>
    /// gets inventory from scene
    /// </summary>
    public Inventory inventory;

    /// <summary>
    /// let's us place objects for view and rotate in front of player
    /// </summary>
    public GameObject Hand;

    /// <summary>
    /// item in hand
    /// </summary>
    public GameObject GoItem;

    /// <summary>
    /// check if rotation script is active
    /// </summary>
    private bool RotActive;

    /// <summary>
    /// view controller to set panels
    /// </summary>
    public ViewController vc;

    /// <summary>
    /// hub to toggle and control inventory
    /// </summary>
    public HUB hub;

    /// <summary>
    /// call dead chicken prefab
    /// </summary>
    public GameObject Elmo;

    /// <summary>
    /// get broom to fall down
    /// </summary>
    public GameObject Broom;

    /// <summary>
    /// get doors
    /// </summary>
    public GameObject DoorStorage;

    public GameObject DoorZen;

    public GameObject DoorLivingRoom;

    /// <summary>
    /// get door trigger
    /// </summary>
    public TriggerDoorLock trigger;

    /// <summary>
    /// to open door
    /// </summary>
    public int counter = 0;

    /// <summary>
    /// getting random dialogue
    /// </summary>
    RandomDialogues rD;

    /// <summary>
    /// check if door is closed, open and if broom is falling
    /// </summary>
    public bool doorClosed;
    public bool doorOpen;
    public bool broomFall;

    private void Start()
    {
        // getting event
        inventory.ItemUsed += Inventory_ItemUsed;

        // set rotation to true
        RotActive = false;
    }

    /// <summary>
    /// activate or deactivate rotation
    /// </summary>
    /// <param name="rotActive"></param>
    public void Activate(bool rotActive)
    {
        RotActive = rotActive;
    }

    private void Update()
    {      
        // checking if player has untoggled rotation
        if (Input.GetKeyDown(KeyCode.R) || !RotActive && GoItem != null)
        {
            // disable item
            GoItem.SetActive(false);

            // enable script
            GoItem.GetComponent<RotateObject>().enabled = true;

            // set rotactive to true
            RotActive = true;
        }
    }

    /// <summary>
    /// this method let's us check when item is being used
    /// </summary>
    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        // get itemm from inventory event
        IInventoryItem item = e.Item;

        // current item
        GameObject goItem;

        // check item's name for password actions toggle
        if (item.Name == "passwordReader")
        {
            // set item as monobehaviour for manipulation
            goItem = (item as MonoBehaviour).gameObject;
            item.OnUse();
            goItem = null;
        }

        if (item.Name == "book")
        {
            goItem = (item as MonoBehaviour).gameObject;

            vc.ToggleInventory(true);
            GoItem = goItem;
            Broom.GetComponent<Animator>().SetBool("Fall", true);
            DoorStorage.GetComponent<Animator>().SetBool("DoorOpen", true);
            broomFall = true;

            //FindOjbectOfType<AudioSource>().Play("Fallingbroom");
        }

        // for items without problems
        else
        {
            goItem = (item as MonoBehaviour).gameObject;

            goItem.SetActive(true);
            goItem.GetComponent<RotateObject>().enabled = true;
            goItem.transform.parent = Hand.transform;
            goItem.transform.localPosition = 
                (item as InventoryItemBase).PickPosition;
            goItem.transform.localEulerAngles = 
                (item as InventoryItemBase).PickRotation;

            GoItem = goItem;
        }

        GoItem = goItem;
    }

    // check collision for toggle of hub
    void OnTriggerEnter(Collider other)
    {
        hub.OpenMessagePanel("");

    }

    void OnTriggerExit(Collider other)
    { 
        hub.CloseMessagePanel();
    }

    // check collision for actions depending on the type of interactable
    void OnTriggerStay(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();

        IInventoryItem currentItem = null;


        if (item != null && other.tag == "ZamazonKit")
        {
            trigger.GetComponent<BoxCollider>().enabled = true;
            doorClosed = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                vc.ToggleKit(false);
                vc.InventoryIsActive = true;
                Instantiate(Elmo);

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

            // check if interacting with touchable items
            if (item != null && other.tag == "Touchable")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    hub.OpenMessagePanel("");
                    item.OnUse();
                }
            }
          
            // check if interacting with images
            if (item != null && other.tag == "PictureClues")
            {
                counter+=1;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    inventory.AddItem(item);
                    item.OnPickup();

                    GameObject iitem = GameObject.Find(item.Name);
                    iitem.GetComponent<SpriteRenderer>().enabled=true;
                 
                    Destroy(other);
     
                    hub.OpenMessagePanel("");

                    Debug.Log(counter);
                }
            }

            if(counter >= 4)
            {
                DoorLivingRoom.GetComponent<Animator>().SetBool("DoorOpen", true);
                doorOpen = true;
            }

        }

    }
}
