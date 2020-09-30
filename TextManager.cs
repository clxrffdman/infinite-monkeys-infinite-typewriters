using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameObject textBox;

    public TextMeshPro theText;

    public List<string> textLines;
    public float[] typeSpeedArray;

    

    public int currentLine;
    public int endAtLine;
    public bool on;

    public bool isTyping = false;
    public bool cancelTyping = false;

    public float typeSpeed;

    public Sprite textimg;

    public GameObject clickPrompt;


    public GameObject tiedInteractable;

    public GameObject paper;

    public int lineCount;

    public string title;

    void Awake()
    {
        

    }

    // Start is called before the first frame update
    void Start()
    {

        theText = transform.GetChild(0).GetComponent<TextMeshPro>();

        //transform.position = new Vector3(0, -350, 0);

        on = true;
        //OnOpen();
        
        textBox = gameObject;
        currentLine = 0;


        Invoke("AddTitle", 0.25f);
        //UpdateLine();
    }

    void AddTitle()
    {
        title = "Level: ";
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 0)
        {
            title += "Tutorial";
        }

        /*if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 1)
        {
            title += "dwdwdwdwdwdw";
        }
        */
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 1)
        {
            title += "Shakespeare 1";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 2)
        {
            title += "Shakespeare 2";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 3)
        {
            title += "Shakespeare 3";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 4)
        {
            title += "Shakespeare 4";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 5)
        {
            title += "Shakespeare 5";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 6)
        {
            title += "Shakespeare 6";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 7)
        {
            title += "Shakespeare 7";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 8)
        {
            title += "Shakespeare 8";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 9)
        {
            title += "Miller";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 10)
        {
            title += "Twain";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 11)
        {
            title += "O'Brien";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 12)
        {
            title += "Kesey";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 13)
        {
            title += "Hawthorne";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 14)
        {
            title += "Lee";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 15)
        {
            title += "Steinbeck";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 16)
        {
            title += "Bradbury";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 17)
        {
            title += "Fitzgerald";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 18)
        {
            title += "N.C.O.M";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 19)
        {
            title += "Taxi Driver";
        }

        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 20)
        {
            title += "Mr. Fox";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 21)
        {
            title += "Amer. Psycho";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 22)
        {
            title += "Cit. Kane";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 23)
        {
            title += "Amer. Beauty";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 24)
        {
            title += "Kubrick";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 25)
        {
            title += "Nietzsche";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 26)
        {
            title += "Kierkegaard";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 27)
        {
            title += "DesCartes";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 28)
        {
            title += "Hegel";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 29)
        {
            title += "Hume";
        }
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 30)
        {
            title += "Schopenhauer";
        }


        ActivateLine(title + "\n");
    }

    public void ActivateLine(string input)
    {
        if (on)
        {
            
            if (!isTyping)
            {
                if (currentLine+3 > textLines.Count)
                {
                    textLines.Add("");
                }
                
                textLines[currentLine] = input;
                //UpdateLine();


                lineCount = theText.GetTextInfo(theText.text).lineCount;
                StartCoroutine(TextScoll(textLines[currentLine]));
                
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
                //clickPrompt.SetActive(true);
            }
        }
        
    }

    // Update is called once per frame
    
    

    private IEnumerator TextScoll(string lineOfText)
    {
        //clickPrompt.SetActive(false);
        int letter = 0;
        
        isTyping = true;
        cancelTyping = false;
        
        while (isTyping && !cancelTyping && (letter < textLines[currentLine].Length))
        {

            theText.text += textLines[currentLine].Substring(letter, 1);
            letter++;
            yield return new WaitForSecondsRealtime(typeSpeed);
        }


        currentLine++;

        //clickPrompt.SetActive(true);
        isTyping = false;
        cancelTyping = false;
        if(lineCount < theText.GetTextInfo(theText.text).lineCount)
        {
            float initY = paper.transform.position.y;
            if(paper.transform.position.y < 2)
            {
                LeanTween.moveY(paper, initY + 0.45f, .05f);
            }
            
            
            lineCount = theText.GetTextInfo(theText.text).lineCount;
        }
    }

    void UpdateLine()
    {
        theText.text = textLines[currentLine];
    }

    void OnOpen()
    {
        LeanTween.scale(gameObject, new Vector3(6.675f, 2.175f, 6f), 0.25f).setOnComplete(SetActive).setIgnoreTimeScale(true);
        LeanTween.value(gameObject, -350, -150, 0.25f).setIgnoreTimeScale(true).setOnUpdate((float val) => {
            transform.position = new Vector3(0, val, 0);
        });



        Time.timeScale = 0;



        //tiedInteractable.GetComponent<Interactable>().canInteract = false;
    }


    public void OnClose()
    {







        LeanTween.scale(gameObject, new Vector3(6.675f, 0f, 0f), 0.25f).setOnComplete(DestroyMe).setIgnoreTimeScale(true);
        LeanTween.value(gameObject, -150, -350, 0.25f).setIgnoreTimeScale(true).setOnUpdate((float val) => {
            transform.position = new Vector3(0, val, 0);
        });

        // tiedInteractable.GetComponent<Interactable>().clicked = true;
        //tiedInteractable.GetComponent<Interactable>().canInteract = true;
    }

    void DestroyMe()
    {

        //tiedInteractable.GetComponent<Interactable>().canInteract = true;

        Destroy(gameObject);
    }



    void SetActive()
    {
        StartCoroutine(TextScoll(textLines[currentLine]));
        on = true;
    }
}
