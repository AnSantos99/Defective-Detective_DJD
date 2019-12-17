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

    private void Start()
    {
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if(attemptedCode == code)
        {
            StartCoroutine(Open());
        }
        else
        {
            Debug.Log("WrongCode");
        }
    }

    IEnumerator Open()  //'animation' of open & close
    {
        toOpen.Rotate(new Vector3(90, 0, 0), Space.World);

        yield return new WaitForSeconds(4);

        toOpen.Rotate(new Vector3(-90, 0, 0), Space.World);
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
