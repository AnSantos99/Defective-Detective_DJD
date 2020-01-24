using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class's purpose is to control the view by toggling
/// the different panels presented to the player depending on the game's status
/// </summary>
public class ViewController : MonoBehaviour
{
    /// <summary>
    /// get the inventory panel
    /// </summary>
    public GameObject inventory;

    /// <summary>
    /// get the player
    /// </summary>
    public GameObject player;

    /// <summary>
    /// get the pause menu panel
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// get the input menu panel
    /// </summary>
    public GameObject inputMenu;

    /// <summary>
    /// get the book panel
    /// </summary>
    public GameObject bookPanel;

    /// <summary>
    /// get the notes panel
    /// </summary>
    public GameObject notesPanel;

    /// <summary>
    /// get the zamazon kit image
    /// </summary>
    public GameObject zamazonKitPanel;

    /// <summary>
    /// verifi if there's input being checked
    /// </summary>
    public bool InputChecking;

    /// <summary>
    /// verify if the input password is correct
    /// </summary>
    public bool passwordCorrect;

    /// <summary>
    /// set the inventory to false until it gets activated
    /// </summary>
    public bool InventoryIsActive = false;

    void Start()
    {
        
        // sets cursor visibility to false for locking
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // sets timescale to 1 for normal time on frames
        Time.timeScale = 1;

        // set input checking to false while panel inactive
        InputChecking = false;

        // set password correct to false until correct input
        passwordCorrect = false;
    }

    void Update()
    {
        // lock input checking if it shouldn't be read
        if(!InputChecking && InventoryIsActive == true)
            CheckInput();
    }

    /// <summary>
    /// this method allows us to check for user input
    /// </summary>
    public void CheckInput()
    {
        // if I key got pressed toggle inventory
        if (Input.GetKeyDown(KeyCode.I) && InventoryIsActive == true)
        { 
            ToggleInventory(false);
            ShowMouseCursor();     
        }

        // if P key got pressed toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu(false);
            ShowMouseCursor();
        }

        // if Z key got pressed toggle zamazon image
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ToggleKit(false);
            ShowMouseCursor();
        }
    }

    /// <summary>
    ///  this method toggles zamazon kit
    /// </summary>
    /// <param name="condition">check if true or false</param>
    public void ToggleKit(bool condition)
    {
        InputChecking = !zamazonKitPanel.activeInHierarchy;
        zamazonKitPanel.SetActive(!zamazonKitPanel.activeInHierarchy);
        StopPlayerMotion(!zamazonKitPanel.activeInHierarchy);
    }

    /// <summary>
    /// this method toggles input panel
    /// </summary>
    /// <param name="condition">check condition</param>
    public void ToggleInputPanel(bool condition)
    {
        InputChecking = !inputMenu.activeInHierarchy;
        inputMenu.SetActive(!inputMenu.activeInHierarchy);
        StopPlayerMotion(!inputMenu.activeInHierarchy);
    }


    /// <summary>
    /// this method toggles book panel
    /// </summary>
    /// <param name="condition">check condition</param>
    public void ToggleBookPanel(bool condition)
    {
        InputChecking = !bookPanel.activeInHierarchy;
        bookPanel.SetActive(!bookPanel.activeInHierarchy);
        StopPlayerMotion(!bookPanel.activeInHierarchy);
    }


    /// <summary>
    /// this method toggles pause menu
    /// </summary>
    /// <param name="condition">check condition</param>
    public void TogglePauseMenu(bool condition)
    {
        InputChecking = !pauseMenu.activeInHierarchy;
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        StopPlayerMotion(!pauseMenu.activeInHierarchy);
    }



    /// <summary>
    /// this method toggles inventory panel
    /// </summary>
    /// <param name="condition">check condition</param>
    public void ToggleInventory(bool condition)
    {
       // InputChecking = !inventory.activeInHierarchy;
        inventory.SetActive(!inventory.activeInHierarchy);
        StopPlayerMotion(!inventory.activeInHierarchy);
    }
  
    /// <summary>
    /// this method sets timescale to 0 and shows cursor to toggle movement
    /// </summary>
    /// <param name="condition"></param>
    void StopPlayerMotion(bool condition)
    {
        if (!condition)
        {
            Time.timeScale = 0;
            ShowMouseCursor();
        }

        else
        {
            Time.timeScale = 1.0f;
            HideMouseCursor();
        }
    }

    /// <summary>
    /// this method lets us show  the cursor in panels
    /// </summary>
    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Screen.lockCursor = false;
    }

    /// <summary>
    /// this method lets us hide the cursor in panels
    /// </summary>
    public void HideMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Screen.lockCursor = true;
    }
}
