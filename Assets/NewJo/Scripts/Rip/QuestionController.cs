using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QuestionController : MonoBehaviour
{
    public Question question;
    public TMP_Text questionText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();    //track of list for all controlers of choices; everytime one changes, calls Change()

    public void Change(Question _question)
    {
        RemoveChoices();
        question = _question;
        gameObject.SetActive(true);
        Initialize();
    }

    public void Hide()              //Hides UI after a choise is over
    {
        RemoveChoices();
        gameObject.SetActive(false);
    }

    private void RemoveChoices()                //Removes all previous choices
    {
        foreach (ChoiceController c in choiceControllers)
        {
            Destroy(c.gameObject);
        }
        choiceControllers.Clear();              //Clears choice list
    }

    void Start()
    {
        
    }

    private void Initialize()         //
    {
        questionText.text = question.text;

        for(int index = 0; index < question.choices.Length; index++)
        {
            ChoiceController c = ChoiceController.AddChoiceButton(choiceButton, question.choices[index], index);        //Calls the static method
            choiceControllers.Add(c);
        }
        choiceButton.gameObject.SetActive(false);
    }
}
