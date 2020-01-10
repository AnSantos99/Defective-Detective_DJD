using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    private GameObject Interactable;

    void Touch()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f))
        {

            if (hit.collider.gameObject.tag == "Touchable") // Did it hit the paper?
            {
                // Show the paper
                hit.collider.gameObject.SendMessage("OnTouch");
                Interactable = hit.collider.gameObject;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // If the player clicks with the left mouse button
        {
            if (Interactable == null)
            {
                Touch(); // then execute Touch()
            }
            else
            {
                //Interactable.SendMessage("UnTouch");
                Interactable = null;
            }
        }
    }
}
