using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextCrawlManager : MonoBehaviour
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


    }

    // Start is called before the first frame update
    void Start()
    {
        theText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
        

        on = false;
        OnOpen();

        textBox = gameObject;
        currentLine = 0;

        ActivateLine("The infinite monkey theorem states that a monkey hitting keys at random on a typewriter keyboard for an infinite amount of time will almost surely type any given text, such as the complete works of William Shakespeare.\n\n\n\nOf course the monkey does not know what it is doing; the fact that words are formed at all is due to sheer luck.");

        
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
        transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "CONTINUE";
        
        isTyping = false;
        cancelTyping = false;

    }

    void UpdateLine()
    {
        theText.text = textLines[currentLine];
    }

    void OnOpen()
    {
        GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().canType = false;

        on = true;

        



        //tiedInteractable.GetComponent<Interactable>().canInteract = false;
    }


    public void OnClose()
    {
        StopAllCoroutines();
        theText.text = textLines[currentLine];

        LeanTween.value(gameObject, 0.75f, 0f, 2f).setOnComplete(DestroyMe).setOnUpdate((float val) => {
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
        Invoke("Death", 0.2f);
        //tiedInteractable.GetComponent<Interactable>().canInteract = true;

        
    }

    void Death()
    {
        GameObject.Find("InputField (TMP)").GetComponent<TextInput>().canType = true;

        Destroy(gameObject);
    }



    void SetActive()
    {
        StartCoroutine(TextScoll(textLines[currentLine]));
        on = true;
    }
}
