using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public GameObject chicken;

    public bool startPF;

    // Start is called before the first frame update
    void Start()
    {
        //chicken = GetComponent<GameObject>();

        startPF = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActivateObject();
    }

    private void ActivateObject(bool condition)
    {
        if (startPF == true)
        {
            //chicken.SetActive(true);
        }
    }
}
