using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

/// <summary>
/// Class that describes the functionalities of teh NPC's
/// </summary>
public class NPC : MonoBehaviour
{
    // To get the NPC
    public Transform CharBG;

    // To transform the position of the NPC
    public Transform NPCChar;

    // variable of type dialoguesystem for the dialogues of the npc's 
    private DialogueSystem dialogueSys;

    // get name of the NPC
    public string Name;

    /// <summary>
    /// Array of sentences to be able to write down all sentences
    /// </summary>
    [TextArea(5, 10)]
    public string[] sentences;

    /// <summary>
    /// Start the dialogue system
    /// </summary>
    void Start()
    {
        dialogueSys = FindObjectOfType<DialogueSystem>();
    }
    
    /// <summary>
    /// Method to update on each frame
    /// </summary>
    void Update()
    {
        //CharacterBG.position = Camera.main.WorldToScreenPoint(NPCChar.position + Vector3.up + 7f);
        Vector3 pos = Camera.main.WorldToScreenPoint(NPCChar.position);
        pos.y += 175;
        CharBG.position = pos;
    }

    /// <summary>
    /// Ontriggerstay enable the dialoguesystem and enable the possibility to
    /// acess the dialogue with the the input.
    /// Display the name and the sentences of the npc's
    /// </summary>
    /// <param name="other"> To compare with other gameobjects. In this
    /// case the player </param>
    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;

        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();

        // check if the trigger is with the player and enable the dialogue
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSys.name = name;
            dialogueSys.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    /// <summary>
    /// On triggerexit, exit the possibility to talk with npc's
    /// </summary>
    /// <param name="other"> Get the other game object </param>
    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
