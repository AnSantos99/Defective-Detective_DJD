using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// this class allows us to manipulate an inventory item of type book with 
/// the special condition of letting us read through it
/// </summary>
public class BookInteractable : InventoryItemBase
{
    /// <summary>
    /// gets the viewController
    /// </summary>
    private GameObject view;

    /// <summary>
    /// gets the script in viewController
    /// </summary>
    private ViewController viewScript;

    /// <summary>
    /// int to check current page in use
    /// </summary>
    private int currentPage = 0;

    /// <summary>
    /// array of pages in book
    /// </summary>
    public GameObject[] pages;

    void Start()
    {
        // find gameManager and set script
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();

        // set the pages correctly
        foreach (GameObject page in pages)
            page.SetActive(false);
        pages[0].SetActive(true);
    }

    /// <summary>
    /// go forward a page when input
    /// </summary>
    /// <param name="page"></param>
    public void ForwardPage(int page)
    {
        pages[page].SetActive(true);
        pages[page - 1].SetActive(false);
    }

    /// <summary>
    /// go backward a page when input
    /// </summary>
    /// <param name="page"></param>
    public void BackwardsPage(int page)
    {
        pages[page].SetActive(true);
        pages[page + 1].SetActive(false);
    }

    // get name of item
    public override string Name
    {
        get
        {
            return "book";
        }
    }

    /// <summary>
    /// when book is on use toggle book panel
    /// </summary>
    public override void OnUse()
    {
        viewScript.ToggleBookPanel(false);
    }

    void Update()
    {
        // get the input to move between pages
        if (Input.GetKeyDown(KeyCode.M) && currentPage < pages.Length)
        {
            //go forward a page
            currentPage += 1;
            ForwardPage(currentPage);
        }

        // get the input to move between pages
        if (Input.GetKeyDown(KeyCode.N) && currentPage >= 0)
        {
            // go backward a page
            currentPage -= 1;
            BackwardsPage(currentPage);
        }
    
    } 
}
