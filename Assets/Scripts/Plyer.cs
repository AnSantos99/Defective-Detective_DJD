using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyer : MonoBehaviour
{
    private DialogTrigger triggeringNPC;
    public DialogSystem dialogSystem;
   

    // variable of type bool to check if player is triggering with objects
    private bool triggering;

    // Is interactive text appear
    [SerializeField] GameObject npcInteractionText; // was public earlier
    
    private void Update()
    {
        if (triggering) 
        {
            
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (triggeringNPC != null)
                {
                    dialogSystem.npcDialogText.text = triggeringNPC.dialog.npcSentences[0];
                }
                Debug.Log("Interacting");
                
            }
        } 
        else
            npcInteractionText.SetActive(false);
    }

    /// <summary>
    /// Check if player is colliding with the NPC
    /// </summary>
    /// <param name="other"> Get collider of other object with tag NPC </param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC") 
        {
            triggering = true;
            triggeringNPC = other.GetComponent<DialogTrigger>();
            npcInteractionText.SetActive(true);
        }
    }

    /// <summary>
    /// Check if player is not collind with NPC and set triggering to false
    /// </summary>
    /// <param name="other"> Get collider of other object with tag NPC </param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggering = false;
            triggeringNPC = null;
            npcInteractionText.SetActive(false);
        }
    }
    

    
}
