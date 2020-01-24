using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// this class lets us read the input from the user
/// </summary>
public class inputReader : MonoBehaviour
{
    /// <summary>
    ///  get the TMP input field for input checking
    /// </summary>
    public TMP_InputField input;

    /// <summary>
    /// get the door to open with the right password
    /// </summary>
    public GameObject Door;

    /// <summary>
    /// animate door to open
    /// </summary>
    private Animator doorAnim;

    /// <summary>
    /// get the view manager to toggle hub
    /// </summary>
    private GameObject view;
    
    private ViewController viewScript;

    /// <summary>
    /// check if input is wrong and show wrong input panel to player
    /// </summary>
    public GameObject WrongPanel;

    void Start()
    {
        // set the values
        doorAnim = Door.GetComponent<Animator>();
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();
    }

    /// <summary>
    /// get player's input and check if it's right or wrong for message show
    /// </summary>
    public void GetInput()
    {
        // if password is right toggle actions
        if (input.text == "zen is beautiful")
        {
            input.text = "";
            doorAnim.SetBool("DoorOpen", true);
            viewScript.passwordCorrect = true;
            viewScript.ToggleInputPanel(false);    
        }

        else
        {
            viewScript.ToggleInputPanel(false);
            StartCoroutine(ShowWrongInputMessage());
        }
    }

    /// <summary>
    /// show error message if wrong input
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowWrongInputMessage()
    {
        WrongPanel.SetActive(true);

        yield return new WaitForSeconds(1);

        WrongPanel.SetActive(false); ;
    }
}
