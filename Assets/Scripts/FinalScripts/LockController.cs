using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class allows us to control the lock in a lockpad
/// </summary>
public class LockController : MonoBehaviour
{
    /// <summary>
    /// get the codeLock
    /// </summary>
    CodeLock codeLock;

    /// <summary>
    /// range for where mouse reaches
    /// </summary>
    int reachRange = 100;
    

    void Update()
    {
        // when mouse pressed check if the object was hit
        if(Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
        }
    }

    /// <summary>
    /// check if object was hit
    /// </summary>
    void CheckHitObj()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, reachRange))
        {
            codeLock = hit.transform.gameObject.GetComponentInParent<CodeLock>();

            if (codeLock != null)
            {
                string value = hit.transform.name;
                codeLock.SetValue(value);
            }
        }
    }
}
