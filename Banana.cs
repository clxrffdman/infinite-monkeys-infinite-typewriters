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
        transform.position = new Vector3(-10f, 2.25f, 0);

        LeanTween.moveX(gameObject, -4.5f, 0.1f);
        LeanTween.rotate(gameObject, new Vector3(0, 0, Random.Range(-180, 180)), 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
