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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMap1()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        GameObject.Find("LineStorage").GetComponent<LineStorage>().currentText = 0;
        
        
        
    }

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

    public IEnumerator LevelValueAdd()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        level++;

        
    }



}
