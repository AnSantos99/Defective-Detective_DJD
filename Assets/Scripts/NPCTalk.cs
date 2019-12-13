using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    private GameObject triggeringNPC;
    DialogSystem activate;

    Dialog dialog;

    // variable of type bool to check if player is triggering with objects
    private bool triggering;

    // istance of type GameObject to get interactive text on screen
    [SerializeField] GameObject npcText; // was public earlier

    /// <summary>
    /// Check if player is colliding with the NPC
    /// </summary>
    /// <param name="other"> Get collider of other object with tag NPC </param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = true;
            triggeringNPC = other.gameObject;
            activate.StartDialog(dialog);
        }
    }

    /// <summary>
    /// Check if player is not collind with NPC and set triggering to false
    /// </summary>
    /// <param name="other"> Get collider of other object with tag NPC </param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            triggeringNPC = null;
        }
    }
}
