using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] string FirstSceneName;

    [SerializeField] GameObject MainPanel;

    [SerializeField] GameObject SettingsPanel;

    [SerializeField] GameObject InstructionsPanel;

    [SerializeField] GameObject CreditsPanel;

    public void Awake()
    {
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

   public void ButtonStart()
    {
        SceneManager.LoadScene(FirstSceneName);
    }

    public void ButtonSettingsOpen()
    {
        SettingsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void ButtonSettingsClose()
    {
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void ButtonInstructionsOpen()
    {
        InstructionsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void ButtonInstructionsClose()
    {
        InstructionsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void ButtonCreditsOpen()
    {
        MainPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void ButtonCreditsClose()
    {
        CreditsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
