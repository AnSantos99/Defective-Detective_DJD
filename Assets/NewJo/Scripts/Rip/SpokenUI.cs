using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SpokenUI : MonoBehaviour
{
    public Image portrait;
    public TMP_Text fullName;
    public TMP_Text dialogue;

    private Character speak;
    public Character Speaker
    {
        get { return speak; }
        set
        {
            speak = value;
            portrait.sprite = speak.portrait;
            fullName.text = speak.fullName;
        }
    }
    public string Dialogue
    {
        set
        {
            dialogue.text = value;
        }
    }

    public bool HasSpeak()
    {
        return speak != null;
    }

    public bool SpeakIs(Character character)
    {
        return speak == character;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
