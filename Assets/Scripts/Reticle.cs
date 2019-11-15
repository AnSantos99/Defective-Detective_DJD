using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Reticle : MonoBehaviour
{

    private RectTransform _reticle;


    private void Start()
    {
        _reticle = GetComponent<RectTransform>();
    }
}
