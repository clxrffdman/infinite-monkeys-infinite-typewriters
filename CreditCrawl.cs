using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditCrawl : MonoBehaviour
{
    public GameObject textBox;

    public TextMeshProUGUI theText;

    public List<string> textLines;
    public float[] typeSpeedArray;



    public int currentLine;


    public int endAtLine;
    public bool on;

    public bool isTyping = false;
    public bool cancelTyping = false;

    public float typeSpeed;

    public Sprite textimg;




    public GameObject tiedInteractable;

    void Awake()
    {
        textBox = gameObject;
        on = false;
        theText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
    }

    void OnEnable()
    {
        
        on = false;
        OnOpen();

        textBox = gameObject;
        currentLine = 0;

        GetComponent<Image>().color = new Color(1, 1, 1, 0.75f);
        theText.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
        transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 0.75f);
        transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 1);


        ActivateLine("CREDITS:\n     \nProgramming: Calex Raffield and Ian Chi\n     \nArt: Brandon Wang (Insta: @bwang13sr)\n     \nAudio: Kevin Hu");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        



        

    }

    // Update is called once per frame
    public void ActivateLine(string input)
    {
        if (on)
        {

            if (!isTyping)
            {
                if (currentLine + 3 > textLines.Count)
                {
                    textLines.Add("");
                }

                textLines[currentLine] = input;
                //UpdateLine();



                StartCoroutine(TextScoll(textLines[currentLine]));

            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
                //clickPrompt.SetActive(true);
            }
        }





    }

    private IEnumerator TextScoll(string lineOfText)
    {

        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < textLines[currentLine].Length))
        {
            typeSpeed = typeSpeedArray[currentLine];
            theText.text = textLines[currentLine].Substring(0, letter);
            letter++;
            yield return new WaitForSecondsRealtime(typeSpeed);
        }
        theText.text = textLines[currentLine];
        

        isTyping = false;
        cancelTyping = false;

    }

    void UpdateLine()
    {
        theText.text = textLines[currentLine];
    }

    void OnOpen()
    {
        

        on = true;





        //tiedInteractable.GetComponent<Interactable>().canInteract = false;
    }


    public void OnClose()
    {
        StopAllCoroutines();
        theText.text = textLines[currentLine];

        LeanTween.value(gameObject, 0.75f, 0f, 0.25f).setOnComplete(DestroyMe).setOnUpdate((float val) => {
            GetComponent<Image>().color = new Color(1, 1, 1, val);
            theText.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, val);
            transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, val);
            transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, val);

        });


        Time.timeScale = 1;





        // tiedInteractable.GetComponent<Interactable>().clicked = true;
        //tiedInteractable.GetComponent<Interactable>().canInteract = true;
    }

    void DestroyMe()
    {
        Invoke("Death", 0.05f);
        //tiedInteractable.GetComponent<Interactable>().canInteract = true;


    }

    void Death()
    {
        gameObject.SetActive(false);

        
    }



    void SetActive()
    {
        StartCoroutine(TextScoll(textLines[currentLine]));
        on = true;
    }
}
