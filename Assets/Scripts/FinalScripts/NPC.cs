using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public Transform CharBG;
    public Transform NPCChar;

    private DialogueSystem dialogueSys;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    
    void Start()
    {
        dialogueSys = FindObjectOfType<DialogueSystem>();
    }
    
    void Update()
    {
        //CharacterBG.position = Camera.main.WorldToScreenPoint(NPCChar.position + Vector3.up + 7f);
        Vector3 pos = Camera.main.WorldToScreenPoint(NPCChar.position);
        pos.y += 175;
        CharBG.position = pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSys.name = name;
            dialogueSys.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
