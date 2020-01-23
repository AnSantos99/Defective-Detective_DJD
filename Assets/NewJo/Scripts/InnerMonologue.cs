using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerMonologue : MonoBehaviour
{
    public GameObject[] Monologue;
    PlayerInventory pi;
    public GameObject trigger_1;
    public GameObject trigger_2;


    [SerializeField]private GameObject current;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        DialogueInputManage();
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
            Monologue[1].SetActive(true);
            current = Monologue[1];
            Debug.Log("Kill");
        }

        if (other.tag == "Diary")
        {
            Monologue[5].SetActive(true);
            current = Monologue[5];
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
            Monologue[2].SetActive(true);
            current = Monologue[2];
            Destroy(trigger_1);

        }
    }

    public void DialogueInputManage()
    {
        if (pi.doorOpen == true)
        {
            Monologue[3].SetActive(true);
            current = Monologue[3];
        }

        if (pi.doorClosed == true)
        {
            Monologue[4].SetActive(true);
            current = Monologue[4];
        }
        if(pi.broomFall == true)
        {
            Monologue[6].SetActive(true);
            current = Monologue[6];
        }
    }

    IEnumerator waitMoment()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
