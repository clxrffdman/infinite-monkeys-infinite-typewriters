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

    /**************************************************************************************************************************************************
    * Purpose: Applies default color, line index, and state settings to the object
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
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

    /**************************************************************************************************************************************************
    * Purpose: Activates the current line based on a string input. 
    * Parameters:
    *     Arguments: string input
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
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

    
    /**************************************************************************************************************************************************
    * Purpose: Private coroutine that scrolls the .text variable of theText based on string input
    * Parameters:
    *     Arguments: Student inputOne, Student inputTwo, Student inputThree.
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
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

    /**************************************************************************************************************************************************
    * Purpose: Updates theText's .text attribute with the element within textlines[] at index currentline.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    void UpdateLine()
    {
        theText.text = textLines[currentLine];
    }


    void OnOpen()
    {
        on = true;
    }

    /**************************************************************************************************************************************************
    * Purpose: Runs upon closing the UI element, stops all running coroutines, auto-finishes the text scoll, and resets time scale to 1.0.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
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

    /**************************************************************************************************************************************************
    * Purpose: Disables this gameObject after 0.05 sec.
    * Parameters:
    *     Arguments: Student inputOne, Student inputTwo, Student inputThree.
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
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
