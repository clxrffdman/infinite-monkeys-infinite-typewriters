using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    //sprites is an array of all possible banana sprites
    public Sprite[] sprites;
    //spriteInt represents the current sprite index.
    public int spriteInt;

    // Start is called before the first frame update
    void Start()
    {
        //sets position of banana to preset position
        transform.position = new Vector3(-10f, 2.25f, 0);

        //moves banana in the span of 0.1sec while rotating it to a random orientation
        LeanTween.moveX(gameObject, -4.5f, 0.1f);
        LeanTween.rotate(gameObject, new Vector3(0, 0, Random.Range(-180, 180)), 0.1f);
    }

    /**************************************************************************************************************************************************
    * Purpose: Kills this gameObject (banana)
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void Kill()
    {
        Destroy(gameObject);
    }
}
