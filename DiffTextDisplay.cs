﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiffTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI tex;


    /**************************************************************************************************************************************************
    * Purpose: Updates text display every frame (inefficient I know...) depending on DataStorage difficulty.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    void Update()
    {
        if (GameObject.Find("DataStorage") != null)
        {
            if(GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 0)
            {
                tex.text = "EASY: Start with this.";
            }

            if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 1)
            {
                tex.text = "MEDIUM: A bit faster.";
            }

            if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 2)
            {
                tex.text = "HARD: A real challenge.";
            }

            if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 3)
            {
                tex.text = "BRUTAL: Why?";
            }

            if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 4)
            {
                tex.text = "CLASSIC: No interference.";
            }

            if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 5)
            {
                tex.text = "CLASSIC-BRUTAL: No interference, but why?";
            }
        }
    }
}
