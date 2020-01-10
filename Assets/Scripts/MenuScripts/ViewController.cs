using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameObject inventory;
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject inputMenu;
    public GameObject bookPanel;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory(false);
            ShowMouseCursor();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu(false);
            ShowMouseCursor();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleInputPanel(false);
            ShowMouseCursor();
        }
    }

    public void ToggleInputPanel(bool condition)
    {
        inputMenu.SetActive(!inputMenu.activeInHierarchy);
        StopPlayerMotion(!inputMenu.activeInHierarchy);
    }

    public void ToggleBookPanel(bool condition)
    {
        bookPanel.SetActive(!bookPanel.activeInHierarchy);
        StopPlayerMotion(!bookPanel.activeInHierarchy);
    }

    public void TogglePauseMenu(bool condition)
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        StopPlayerMotion(!pauseMenu.activeInHierarchy);
    }

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
