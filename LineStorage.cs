using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineStorage : MonoBehaviour
{
    public string[] textStorage;
    
    public int characterIndex;
    public int currentText;

    public string[] moveWords;

    public int startIndex;
    public int finalIndex;

    public string line;

    public int index1;
    public int index2;

    public bool end1;
    public bool end2;

    public int[] tutorialScript;

    public string sub1;
    public string sub2;

    public int end;

    void Awake()
    {
        
        if(GameObject.Find("DataStorage") != null)
        {
            currentText = GameObject.Find("DataStorage").GetComponent<LevelController>().level;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        ApplySettings();
        startIndex = 0;
        characterIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CheckMove(string word)
    {
        for(int i = 0; i < moveWords.Length; i++)
        {
            if(word.CompareTo(moveWords[i]) == 0)
            {
                return Random.Range(1, 4);
            }


            
        }

        

        return 0;

    }

    public bool canMistake()
    {
        bool rv = true;
        if(characterIndex >= EndOfWordCharacter())
        {
            rv = false;
        }
        return rv;
    }

    public bool CheckChar(string character)
    {

        if(textStorage[currentText].Substring(characterIndex,1) == character)
        {
            
            return true;
        }
        else
        {
            
            return false;
        }
    }

    

    public void FixCharacterCount()
    {
        characterIndex = textStorage[currentText].IndexOf(" ", startIndex)+1;
        startIndex = characterIndex;
    }

    public int EndOfWordCharacter()
    {
        end = textStorage[currentText].IndexOf(" ", startIndex) - 1;
        return end;

    }

    public string OneWordAhead()
    {
        if (textStorage[currentText].Substring(index1) == " END")
        {
            end2 = true;
            end1 = true;
        }

        if (!end1)
        {
            index1 = textStorage[currentText].IndexOf(" ", startIndex) + 1;
            sub1 = (textStorage[currentText].Substring(index1, (textStorage[currentText].IndexOf(" ", index1)) - index1));
            print("S " + sub1);

            print("P " + textStorage[currentText].Substring(index1));
            return sub1;
            
            
        }
        return "";

    }

    public string TwoWordsAhead()
    {
        if (textStorage[currentText].Substring(index2 + sub2.Length) == " END")
        {
            end2 = true;
            end1 = true;
        }

        int indexSub = index2;
        if (!end2)
        {
            

            index2 = textStorage[currentText].IndexOf(" ", index1) + 1;
            sub2= (textStorage[currentText].Substring(index2, (textStorage[currentText].IndexOf(" ", index2)) - index2));
            print("S " + sub2);
            print("P " + textStorage[currentText].Substring(index2));

            return sub2;
        }
        return "";
        
    }

    public void NextLine()
    {
        startIndex = 0;
        characterIndex = 0;
        finalIndex = 0;
        currentText++;
    }

    public void ApplySettings()
    {
        
        
        
        


    }

    
}
