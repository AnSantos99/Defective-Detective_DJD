using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorLock : MonoBehaviour
{
    public GameObject Door;

    void OnTriggerEnter()
    {
        Door.GetComponent<Animator>().SetBool("DoorOpen", false);

      //  Destroy();
    }
}
