using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiffTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI tex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
