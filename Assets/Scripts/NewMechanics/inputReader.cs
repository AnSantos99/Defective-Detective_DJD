using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inputReader : MonoBehaviour
{
    public TMP_InputField input;

    public GameObject Door;

    private Animator doorAnim;

    private GameObject view;
    
    private ViewController viewScript;

    public GameObject WrongPanel;

    void Start()
    {
        doorAnim = Door.GetComponent<Animator>();
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();
    }

    public void GetInput()
    {
        if (input.text == "zen is beautiful")
        {
            FindObjectOfType<SoundManager>().Play("CodeZRight");
            input.text = "";
            doorAnim.SetBool("DoorOpen", true);
            FindObjectOfType<SoundManager>().Play("DoorOpen");
            viewScript.passwordCorrect = true;
            viewScript.ToggleInputPanel(false);
        }

        else
        {
            viewScript.ToggleInputPanel(false);
            StartCoroutine(ShowWrongInputMessage());
            FindObjectOfType<SoundManager>().Play("CodeWrong");
        }
    }

    IEnumerator ShowWrongInputMessage()
    {
        WrongPanel.SetActive(true);

        yield return new WaitForSeconds(1);

        WrongPanel.SetActive(false); ;
    }
}
