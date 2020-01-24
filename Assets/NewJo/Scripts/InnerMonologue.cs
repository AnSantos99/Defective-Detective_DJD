using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerMonologue : MonoBehaviour
{
    public GameObject[] Monologue;
    public PlayerInventory pi;
    public GameObject trigger_1;
    public GameObject trigger_2;
    private bool crRunning;
    Action coroutineCalls;

    [SerializeField] private GameObject current;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monologue_PlayerRoom")
        {
            StartCoroutine(DisplayMonologue(1, coroutineCalls));
        }

        if (other.tag == "Diary")
        {
            coroutineCalls = delegate () { Destroy(trigger_2); };
            StartCoroutine(DisplayMonologue(5, coroutineCalls));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monologue_PlayerRoom")
        {
            coroutineCalls = delegate () { Destroy(trigger_1); };
            DisplayMonologue(2, coroutineCalls);
        }
    }

    IEnumerator DisplayMonologue(int i, Action coroutineCalls)
    {
        Monologue[i].SetActive(true);
        current = Monologue[i];
        yield return new WaitForSeconds(5);
        coroutineCalls();
        Monologue[i].SetActive(false);
        current = Monologue[0];
    }
}
