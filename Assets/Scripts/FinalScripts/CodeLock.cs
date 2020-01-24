using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class allows us to control the codelock
/// </summary>
public class CodeLock : MonoBehaviour
{
    /// <summary>
    /// get code length from editor
    /// </summary>
    int codeLength;
    int placeInCode;

    /// <summary>
    /// base code
    /// </summary>
    public string code = "";
    public string attemptedCode;

    /// <summary>
    ///  where to open to
    /// </summary>
    public Transform toOpen;

    /// <summary>
    /// what's inside
    /// </summary>
    public GameObject caseInside;

    /// <summary>
    /// animator in box
    /// </summary>
    private Animator _animator;

    /// <summary>
    // show wrong input panel
    /// </summary>
    public GameObject WrongPanel;

    private void Start()
    { 
        _animator = GetComponentInParent<Animator>();
        codeLength = code.Length;
    }

    /// <summary>
    /// check if the code is right or show error message
    /// </summary>
    void CheckCode()
    {
        // if code is right open the case
        if(attemptedCode == code)
        {
            StartCoroutine(Open());
            caseInside.SetActive(true);
        }

        // show error message
        else
        {
            StartCoroutine(ShowWrongInputMessage());
           
        }
    }

    /// <summary>
    /// show the input message for 2 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowWrongInputMessage()
    {
        WrongPanel.SetActive(true);

        yield return new WaitForSeconds(2);

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
