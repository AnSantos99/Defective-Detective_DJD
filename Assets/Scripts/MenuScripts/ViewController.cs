﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameObject inventory;
    public GameObject player;
    public GameObject pauseMenu;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu(false);
        }
    }

    public void TogglePauseMenu(bool condition)
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        Cursor.visible = pauseMenu.activeInHierarchy;
        StopPlayerMotion(!pauseMenu.activeInHierarchy);
    }

    public void ToggleInventory(bool condition)
    {

        if (condition)
        {
            Time.timeScale = 0;
            ShowMouseCursor();
        }

        else
        {
            Time.timeScale = 1.0f;
            HideMouseCursor();

        }

        inventory.SetActive(!inventory.activeInHierarchy);
        Cursor.visible = inventory.activeInHierarchy;
        StopPlayerMotion(!inventory.activeInHierarchy);
    }

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
            ShowMouseCursor();
        }
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}