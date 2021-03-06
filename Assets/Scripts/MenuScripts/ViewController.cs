﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameObject inventory;
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject inputMenu;
    public GameObject bookPanel;
    public GameObject notesPanel;
    public GameObject zamazonKitPanel;

    public bool InputChecking;
    public bool passwordCorrect;

    public bool InventoryIsActive = false;

    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        InputChecking = false;
        passwordCorrect = false;
    }

    void Update()
    {
        if(!InputChecking)
            CheckInput();
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.I) && InventoryIsActive == true)
        {
            
            ToggleInventory(false);
            ShowMouseCursor();     
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu(false);
            ShowMouseCursor();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotes(false);
            ShowMouseCursor();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ToggleKit(false);
            ShowMouseCursor();
        }
    }

    // change to this later 
    /*
    public void ToggleComponent(bool condition, GameObject component)
    {
        InputChecking = !component.activeInHierarchy;
        inputMenu.SetActive(!component.activeInHierarchy);
        StopPlayerMotion(!component.activeInHierarchy);
    }
    */

    public void ToggleKit(bool condition)
    {
        InputChecking = !zamazonKitPanel.activeInHierarchy;
        zamazonKitPanel.SetActive(!zamazonKitPanel.activeInHierarchy);
        StopPlayerMotion(!zamazonKitPanel.activeInHierarchy);
    }

    public void ToggleInputPanel(bool condition)
    {
        InputChecking = !inputMenu.activeInHierarchy;
        inputMenu.SetActive(!inputMenu.activeInHierarchy);
        StopPlayerMotion(!inputMenu.activeInHierarchy);
    }

    public void ToggleBookPanel(bool condition)
    {
        InputChecking = !bookPanel.activeInHierarchy;
        bookPanel.SetActive(!bookPanel.activeInHierarchy);
        StopPlayerMotion(!bookPanel.activeInHierarchy);
    }

    
    public void TogglePauseMenu(bool condition)
    {
        InputChecking = !pauseMenu.activeInHierarchy;
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        StopPlayerMotion(!pauseMenu.activeInHierarchy);
    }

    public void ToggleNotes(bool condition)
    {
        InputChecking = !notesPanel.activeInHierarchy;
        notesPanel.SetActive(!notesPanel.activeInHierarchy);
        StopPlayerMotion(!notesPanel.activeInHierarchy);
    }

    public void ToggleInventory(bool condition)
    {
       // InputChecking = !inventory.activeInHierarchy;
        inventory.SetActive(!inventory.activeInHierarchy);
        StopPlayerMotion(!inventory.activeInHierarchy);
    }
    /*
    public void ToggleInventory(bool condition)
    {
        if (condition)
        {
            Time.timeScale = 0;
            ShowMouseCursor();
            inventory.SetActive(!inventory.activeInHierarchy);
        }

        else
        {
            Time.timeScale = 1.0f;
            HideMouseCursor();
        }       
    }
    */
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

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Screen.lockCursor = false;
    }

    public void HideMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Screen.lockCursor = true;
    }
}
