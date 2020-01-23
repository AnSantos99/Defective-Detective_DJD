using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDialogue : MonoBehaviour
{
    // To display the characters Name
    public TMP_Text characterName;
    public string playerName;

    // To display characters dialogue
    public TMP_Text dialogueText;


    public GameObject dialogueGUI;
    public Transform dialogueBox;

    // Delay of each char to be displayed
    const float LETTER_DELAY = 0.1f;

    // To multiply it by each letter
    const float LETTER_MULTIPL = 0.5f;

    // Press key f to be able to know what the character is thinking
    public KeyCode interactiveLetter = KeyCode.F;

    public string[] dialogueLines;

    public bool letterMultipl = false;
    public bool dialogueActive = false;
    public bool dialogueEnd = false;
    public bool outOfRange = true;


    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";
    }


    public void EnterRangeOfObject() 
    {
        outOfRange = false;
        dialogueGUI.SetActive(true);

        if (dialogueActive == true)
            dialogueGUI.SetActive(false);
    }

    public void OutOfObjectRange() 
    {
        letterMultipl = false;
        dialogueActive = false;
        StopAllCoroutines();
        dialogueGUI.SetActive(false);
        dialogueBox.gameObject.SetActive(false);
    }

    public void PLName() 
    {
        outOfRange = false;
        dialogueGUI.gameObject.SetActive(true);
        characterName.text = playerName;
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    if (!dialogueActive)
        //    {
        //        dialogueActive = true;
        //        StartCoroutine(StartDialogue());
        //    }
        //}
        StartDialogue();
    }

    public void GetDialogue() 
    {
        // Activate dialogue box
        dialogueBox.gameObject.SetActive(true);

        // To set the TMP text to the given string player name
        characterName.text = playerName;
    }

    /// <summary>
    /// Start dialogue of player
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartDialogue() 
    {
        int dialogueTextLenght = dialogueLines.Length;

        int currentDialogueIndx = 0;

        while (currentDialogueIndx < dialogueTextLenght || !letterMultipl)
        {
            if (!letterMultipl)
            {
                letterMultipl = true;
                StartCoroutine(DisplayString(dialogueLines[currentDialogueIndx]));

                // If the dialogue index has reached and is equal to the last 
                // index of the dialogue text lenght, end the dialogue
                if (currentDialogueIndx >= dialogueTextLenght)
                    dialogueEnd = true;
            }
            yield return 0;
        }

        // To switch to next page of dialogue
        while (true)
        {
            if (Input.GetKeyDown(interactiveLetter) && dialogueEnd == false)
                break;
            yield return 0;
        }
        dialogueEnd = false;
        dialogueActive = false;
        DropDialogue();
    }


    public IEnumerator DisplayString(string stringToDisplay) 
    {
        int stringLength = stringToDisplay.Length;

        int currentCharIndex = 0;

        dialogueText.text = "";

        // While the index of char is smaller than the lenght of the string
        while (currentCharIndex < stringLength)
        {
            // Display more text and set the a new index on the next char
            dialogueText.text += stringToDisplay[currentCharIndex];
            currentCharIndex++;

            // Check the if the index still didnt reach the limit
            if (currentCharIndex < stringLength)
            {
                // Get the input
                if (Input.GetKey(interactiveLetter))
                {
                    // Return the next after the last frame letter
                    yield return new WaitForSeconds(LETTER_DELAY * LETTER_MULTIPL);
                }
                else
                {
                    yield return new WaitForSeconds(LETTER_DELAY);
                }
            }
            else
            {
                dialogueEnd = false;
                break;
            }
        }

        while (true)
        {
            if (Input.GetKeyDown(interactiveLetter))
                break;
            yield return 0;

            dialogueEnd = false;
            letterMultipl = false;
            dialogueText.text = "";
        }
    }

    public void DropDialogue() 
    {
        dialogueGUI.SetActive(false);
        dialogueBox.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!dialogueActive)
        {
            dialogueActive = true;
            StartCoroutine(StartDialogue());
            Debug.Log("GoDie");
        }
    }
}
