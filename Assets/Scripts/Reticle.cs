using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Reticle : MonoBehaviour
{

    private RectTransform _reticle;

    [Range(50f, 250)]
    public float size;


    private void Start()
    {
        _reticle = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _reticle.sizeDelta = new Vector2(size, size);
    }
}
