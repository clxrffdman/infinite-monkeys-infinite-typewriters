using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    //health and maximum health values
    public float health;
    public float maxHealth;
    
    //GameObject set within Unity Editor to the healthBar gameObject in scene.
    public GameObject healthBar;
    
    //float variables which determine the rate that health decays over time and how much health player loses per mistake 
    public float timeDecay;
    public float healthChunk;
    public float healthGain;

    //Boolean variables for testing purposes to test if alive and/or decaying
    public bool alive;
    public bool decaying;

    //Integer representing difficulty value
    public int diff;
    
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        maxHealth = 1000;
        healthBar = GameObject.Find("HealthBar");
        health = 1000;
        decaying = true;
        StartCoroutine(Decay());
        Invoke("CheckDiff", 0.05f);
    }

    /**************************************************************************************************************************************************
    * Purpose: Checks the difficulty of the level and sets timeDecay, healthChunk, and healthGain respectively.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    void CheckDiff()
    {
        diff = GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty;

        if(diff == 0)
        {
            timeDecay = 0.75f;
            healthChunk = 60;
            healthGain = 75;
        }

        if (diff == 1)
        {
            timeDecay = 0.85f;
            healthChunk = 65;
            healthGain = 70;
        }

        if (diff == 2)
        {
            timeDecay = 1.2f;
            healthChunk = 65;
            healthGain = 70;
        }

        if (diff == 3)
        {
            timeDecay = 1.2f;
            healthChunk = 70;
            healthGain = 65;
        }

        if (diff == 4)
        {
            timeDecay = 0.85f;
            healthChunk = 65;
            healthGain = 70;
        }

        if (diff == 5)
        {
            timeDecay = 1.2f;
            healthChunk = 70;
            healthGain = 65;
        }
    }

    /**************************************************************************************************************************************************
    * Purpose: Visually and internally decay health every frame based on values.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    void Update()
    {
        if(health <= 0 && alive)
        {
            alive = false;
            GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().LevelComplete(false);

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().seconds == 0)
            {
                GameObject.Find("InputTextBox").transform.GetChild(0).GetChild(0).GetComponent<TextInput>().seconds = 1;
            }

            health = 0;
        }
        healthBar.transform.localScale = new Vector3(2f * (health / maxHealth), 3, 3.75f);
    }

    /**************************************************************************************************************************************************
    * Purpose: Coroutine which continually decays health based on timeDecay value.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    IEnumerator Decay()
    {
        
        
            while (decaying)
            {
                if (health > 0)
                {
                    health -= timeDecay;
                }

                yield return new WaitForSecondsRealtime(0.016f);
            }

        

        decaying = false;
        

    }

    /**************************************************************************************************************************************************
    * Purpose: Adds health to the player
    * Parameters:
    *     Arguments: float val; used as amount of health to be given to player
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void AddHealth(float val)
    {
        if(health + val > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += val;
        }
    }

    /**************************************************************************************************************************************************
    * Purpose: Subtracts health from the player.
    * Parameters:
    *     Arguments: float val; used as amount of health to be taken from player.
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void LoseHealth(float val)
    {
        if (health - val <= 0)
        {
            health = 0;
        }
        else
        {
            health -= val;
        }
    }
}
