using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class sets a door lock to open when needed
/// </summary>
public class TriggerDoorLock : MonoBehaviour
{
    /// <summary>
    /// get the door
    /// </summary>
    public GameObject Door;

    /// <summary>
    /// set animator of door to close
    /// </summary>
    void OnTriggerEnter()
    {
        Door.GetComponent<Animator>().SetBool("DoorOpen", false);
    }
}
