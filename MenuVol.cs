using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVol : MonoBehaviour
{
    public AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aud.volume = GameObject.Find("DataStorage").GetComponent<LevelController>().volume;
    }
}
