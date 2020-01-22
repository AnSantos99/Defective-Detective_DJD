using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{
    // To get acess to text mesh pro text
    public TMP_Text notificationText;

    // To get acess the gameobject of notification box
    public GameObject notificationBox;

    GameObject objs;

    // Start is called before the first frame update
    void Start()
    {
        //HideNotification();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    /// <summary>
    /// Display Notifications and its message and makes the panel
    /// visible
    /// </summary>
    /// <param name="message"> Gets a message </param>
    public void DisplayNotification(string message) 
    {
        notificationText.text = message;
        notificationBox.SetActive(true);
    }

    /// <summary>
    /// Hide the notification panel
    /// </summary>
    public void HideNotification() 
    {
        notificationBox.SetActive(false);
    }

    IEnumerator DisapearCountDown() 
    {
        yield return new WaitForSeconds(5);
        HideNotification();
    }
}
