using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepActiveTextField : MonoBehaviour
{
    public void KeepActive()
    {
        GetComponent<TMP_InputField>().ActivateInputField();
    }

    void Start()
    {
        KeepActive();
    }
}
