using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerMonologue : MonoBehaviour
{
    public GameObject[] Monologue;

    [SerializeField]private GameObject current;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        InputManage();
    }

    void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "TagOfTheObj")      //This is example
        {
            Monologue[TheThingy].SetActive(true);
            current = Monologue[TheThingy];
        }*/

        if (other.tag == "Monologue_PlayerRoom")
        {
            Monologue[3].SetActive(true);
            current = Monologue[3];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.tag == "TagOfTheObj")      //This is example
        {
            Monologue[TheThingy].SetActive(false);
            current = Monologue[TheThingy];
        }*/

        if (other.tag == "Monologue_PlayerRoom")
        {
            Monologue[3].SetActive(true);
            current = Monologue[3];
            waitMoment();
            Monologue[3].SetActive(false);
            current = Monologue[0];

        }
    }

    public void InputManage()
    {
        /*if(bool == true)                                  //This is example
        {
            Monologue[TheThingy].SetActive(true);
            current = Monologue[TheThingy];
        }*/
    }

    IEnumerator waitMoment()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
