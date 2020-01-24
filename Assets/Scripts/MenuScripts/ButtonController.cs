using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// this class let's us control the different buttons
/// </summary>
public class ButtonController : MonoBehaviour
{
    /// <summary>
    /// get string of the first scene
    /// </summary>
    [SerializeField] string FirstSceneName;

    /// <summary>
    /// get main panel
    /// </summary>
    [SerializeField] GameObject MainPanel;

    /// <summary>
    /// instructions panel
    /// </summary>
    [SerializeField] GameObject InstructionsPanel;

    /// <summary>
    /// credits panel
    /// </summary>
    [SerializeField] GameObject CreditsPanel;

    public void Awake()
    {
        MainPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    /// <summary>
    /// start game scene
    /// </summary>
   public void ButtonStart()
    {
        SceneManager.LoadScene(FirstSceneName);
    }

    /// <summary>
    /// change to instructions panel
    /// </summary>
    public void ButtonInstructionsOpen()
    {
        InstructionsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    /// <summary>
    /// close instructions panel
    /// </summary>
    public void ButtonInstructionsClose()
    {
        InstructionsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    /// <summary>
    /// change to credits panel
    /// </summary>
    public void ButtonCreditsOpen()
    {
        MainPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    /// <summary>
    /// close credits panel
    /// </summary>
    public void ButtonCreditsClose()
    {
        CreditsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    /// <summary>
    /// quit application if exit button was hit
    /// </summary>
    public void ButtonQuit()
    {
        Application.Quit();
    }
}
