using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTalk : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public string Name;

    private PlayerDialogue diaSystem;

    [TextArea(5, 10)]
    public string[] sentences;


    // Start is called before the first frame update
    void Start()
    {
        diaSystem = FindObjectOfType<PlayerDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        gameObject.GetComponent<PlayerTalk>().enabled = true;
        FindObjectOfType<PlayerDialogue>().EnterRangeOfObject();

        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            gameObject.GetComponent<PlayerTalk>().enabled = true;
            diaSystem.name = name;
            diaSystem.dialogueLines = sentences;
            FindObjectOfType<PlayerDialogue>().PLName();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<PlayerDialogue>().OutOfObjectRange();
        gameObject.GetComponent<PlayerTalk>().enabled = false;
    }
}
