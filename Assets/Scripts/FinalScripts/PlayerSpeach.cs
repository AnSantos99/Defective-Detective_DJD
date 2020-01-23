using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerSpeach : MonoBehaviour
{
    public Transform CharBG;
    public Transform NPCChar;

    private PDialogueSystem playerDSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    
    void Start()
    {
        playerDSystem = FindObjectOfType<PDialogueSystem>();
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
        this.gameObject.GetComponent<PlayerSpeach>().enabled = true;
        //FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "speachTrigger"))
        {
            this.gameObject.GetComponent<PlayerSpeach>().enabled = true;
            playerDSystem.name = name;
            playerDSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<PlayerSpeach>().enabled = false;
    }
}
