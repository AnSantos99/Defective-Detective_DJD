using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Conversation conversation;

    public GameObject speakLeft;
    public GameObject speakRight;

    private SpokenUI speakUILeft;
    private SpokenUI speakUIRight;

    private int activeLineIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        speakUILeft = speakUILeft.GetComponent<SpokenUI>();
        speakUIRight = speakUIRight.GetComponent<SpokenUI>();

        speakUILeft.Speaker = conversation.speakerLeft;
        speakUIRight.Speaker = conversation.speakerRight;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("space"))
        {
            AdvanceConversation();
        }
    }

    void AdvanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakUILeft.Hide();
            speakUIRight.Hide();
            activeLineIndex = 0;
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if(speakUILeft.SpeakIs(character))
        {
            SetDialog(speakUILeft, speakUIRight, line.text);
        }
        else
        {
            SetDialog(speakUIRight, speakUILeft, line.text);
        }
    }

    void SetDialog(SpokenUI activeSpeakerUI, SpokenUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialogue = text;
        activeSpeakerUI.Show();
    }
}
