using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class QuestionEvent : UnityEvent<Question> { }

public class ConversationController : MonoBehaviour
{
    public Conversation conversation;
    public QuestionEvent questionEvent;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpokenUI speakerUILeft;
    private SpokenUI speakerUIRight;

    private int activeLineIndex;
    private bool conversationStarted = false;

    public void ChangeConversation(Conversation nextConversation)       //Changing conversation
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

    private void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpokenUI>();
        speakerUIRight = speakerRight.GetComponent<SpokenUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("mouse 0"))
            AdvanceLine();
        else if (Input.GetKeyDown("x"))
            EndConversation();
    }

    private void EndConversation()
    {
        conversation = null;
        conversationStarted = false;
        speakerUILeft.Hide();
        speakerUIRight.Hide();
    }

    private void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
    }

    private void AdvanceLine()
    {
        if (conversation == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < conversation.lines.Length)
            DisplayLine();
        else
            AdvanceConversation();
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUILeft.SpeakIs(character))
        {
            SetDialog(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text);
        }

        activeLineIndex += 1;
    }

    private void AdvanceConversation()                                  // These are really three types of dialog tree node and should be three different objects with a standard interface
    {
        if (conversation.question != null)
            questionEvent.Invoke(conversation.question);
        else if (conversation.nextConversation != null)                 //If a conversation is a question, it'll show the question
            ChangeConversation(conversation.nextConversation);          //If there is no question, it'll make sure there is a next conversation
        else
            EndConversation();
    }

    private void SetDialog(SpokenUI activeSpeakerUI, SpokenUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();

        activeSpeakerUI.Dialogue = text;
        StopAllCoroutines();
    //    StartCoroutine(EffectTypewriter(text, activeSpeakerUI));
    }

    //private IEnumerator EffectTypewriter(string text, SpokenUI controller)
    //{
    //    foreach (char character in text.ToCharArray())
    //    {
    //        controller.Dialogue += character;
    //        // yield return new  WaitForSeconds(0.1f);
    //        yield return null;
    //    }
    //}
}