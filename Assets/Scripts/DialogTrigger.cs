﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public void TriggerDialog() 
    {
        FindObjectOfType<DialogSystem>().StartDialog(dialog);
    }
}
