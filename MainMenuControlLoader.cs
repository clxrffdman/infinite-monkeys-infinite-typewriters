using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuControlLoader : MonoBehaviour
{
    public Slider[] levelSliders;

    public GameObject[] genrebooks;

    public GameObject credit;

    // Start is called before the first frame update
    void Start()
    {
        

        if (GameObject.Find("DataStorage") == null)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevelOne()
    {
        print((int)levelSliders[0].value);
        GameObject.Find("DataStorage").GetComponent<LevelController>().Play(0);
    }
    //shakespeare
    public void StartLevelTwo()
    {
        GameObject.Find("DataStorage").GetComponent<LevelController>().Play((int)levelSliders[1].value);
    }
    //american literature
    public void StartLevelThree()
    {
        GameObject.Find("DataStorage").GetComponent<LevelController>().Play((int)levelSliders[2].value + 8);
    }
    //film quotes
    public void StartLevelFour()
    {
        GameObject.Find("DataStorage").GetComponent<LevelController>().Play((int)levelSliders[3].value + 17);
    }
    //philosophy
    public void StartLevelFive()
    {
        GameObject.Find("DataStorage").GetComponent<LevelController>().Play((int)levelSliders[4].value + 24);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ActivateAllBooks()
    {
        for(int i = 0; i < genrebooks.Length; i++)
        {
            if(genrebooks[i] != null)
            {
                if (genrebooks[i].transform.GetChild(genrebooks[i].transform.childCount - 1).GetComponent<Image>().raycastTarget == false)
                {
                    genrebooks[i].transform.GetChild(0).GetComponent<Animator>().Play("backBookClose");
                    genrebooks[i].transform.GetChild(genrebooks[i].transform.childCount - 1).GetComponent<Animator>().Play("bookClose");
                }
                genrebooks[i].transform.GetChild(genrebooks[i].transform.childCount - 1).GetComponent<Image>().raycastTarget = true;
                
                
            }
            
            
        }
    }

    public void Credits()
    {
        credit.SetActive(true);
    }

}
