using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class ConversationChangerEvent: UnityEvent<Conversation> {}

public class ChoiceController : MonoBehaviour
{

    public Choice choice;
    public ConversationChangerEvent conversChangeEvent;

   public static ChoiceController AddChoiceButton(Button choiceButtonTemplate, Choice choice, int index)  //takes the choicebutton and copy for each choices on the list
    {
        int buttonSpacing = -44;

        Button button = Instantiate(choiceButtonTemplate);

        button.transform.SetParent(choiceButtonTemplate.transform.parent);                  //set button as child
        button.transform.localScale = Vector3.one;                                          //set scale/size of option
        button.transform.localPosition = new Vector3(0, index + buttonSpacing, 0);          //set position of option; sts it under previous button
        button.name = "Choice_" + (index + 1);                                              //set the name of button (as Choice_1, Choice_2, etc)
        button.gameObject.SetActive(true);                                                  //turn on the buttons

        ChoiceController choiceController = button.GetComponent<ChoiceController>();        //
        choiceController.choice = choice;                                                   //sets button as a 'choice'
        return choiceController;                                                            //returns it to list of active choices
    }

    private void Start()
    {
        if(conversChangeEvent == null)
        {
            conversChangeEvent = new ConversationChangerEvent();
        }
        GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = choice.text;
    }

    public void MakeChoice()
    {
        conversChangeEvent.Invoke(choice.conversation);
    }
}
