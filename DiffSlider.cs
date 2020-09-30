using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiffSlider : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty;
    }



    // Update is called once per frame
    void Update()
    {

        if(slider.value == 0)
        {
            if (GameObject.Find("DataStorage") != null)
            {
                GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty = 0;
            }
            text.fontSize = 3.25f;
            text.text = "EASY";
        }
        if (slider.value == 1)
        {
            if (GameObject.Find("DataStorage") != null)
            {
                GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty = 1;
            }
            text.fontSize = 3.25f;
            text.text = "MEDIUM";
        }
        if (slider.value == 2)
        {
            if (GameObject.Find("DataStorage") != null)
            {
                GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty = 2;
            }
            text.fontSize = 3.25f;
            text.text = "HARD";
        }

        if (slider.value == 3)
        {
            if (GameObject.Find("DataStorage") != null)
            {
                GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty = 3;
            }
            text.fontSize = 3.25f;
            text.text = "BRUTAL";
        }

        if (slider.value == 4)
        {
            if (GameObject.Find("DataStorage") != null)
            {
                GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty = 4;
            }
            text.fontSize = 3.25f;
            text.text = "CLASSIC";
        }

        if (slider.value == 5)
        {
            if (GameObject.Find("DataStorage") != null)
            {
                GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty = 5;
            }
            text.fontSize = 2.4f;
            text.text = "CLASSIC-BRUTAL";
        }
    }

}
