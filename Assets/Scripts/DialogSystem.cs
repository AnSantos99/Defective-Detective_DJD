using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Text npcName;
    public Text npcDialogText;

    // Queue collection of type string to save setences in.
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog) 
    {
        Debug.Log("Starting convo with " + dialog.npcName);

        npcName.text = dialog.npcName;

        // Clear dialogue text
        sentences.Clear();

        foreach (string sentence in dialog.npcSentences) 
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSetence();
    }

    public void DisplayNextSetence() 
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) 
    {
        npcDialogText.text = "";
        foreach (char n in sentence.ToCharArray()) 
        {
            npcDialogText.text += n;
            yield return null;
        }
    }

    public void EndDialogue() 
    {
        Debug.Log("End of conversation");
    }
}
