using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookInteractable : InventoryItemBase
{
    private GameObject view;
    private ViewController viewScript;

    private int currentPage = 0;

    public GameObject[] pages;

    void Start()
    {
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();
        foreach (GameObject page in pages)
            page.SetActive(false);
        pages[0].SetActive(true);
    }

    public void ForwardPage(int page)
    {
        pages[page].SetActive(true);
        pages[page - 1].SetActive(false);
    }

    public void BackwardsPage(int page)
    {
        pages[page].SetActive(true);
        pages[page + 1].SetActive(false);
    }

    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "book";
        }
    }

    public override void OnUse()
    {
        viewScript.ToggleBookPanel(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && currentPage < pages.Length)
        {
            currentPage += 1;
            ForwardPage(currentPage);
        }

        if (Input.GetKeyDown(KeyCode.N) && currentPage >= 0)
        {
            currentPage -= 1;
            BackwardsPage(currentPage);
        }
    
    } 
}
