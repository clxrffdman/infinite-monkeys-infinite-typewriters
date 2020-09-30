using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public int level;
    public int difficulty;
    public float volume;

    void Awake()
    {
        if (GameObject.Find("Monkey") == null && GameObject.Find("LevelControlLoader") == null)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
        volume = 0.1f;
    }

    /**************************************************************************************************************************************************
    * Purpose: Loads the first level (tutorial)
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void LoadMap1()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        GameObject.Find("LineStorage").GetComponent<LineStorage>().currentText = 0;      
    }

    /**************************************************************************************************************************************************
    * Purpose: Loads a level based on levelInput integer
    * Parameters:
    *     Arguments: int levelInput
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void Play(int levelInput)
    {
        print("PLAY");
        if (GameObject.Find("LevelControlLoader"))
        {
            SceneManager.UnloadSceneAsync("MainMenu");
        }
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        level = levelInput;
    }

    /**************************************************************************************************************************************************
    * Purpose: Coroutine which adds to the level index after a short 0.05sec delay.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public IEnumerator LevelValueAdd()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        level++;       
    }

}
