using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndCard : MonoBehaviour
{
    //Float variables representing words per minute, combo, accuracy, and a total score
    public float wpm;
    public float highestCombo;
    public float accuracy;
    public float score;

    //GameObjects representing the data on the left and right, and the buttons to proceed to next level/main menu.
    public GameObject leftData;
    public GameObject rightData;
    public GameObject button1;
    public GameObject button2;

    public GameObject letterGrade;

    public float diff;

    public string alphagrade;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        score = 0;
        OnOpen();
        CalcValues();
        AssignValues();
        
    }

    /**************************************************************************************************************************************************
    * Purpose: Calculates values for WPM, combo, accuracy, and score
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    void CalcValues()
    {

        if(GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 0)
        {
            diff = 1;
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 1)
        {
            diff = 1.2f;
        }

        if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 2)
        {
            diff = 1.4f;
        }

        if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 3)
        {
            diff = 1.6f;
        }

        if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 4)
        {
            diff = 1f;
        }

        if (GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty == 5)
        {
            diff = 1.4f;
        }

        if (GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().wordCount != 0)
        {
            accuracy = GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().totalWords / GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().wordCount;
        }
        else
        {
            accuracy = 0;
        }
        
        highestCombo = GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().highestCombo;
        wpm = 60 * (GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().wordCount/ GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().seconds);

        wpm = Mathf.RoundToInt(wpm);

        score = (diff * (1.0f + wpm / 100) * (accuracy*100 / 70) * (GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().comboScore));

        letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 36;
        letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.1698113f, 0.1698113f, 0.1698113f, 1);
        alphagrade = "F";
        if(accuracy >= 0.6)
        {
            letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0.2464418f, 1);
            alphagrade = "D";
        }
        if (accuracy >= 0.7)
        {
            letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.8914347f, 0, 1, 1);
            alphagrade = "C";
        }
        if (accuracy >= 0.8)
        {
            letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0, 0.4302311f, 0, 1);
            alphagrade = "B";
        }
        if (accuracy >= 0.9)
        {
            letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.1151781f, 1, 0, 1);
            alphagrade = "A";
        }
        if (accuracy >= 0.98)
        {
            letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 0.8416415f, 0, 1);
            alphagrade = "S";
        }

        if (accuracy >= 1)
        {
            letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 30;
            letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 0.8416415f, 0, 1);
            alphagrade = "SS";
        }

        if (GameObject.Find("HealthBar").GetComponent<HealthBehaviour>().alive == false)
        {
            alphagrade = "F";
        }


    }

    /**************************************************************************************************************************************************
    * Purpose: Assigns calculated values to the .text components on the left/right side of the score screen.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    void AssignValues()
    {
        rightData.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(score) + " : " + diff + "x";
        rightData.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = wpm + "";
        rightData.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = (100*accuracy).ToString("#.00") + "%";
        rightData.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "x" + highestCombo;
        letterGrade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = alphagrade;
    }

    void OnOpen()
    {
        
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        Time.timeScale = 0;

        LeanTween.value(gameObject, new Color(1,1,1,0), new Color(1,1,1,0.6f), 0.6f).setIgnoreTimeScale(true).setOnUpdate((Color val) => {
            GetComponent<Image>().color = val;
        });

        LeanTween.moveX(leftData.GetComponent<RectTransform>(), 0f, 0.75f).setIgnoreTimeScale(true);
        LeanTween.moveX(rightData.GetComponent<RectTransform>(), 0f, 0.75f).setIgnoreTimeScale(true);
        LeanTween.moveX(button1.GetComponent<RectTransform>(), 35f, 0.75f).setIgnoreTimeScale(true);
        LeanTween.moveX(button2.GetComponent<RectTransform>(), 35f, 0.75f).setIgnoreTimeScale(true);
        LeanTween.moveY(letterGrade.GetComponent<RectTransform>(), 0f, 0.75f).setIgnoreTimeScale(true);
    }

    void OnClose()
    {

    }

    /**************************************************************************************************************************************************
    * Purpose: Called upon clicking the main menu button, loads the main menu screen while unloading the current scene.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(2);
        if(GameObject.Find("LevelControlLoader") == null)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }

        
        
    }

    /**************************************************************************************************************************************************
    * Purpose: Increases the level index in DataStorage by one, and reloads the scene with the new level index data.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void NextLevel()
    {
        if(GameObject.Find("DataStorage").GetComponent<LevelController>().level == 30)
        {
            MainMenu();
        }
        else
        {
            GameObject.Find("DataStorage").GetComponent<LevelController>().level++;
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("SceneOne");

            SceneManager.LoadScene("SceneOne", LoadSceneMode.Additive);
        }
        
        


    }

    

}
