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
        //StartCoroutine(waitMoment());

    }

    private void Update()
    {
        DialogueInputManage();

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monologue_PlayerRoom")
        {
            ClearInvocationList();
            StartCoroutine(DisplayMonologue(1, coroutineCalls));
        }

        if (other.tag == "Diary")
        {
            ClearInvocationList();
            coroutineCalls = delegate () { Destroy(trigger_2); };
            StartCoroutine(DisplayMonologue(5, coroutineCalls));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monologue_PlayerRoom")
        {
            ClearInvocationList();
            coroutineCalls = delegate () { Destroy(trigger_1); };
            DisplayMonologue(2, coroutineCalls);
        }
    }

    public void DialogueInputManage()
    {
        if (pi.doorOpen == true)
        {
            ClearInvocationList();
            StartCoroutine(DisplayMonologue(3, coroutineCalls));
        }

        if (pi.doorClosed == true)
        {
            ClearInvocationList();
            StartCoroutine(DisplayMonologue(4, coroutineCalls));
        }
        if (pi.broomFall == true)
        {
            ClearInvocationList();
            StartCoroutine(DisplayMonologue(6, coroutineCalls));
        }
    }

    private void ClearInvocationList()
    {
        // clears the invocation list array of the coroutineCalls delegate, effectively wiping it clean
        // Array.Clear(coroutineCalls.GetInvocationList(), 0, coroutineCalls.GetInvocationList().Length);
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
