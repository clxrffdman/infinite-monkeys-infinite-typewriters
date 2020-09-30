using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInput : MonoBehaviour
{
    public char[] text;
    public char[] word;


    public KeyCode[] alpha; 


    public int charNumber;

    public KeyCode[] exceptions;

    public TMP_InputField theText;

    public GameObject textDisplay;
    public GameObject textDisplayPreset;

    public GameObject lineStorage;

    public bool contin;

    public bool backspacedelayed;
    public bool backspacedelayedFresh;

    public string displayLineNoHex;

    public bool isBanana;

    public bool wrong;

    public bool canType;

    public Animator anim;

    public int lineCount;

    public float secType;

    public GameObject healthBar;

    public GameObject soundSample;

    public AudioClip[] typeSounds;

    public AudioClip errorSound;

    public AudioClip correctSound;

    public int highestCombo;
    public int currentCombo;

    public float totalWords;
    public float seconds;

    public int wordCount;

    public bool complete;

    public GameObject endScreen;

    public GameObject mainCanvas;

    public float comboScore;

    public GameObject gameMusic;

    public AudioClip[] monkeyMoveSounds;

    public GameObject banana;

    public GameObject lookahead;
    public GameObject lookahead2;

    public float durability0;
    public float durability1;
    public float durability2;
    public float durability3;
    public float durability4;

    public GameObject tutorialPrefab;

    // Start is called before the first frame update
    void Start()
    {
        

        wordCount = 0;
        totalWords = 0;
        lineCount = 0;
        anim = GameObject.Find("Monkey").GetComponent<Animator>();
        healthBar = GameObject.Find("HealthBar");
        
        StartCoroutine(SecondTimer());
        backspacedelayedFresh = true;
        theText = GetComponent<TMP_InputField>();
        alpha = new KeyCode[] { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z, KeyCode.Comma, KeyCode.Period, KeyCode.Question, KeyCode.Exclaim, KeyCode.LeftParen, KeyCode.RightParen, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0, KeyCode.Semicolon, KeyCode.Slash, KeyCode.Quote, KeyCode.LeftBracket, KeyCode.RightBracket, KeyCode.Minus };
        exceptions = new KeyCode[] {KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.LeftAlt, KeyCode.RightAlt, KeyCode.Tab, KeyCode.LeftShift, KeyCode.RightShift, KeyCode.Return, KeyCode.RightAlt, KeyCode.LeftControl, KeyCode.RightControl, KeyCode.Numlock, KeyCode.F1, KeyCode.F2, KeyCode.F3, KeyCode.F4, KeyCode.F5, KeyCode.F6, KeyCode.F7, KeyCode.F8, KeyCode.F9, KeyCode.F10, KeyCode.F11, KeyCode.F12, KeyCode.CapsLock, KeyCode.LeftWindows, KeyCode.RightWindows, KeyCode.Insert, KeyCode.Home, KeyCode.ScrollLock, KeyCode.Pause, KeyCode.End, KeyCode.DownArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.RightArrow };
        textDisplayPreset.GetComponent<TextMeshPro>().text = lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].Substring(lineStorage.GetComponent<LineStorage>().startIndex, lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].IndexOf(" ", lineStorage.GetComponent<LineStorage>().startIndex) + 1);
        Invoke("SetDurability",0.5f);

        lookahead.GetComponent<TextMeshPro>().text = lineStorage.GetComponent<LineStorage>().OneWordAhead();
        lookahead2.GetComponent<TextMeshPro>().text = lineStorage.GetComponent<LineStorage>().TwoWordsAhead();
    }

    void SetDurability()
    {
        if (GameObject.Find("DataStorage").GetComponent<LevelController>().level == 0)
        {
            var spawn = Instantiate(tutorialPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            spawn.transform.SetParent(mainCanvas.transform);
            spawn.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);  

            durability0 = 1;
            durability1 = 1;
            durability2 = 1;
            durability3 = 1;
            durability4 = 1;
            GameObject.Find("HealthBar").GetComponent<HealthBehaviour>().timeDecay = 0f;
        }


    }

    IEnumerator SecondTimer()
    {
        while (!complete)
        {

            yield return new WaitForSeconds(1f);
            seconds++;
        }
    }

    IEnumerator Move(string word)
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1));

            if (lineStorage.GetComponent<LineStorage>().CheckMove(word) == 1)
            {
                SlamAttack();
            }

            else if (lineStorage.GetComponent<LineStorage>().CheckMove(word) == 2)
            {
                Confusion();
            }

            else if (lineStorage.GetComponent<LineStorage>().CheckMove(word) == 3)
            {

            }

            else if (lineStorage.GetComponent<LineStorage>().CheckMove(word) == 4)
            {

            }

            
        
        
    }
    // Update is called once per frame
    void Update()
    {

        if(GameObject.Find("DataStorage").GetComponent<LevelController>().level == 0)
        {
            Tutorial();
        }


        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            backspacedelayedFresh = true;
        }

        if (secType > 0)
        {
            secType -= Time.deltaTime;
        }
        if(secType <= 0)
        {
            AnimateType(false);
        }


        theText.caretPosition += 1;

        if (Input.anyKey && theText.isFocused && canType)
        {
            contin = true;

            for(int i = 0; i < exceptions.Length; i++)
            {
                if (Input.GetKeyDown(exceptions[i]))
                {
                    contin = false;
                }
            }

            if(contin == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    CheckGay();
                    lineStorage.GetComponent<LineStorage>().characterIndex++;
                    print("SUBMITTED " + theText.text);


                    KillBanana();
                    theText.text = displayLineNoHex;

                    if (theText.text.IndexOf(" ") == -1)
                    {
                        theText.text += " ";
                    }

                    if (theText.text.IndexOf(" ") == 0)
                    {
                        theText.text = theText.text.Substring(1, theText.text.Length - 1);
                    }



                    if (lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].Substring(lineStorage.GetComponent<LineStorage>().startIndex, lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].IndexOf(" ", lineStorage.GetComponent<LineStorage>().startIndex) - lineStorage.GetComponent<LineStorage>().startIndex) + " " == theText.text)
                    {
                        print(lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].Substring(lineStorage.GetComponent<LineStorage>().startIndex, lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].IndexOf(" ", lineStorage.GetComponent<LineStorage>().startIndex) - lineStorage.GetComponent<LineStorage>().startIndex) + " ");
                        print(theText.text);
                        print("correct");
                        currentCombo++;
                        wordCount++;
                        if(currentCombo > highestCombo){
                            highestCombo = currentCombo;
                        }
                        CorrectSound();
                        healthBar.GetComponent<HealthBehaviour>().AddHealth(healthBar.GetComponent<HealthBehaviour>().healthGain);
                        GameObject.Find("PaperText").GetComponent<TextManager>().theText.text += "<#000000ff>";
                        totalWords++;
                        AddComboScore();
                    }
                    else
                    {
                        print(lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].Substring(lineStorage.GetComponent<LineStorage>().startIndex, lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].IndexOf(" ", lineStorage.GetComponent<LineStorage>().startIndex) - lineStorage.GetComponent<LineStorage>().startIndex) + " ");
                        print(theText.text);
                        print("incorrect");
                        currentCombo = 0;
                        wordCount++;
                        ScreenShake(0.025f, 0.4f);
                        healthBar.GetComponent<HealthBehaviour>().LoseHealth(healthBar.GetComponent<HealthBehaviour>().healthChunk);
                        GameObject.Find("PaperText").GetComponent<TextManager>().theText.text += "<#ff0000ff>";
                    }

                    

                    GameObject.Find("PaperText").GetComponent<TextManager>().ActivateLine(theText.text);
                    
                    textDisplay.GetComponent<TextMeshPro>().text += " ";
                    lineStorage.GetComponent<LineStorage>().FixCharacterCount();
                    lookahead.GetComponent<TextMeshPro>().text = lineStorage.GetComponent<LineStorage>().OneWordAhead();
                    lookahead2.GetComponent<TextMeshPro>().text = lineStorage.GetComponent<LineStorage>().TwoWordsAhead();

                    if (lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].IndexOf(" ", lineStorage.GetComponent<LineStorage>().startIndex) != -1){
                        Fuck();
                    }

                    else
                    {
                        theText.text += "\n";
                        //GameObject.Find("PaperText").GetComponent<TextManager>().theText.text += "\n";
                        LevelComplete(true);
                        Fuck();
                    }

                    displayLineNoHex = "";
                    textDisplay.GetComponent<TextMeshPro>().text = "";
                    theText.text = "";
                    CheckGay();
                    StartCoroutine(Move(lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].Substring(lineStorage.GetComponent<LineStorage>().startIndex, lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].IndexOf(" ", lineStorage.GetComponent<LineStorage>().startIndex) - lineStorage.GetComponent<LineStorage>().startIndex)));

                }
                else if (Input.GetKey(KeyCode.Backspace))
                {
                    CheckGay();
                    if (backspacedelayedFresh)
                    {
                        backspacedelayedFresh = false;
                        backspacedelayed = true;
                        StartCoroutine(BackSpaceDelay(0.5f));
                        if (lineStorage.GetComponent<LineStorage>().characterIndex > 0 && theText.text.Length >= 0)
                        {
                            charNumber--;
                            if (lineStorage.GetComponent<LineStorage>().characterIndex <= lineStorage.GetComponent<LineStorage>().startIndex)
                            {
                                lineStorage.GetComponent<LineStorage>().characterIndex = lineStorage.GetComponent<LineStorage>().startIndex;
                            }
                            else
                            {
                                lineStorage.GetComponent<LineStorage>().characterIndex--;
                                TypeSound();

                            }
                            textDisplay.GetComponent<TextMeshPro>().text = textDisplay.GetComponent<TextMeshPro>().text.Substring(0, textDisplay.GetComponent<TextMeshPro>().text.Length - 12);
                            displayLineNoHex = displayLineNoHex.Substring(0, displayLineNoHex.Length - 1);
                            CheckGay();
                            AnimateType(true);
                            secType = 0.5f;
                            
                        }

                        

                    }

                    else if (!backspacedelayed && !backspacedelayedFresh)
                    {
                        backspacedelayed = true;
                        StartCoroutine(BackSpaceDelay(0.013f));
                        if (lineStorage.GetComponent<LineStorage>().characterIndex > 0 && theText.text.Length > 0)
                        {
                            charNumber--;
                            if(lineStorage.GetComponent<LineStorage>().characterIndex <= lineStorage.GetComponent<LineStorage>().startIndex)
                            {
                                lineStorage.GetComponent<LineStorage>().characterIndex = lineStorage.GetComponent<LineStorage>().startIndex;
                            }
                            else
                            {
                                TypeSound();
                                
                                lineStorage.GetComponent<LineStorage>().characterIndex--;
                            }

                            textDisplay.GetComponent<TextMeshPro>().text = textDisplay.GetComponent<TextMeshPro>().text.Substring(0, textDisplay.GetComponent<TextMeshPro>().text.Length - 12);
                            displayLineNoHex = displayLineNoHex.Substring(0, displayLineNoHex.Length - 1);
                            CheckGay();
                            AnimateType(true);
                            secType = 0.5f;
                            
                        }

                        
                    }

                    

                }
                else if(Input.anyKeyDown)
                {
                    charNumber++;

                    for (int i = 0; i < alpha.Length; i++)
                    {
                        if (Input.GetKeyDown(alpha[i]))
                        {
                            

                            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
                            {
                                if (lineStorage.GetComponent<LineStorage>().CheckChar(indexToLetter(i,false)))
                                {
                                    textDisplay.GetComponent<TextMeshPro>().text += "<#008000ff>" + indexToLetter(i,false);
                                    TypeSound();
                                    displayLineNoHex += indexToLetter(i, false);
                                    print(lineStorage.GetComponent<LineStorage>().EndOfWordCharacter());
                                    print(lineStorage.GetComponent<LineStorage>().characterIndex);
                                    if (GameObject.Find("DataStorage").GetComponent<LevelController>().level != 0 && GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty < 4 && lineStorage.GetComponent<LineStorage>().canMistake())
                                    {
                                        Mistake();
                                    }
                                }
                                else
                                {
                                    
                                    ErrorSound();

                                    textDisplay.GetComponent<TextMeshPro>().text += "<#ff0000ff>" + indexToLetter(i,false);
                                    displayLineNoHex += indexToLetter(i, false);
                                    print(lineStorage.GetComponent<LineStorage>().EndOfWordCharacter());
                                    print(lineStorage.GetComponent<LineStorage>().characterIndex);



                                    if (GameObject.Find("DataStorage").GetComponent<LevelController>().level != 0 && GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty < 4 && lineStorage.GetComponent<LineStorage>().canMistake())
                                    {
                                        Mistake();
                                    }
                                    
                                }
                            }
                            else
                            {
                                if (lineStorage.GetComponent<LineStorage>().CheckChar(indexToLetter(i,true)))
                                {
                                    TypeSound();
                                    textDisplay.GetComponent<TextMeshPro>().text += "<#008000ff>" + indexToLetter(i,true);
                                    displayLineNoHex += indexToLetter(i, true);
                                    
                                    
                                    if (GameObject.Find("DataStorage").GetComponent<LevelController>().level != 0 && GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty < 4 && lineStorage.GetComponent<LineStorage>().canMistake())
                                    {
                                        Mistake();
                                    }
                                }
                                else
                                {
                                    
                                    ErrorSound();

                                    textDisplay.GetComponent<TextMeshPro>().text += "<#ff0000ff>" + indexToLetter(i,true);
                                    displayLineNoHex += indexToLetter(i, true);
                                    print(lineStorage.GetComponent<LineStorage>().EndOfWordCharacter());
                                    print(lineStorage.GetComponent<LineStorage>().characterIndex);
                                    if (GameObject.Find("DataStorage").GetComponent<LevelController>().level != 0 && GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty < 4 && lineStorage.GetComponent<LineStorage>().canMistake())
                                    {
                                        Mistake();
                                    }
                                }
                            }
                            lineStorage.GetComponent<LineStorage>().characterIndex++;
                            CheckGay();
                            AnimateType(true);
                            secType = 0.5f;
                            

                        }
                    }

                    
                    
                    print("TYPED LETTER " + charNumber);
                    
                }
            }

            

            


        }

        
        
    }

    public void ScreenShake(float mag, float time)
    {
        GameObject.Find("MainCamera").GetComponent<ScreenShake>().ShakeIt(mag, time);
    }

    public void CheckGay()
    {
        if(textDisplay.GetComponent<TextMeshPro>().text.IndexOf("<#008000ff>") != -1)
        {
            textDisplayPreset.GetComponent<MeshRenderer>().enabled = true;
            if (textDisplay.GetComponent<TextMeshPro>().text.IndexOf("<#ff0000ff>") != -1)
            {
                textDisplayPreset.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else
        {
            if(textDisplay.GetComponent<TextMeshPro>().text == "")
            {
                textDisplayPreset.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                textDisplayPreset.GetComponent<MeshRenderer>().enabled = false;
            }
            
        }
    }

    public void SelectField()
    {
        theText.Select();
    } 

    public void TypeSound()
    {
        var aud = Instantiate(soundSample, transform.position, Quaternion.identity);
        AudioClip chosenSound = typeSounds[Random.Range(0, typeSounds.Length)];
        aud.GetComponent<SoundSample>().SpawnSound(chosenSound, 0, 100);
    }

    public void ErrorSound()
    {
        var aud = Instantiate(soundSample, transform.position, Quaternion.identity);
        AudioClip chosenSound = errorSound;
        aud.GetComponent<SoundSample>().SpawnSound(chosenSound, 0, 100);
    }

    public void CorrectSound()
    {
        var aud = Instantiate(soundSample, transform.position, Quaternion.identity);
        AudioClip chosenSound = correctSound;
        aud.GetComponent<SoundSample>().SpawnSound(chosenSound, 0, 100);
    }

    public void DisableTyping()
    {
        canType = false;
        theText.DeactivateInputField();
    }

    public void EnableTyping()
    {

    }

    IEnumerator BackSpaceDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        backspacedelayed = false;
    }

    public void AnimateType(bool state)
    {
        anim.SetBool("typing", state);
    }

    

    public void SlamAttack()
    {
        anim.Play("monkeyAngry");
        var aud = Instantiate(soundSample, transform.position, Quaternion.identity);
        aud.GetComponent<SoundSample>().SpawnSound(monkeyMoveSounds[0], 0, 100);
        ScreenShake(0.04f, 0.6f);
        StartCoroutine(Slam(3));
    }

    IEnumerator Slam(int charCount)
    {
        string[] alphaOrder = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", ",", ".", "?", "!", "(",")", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ";", "/", "'",  "[", "]", "-"};
        while (charCount > 0)
        {

            
            charNumber++;
            lineStorage.GetComponent<LineStorage>().characterIndex++;
            string addedChar = alphaOrder[Random.Range(0, 26)];
            theText.text += addedChar;
            CheckGay();
            if (lineStorage.GetComponent<LineStorage>().CheckChar(addedChar))
            {
                textDisplay.GetComponent<TextMeshPro>().text += "<#008000ff>" + addedChar;
            }
            else
            {
                textDisplay.GetComponent<TextMeshPro>().text += "<#ff0000ff>" + addedChar;
            }

            displayLineNoHex += addedChar;


            yield return new WaitForSeconds(0.02f);
            charCount--;
        }
    }

    void Submit()
    {
        
    }

    string indexToLetter(int index, bool cap)
    {
        string[] alphaOrder = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", ",", ".", "?", "!", "(", ")", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ";", "/", "'", "[", "]", "-" };
        if (cap == true)
        {


            if (index == 44)
            {
                return "\"";
            }

            if (index == 45)
            {
                return "{";
            }

            if (index == 46)
            {
                return "}";
            }

            if (index == 47)
            {
                return "_";
            }

            if (index == 35)
            {
                return "$";
            }

            if (index == 36)
            {
                return "%";
            }


            if (index == 38)
            {
                return "&";
            }

            if (index == 39)
            {
                return "*";
            }

            if (index == 40)
            {
                return "(";
            }
            if (index == 41)
            {
                return ")";
            }
            if (index == 42)
            {
                return ":";
            }

            if (index == 43)
            {
                return "?";
            }

            if (index == 32)
            {
                return "!";
            }


            return alphaOrder[index].ToUpper();
        }
        else
        {
            return alphaOrder[index];
        }
        
    }

    void AddComboScore()
    {
        

        if(currentCombo <= 2)
        {
            comboScore += (100);
        }
        else if(currentCombo <= 5)
        {
            comboScore += (100)*2;
        }
        else if (currentCombo <= 8)
        {
            comboScore += (100) * 3;
        }
        else if (currentCombo >= 9)
        {
            comboScore += (100) * 4;
        }
        
    }

    void Fuck()
    {
        textDisplayPreset.GetComponent<TextMeshPro>().text = lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].Substring(lineStorage.GetComponent<LineStorage>().startIndex, lineStorage.GetComponent<LineStorage>().textStorage[lineStorage.GetComponent<LineStorage>().currentText].IndexOf(" ", lineStorage.GetComponent<LineStorage>().startIndex) - lineStorage.GetComponent<LineStorage>().startIndex);
    }

    public void LevelComplete(bool alive)
    {
        
        gameMusic.transform.GetComponent<AudioSource>().Stop();
        healthBar.GetComponent<HealthBehaviour>().decaying = false;

        complete = true;
        canType = false;

        var end = Instantiate(endScreen, new Vector3(0, 0, 0), Quaternion.identity);
        end.transform.SetParent(mainCanvas.transform);


        if (alive)
        {
            print("YOU WON!");
        }
        else
        {
            print("YOU LOSE!");
        }
    }

    public void Confused()
    {
        anim.Play("monkeyConfused");
        var aud = Instantiate(soundSample, transform.position, Quaternion.identity);
        aud.GetComponent<SoundSample>().SpawnSound(monkeyMoveSounds[1], 0, 100);

        StartCoroutine(Confusion());

    }

    IEnumerator Confusion()
    {
        string[] randomWords = { "banana", "swing", "tree", "poop", "fruit", "Cebidae", "Hylobatidae", "arboreal", "savanna", "catarrhine", "brown", "garbage", "typeracer", "gamemakerstoolkit", "hair", "walk", "climb", "clock", "ape", "meso", "axi", "crunch", "bone", "gorilla", "orangutan", "baboon", "jungle", "mango", "coconut", "mammal", "papaya", "primate", "australopithecus", "Mark" };
        string word = randomWords[Random.Range(0, randomWords.Length)];
        int charCount = word.Length;

        while (charCount > 0)
        {


            charNumber++;
            lineStorage.GetComponent<LineStorage>().characterIndex++;
            string addedChar = word.Substring(word.Length - charCount, 1);
            theText.text += addedChar;
            CheckGay();
            if (lineStorage.GetComponent<LineStorage>().CheckChar(addedChar))
            {
                textDisplay.GetComponent<TextMeshPro>().text += "<#008000ff>" + addedChar;
            }
            else
            {
                textDisplay.GetComponent<TextMeshPro>().text += "<#ff0000ff>" + addedChar;
            }

            displayLineNoHex += addedChar;


            yield return new WaitForSeconds(0.02f);
            charCount--;
        }
    }

    IEnumerator TutorialMistake()
    {
        
            anim.Play("monkeyLaugh");
            var aud = Instantiate(soundSample, transform.position, Quaternion.identity);
            aud.GetComponent<SoundSample>().SpawnSound(monkeyMoveSounds[2], 0, 100);
            charNumber++;
            lineStorage.GetComponent<LineStorage>().characterIndex++;
            string addedChar = "y";
            theText.text += addedChar;
            CheckGay();
            if (lineStorage.GetComponent<LineStorage>().CheckChar(addedChar))
            {
                textDisplay.GetComponent<TextMeshPro>().text += "<#008000ff>" + addedChar;
            }
            else
            {
                textDisplay.GetComponent<TextMeshPro>().text += "<#ff0000ff>" + addedChar;
            }

            displayLineNoHex += addedChar;


            yield return new WaitForSeconds(0.02f);
            
        
    }
    
    void Tutorial()
    {
        
            if (lineStorage.GetComponent<LineStorage>().tutorialScript[0] == wordCount)
            {
                if (Input.GetKeyDown(KeyCode.U) && durability0 > 0)
                {
                    StartCoroutine(TutorialMistake());
                    durability0--;
                }
            }

        if (lineStorage.GetComponent<LineStorage>().tutorialScript[1] == wordCount)
        {
            if (Input.GetKeyDown(KeyCode.F) && durability1 > 0)
            {
                StartCoroutine(TutorialMistake());
                durability1--;
            }
        }

        if (lineStorage.GetComponent<LineStorage>().tutorialScript[2] == wordCount)
        {
            if (Input.GetKeyDown(KeyCode.P) && durability2 > 0)
            {
                StartCoroutine(TutorialMistake());
                durability2--;
            }
        }

        if (lineStorage.GetComponent<LineStorage>().tutorialScript[3] == wordCount)
        {
            if (Input.GetKeyDown(KeyCode.C) && durability3 > 0)
            {
                SpawnBanana();
                durability3--;
            }
        }

        if (lineStorage.GetComponent<LineStorage>().tutorialScript[4] == wordCount)
        {
            if (Input.GetKeyDown(KeyCode.X) && durability4 > 0)
            {
                Confused();
                durability4--;
            }
        }

    }

    void Mistake()
    {
        float randomVal = Random.Range(0, 100);

        

        if(randomVal <= 1)
        {
            Confused();
        }
        else if (randomVal <= 2)
        {
            SlamAttack();
        }
        else if (randomVal <= 3)
        {
            Mistype();
        }
        else if (randomVal <= 4)
        {
            SpawnBanana();
        }
    }

    void SpawnBanana()
    {
        if (!isBanana)
        {
            var aud = Instantiate(soundSample, transform.position, Quaternion.identity);
            aud.GetComponent<SoundSample>().SpawnSound(monkeyMoveSounds[3], 0, 100);
            isBanana = true;
            anim.Play("monkeyConfused");
            Instantiate(banana, new Vector3(0, 0, 0), Quaternion.identity);
        }
        
    }

    void KillBanana()
    {
        if(GameObject.Find("Banana(Clone)") != null)
        {
            GameObject.Find("Banana(Clone)").GetComponent<Banana>().Kill();
            isBanana = false;
        }
            
        
        
    }

    void Mistype()
    {
        
        
        anim.Play("monkeyLaugh");
        var aud = Instantiate(soundSample, transform.position, Quaternion.identity);
        aud.GetComponent<SoundSample>().SpawnSound(monkeyMoveSounds[2], 0, 100);
        ScreenShake(0.02f, 0.1f);
        StartCoroutine(Slam(1));
    }

    public void UpdateLookAhead()
    {
        //lookahead.GetComponent<TextMeshPro>().text = ;

    }
    



}
