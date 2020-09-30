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

    /**************************************************************************************************************************************************
    * Purpose: Check if the word (input) is a move word, and returns a random integer from 1-3 if it is.
    * Parameters:
    *     Arguments: string word
    *
    *     Return: int
    ***************************************************************************************************************************************************/
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

    /**************************************************************************************************************************************************
    * Purpose: Checks if the current character index is an end of word character, and returns false if the character index is at the end of a word, true if not.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: bool
    ***************************************************************************************************************************************************/
    public bool canMistake()
    {
        bool rv = true;
        if(characterIndex >= EndOfWordCharacter())
        {
            rv = false;
        }
        return rv;
    }

    /**************************************************************************************************************************************************
    * Purpose: Checks if the current character is correct based on string input.
    * Parameters:
    *     Arguments: string character
    *
    *     Return: bool
    ***************************************************************************************************************************************************/
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

    /**************************************************************************************************************************************************
    * Purpose: Fixes the character index upon finishing a word.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void FixCharacterCount()
    {
        characterIndex = textStorage[currentText].IndexOf(" ", startIndex)+1;
        startIndex = characterIndex;
    }

    /**************************************************************************************************************************************************
    * Purpose: Returns the integer index of the end character of the current word.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: int
    ***************************************************************************************************************************************************/
    public int EndOfWordCharacter()
    {
        end = textStorage[currentText].IndexOf(" ", startIndex) - 1;
        return end;

    }

    /**************************************************************************************************************************************************
    * Purpose: Returns one word ahead to be displayed to the player
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: string
    ***************************************************************************************************************************************************/
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

    /**************************************************************************************************************************************************
    * Purpose: Returns the word two words ahead of the current word for the player to see as a preview.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: string
    ***************************************************************************************************************************************************/
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

    /**************************************************************************************************************************************************
    * Purpose: Moves the text to the next word in the sequence
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
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
