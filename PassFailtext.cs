using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassFailtext : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healthBar;

    void Start()
    {
        healthBar = GameObject.Find("HealthBar");

        if(healthBar.GetComponent<HealthBehaviour>().alive == false)
        {
            GetComponent<TextMeshProUGUI>().text = "Level Failed: ";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "Level Complete: ";
        }


        if(GameObject.Find("DataStorage").GetComponent<LevelController>().level == 0)
        {
            GetComponent<TextMeshProUGUI>().text += "Tutorial";
        }

        /*if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 1)
        {
            GetComponent<TextMeshProUGUI>().text += "dwdwdwdwdwdw";
        }
        */
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 1)
        {
            GetComponent<TextMeshProUGUI>().text += "Shakespeare 1";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 2)
        {
            GetComponent<TextMeshProUGUI>().text += "Shakespeare 2";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 3)
        {
            GetComponent<TextMeshProUGUI>().text += "Shakespeare 3";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 4)
        {
            GetComponent<TextMeshProUGUI>().text += "Shakespeare 4";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 5)
        {
            GetComponent<TextMeshProUGUI>().text += "Shakespeare 5";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 6)
        {
            GetComponent<TextMeshProUGUI>().text += "Shakespeare 6";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 7)
        {
            GetComponent<TextMeshProUGUI>().text += "Shakespeare 7";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 8)
        {
            GetComponent<TextMeshProUGUI>().text += "Shakespeare 8";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 9)
        {
            GetComponent<TextMeshProUGUI>().text += "Miller";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 10)
        {
            GetComponent<TextMeshProUGUI>().text += "Twain";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 11)
        {
            GetComponent<TextMeshProUGUI>().text += "O'Brien";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 12)
        {
            GetComponent<TextMeshProUGUI>().text += "Kesey";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 13)
        {
            GetComponent<TextMeshProUGUI>().text += "Hawthorne";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 14)
        {
            GetComponent<TextMeshProUGUI>().text += "Lee";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 15)
        {
            GetComponent<TextMeshProUGUI>().text += "Steinbeck";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 16)
        {
            GetComponent<TextMeshProUGUI>().text += "Bradbury";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 17)
        {
            GetComponent<TextMeshProUGUI>().text += "Fitzgerald";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 18)
        {
            GetComponent<TextMeshProUGUI>().text += "N.C.O.M";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 19)
        {
            GetComponent<TextMeshProUGUI>().text += "Taxi Driver";
        }

        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 20)
        {
            GetComponent<TextMeshProUGUI>().text += "Mr. Fox";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 21)
        {
            GetComponent<TextMeshProUGUI>().text += "Amer. Psycho";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 22)
        {
            GetComponent<TextMeshProUGUI>().text += "Cit. Kane";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 23)
        {
            GetComponent<TextMeshProUGUI>().text += "Amer. Beauty";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 24)
        {
            GetComponent<TextMeshProUGUI>().text += "Kubrick";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 25)
        {
            GetComponent<TextMeshProUGUI>().text += "Nietzsche";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 26)
        {
            GetComponent<TextMeshProUGUI>().text += "Kierkegaard";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 27)
        {
            GetComponent<TextMeshProUGUI>().text += "DesCartes";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 28)
        {
            GetComponent<TextMeshProUGUI>().text += "Hegel";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 29)
        {
            GetComponent<TextMeshProUGUI>().text += "Hume";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 30)
        {
            GetComponent<TextMeshProUGUI>().text += "Schopenhauer";
        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
