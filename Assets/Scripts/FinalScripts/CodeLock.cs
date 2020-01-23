using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    public Transform toOpen;

    public GameObject caseInside;

    private Animator _animator;

    public GameObject WrongPanel;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if(attemptedCode == code)
        {
            StartCoroutine(Open());
            caseInside.SetActive(true);
        }
        else
        {
            StartCoroutine(ShowWrongInputMessage());
           
        }
    }

    IEnumerator ShowWrongInputMessage()
    {
        WrongPanel.SetActive(true);

        yield return new WaitForSeconds(1);

        WrongPanel.SetActive(false); ;
    }

    IEnumerator Open()  //'animation' of open & close
    {

        _animator.SetBool("Open", true);

        yield return new WaitForSeconds(4);

        _animator.SetBool("Open", false);



    }

    public void SetValue(string value)
    {
        placeInCode++;

        if(placeInCode <= codeLength)
        {
            attemptedCode += value;
        }

        if(placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
