using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTalk : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public string Name;

    private PDialogueSystem diaSystem;

    [TextArea(5, 10)]
    public string[] sentences;


    // Start is called before the first frame update
    void Start()
    {
        diaSystem = FindObjectOfType<PDialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        gameObject.GetComponent<PlayerTalk>().enabled = true;
        //FindObjectOfType<PDialogueSystem>().EnterRangeOfObject();

        if (other.gameObject.tag == "speachTrigger")
        {
            gameObject.GetComponent<PlayerTalk>().enabled = true;
            diaSystem.name = name;
            diaSystem.dialogueLines = sentences;
            Debug.Log("Yes");
            //FindObjectOfType<PDialogueSystem>().PLName();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //FindObjectOfType<PDialogueSystem>().OutOfObjectRange();
        gameObject.GetComponent<PlayerTalk>().enabled = false;
    }
}
