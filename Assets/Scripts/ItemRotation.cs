using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    protected Vector3 posLasFra;
    public Camera UICam;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posLasFra = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - posLasFra;
            posLasFra = Input.mousePosition;

            var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) * transform.rotation;
        }
    }
}
