using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotesAdd : MonoBehaviour
{
    private int currentPage = 0;

    public GameObject[] pages;

    private TMP_Text getText;

   // public GameObject BookPanel;

    //private GameObject BookScript;

    public List<string> PageList;

    // Start is called before the first frame update
    void Start()
    {
        //BookPanel = GameObject.FindGameObjectWithTag("viewManager");
        //BookScript = BookPanel.GetComponent<ViewController>();   

        //pages[0].text = "Some new line of text.";

        /*
        foreach (GameObject page in pages)
        {
            getText = page.GetComponent<TMP_Text>();

            // Change the text on the text component.
            getText.text = "Some new line of text.";

            page.SetActive(false);
        }
       
        pages[0].SetActive(true);
        */

    }

    //public string AddToNotes()
    //{
    //    string noteToAdd = "Zen is bastard";
    //}

    // Update is called once per frame
    void Update()
    {    
        getText = pages[0]?.GetComponent<TMP_Text>();

        // Change the text on the text component.

        string addText = getText?.text;

        getText.text += "Some new line of text.";

        pages[0].SetActive(false);        


    }
}
