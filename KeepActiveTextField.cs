using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepActiveTextField : MonoBehaviour
{
    /**************************************************************************************************************************************************
    * Purpose: Forces the text field to be active (can be typed in).
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void KeepActive()
    {
        GetComponent<TMP_InputField>().ActivateInputField();
    }

    //Start runs before the first frame
    void Start()
    {
        KeepActive();
    }
}
