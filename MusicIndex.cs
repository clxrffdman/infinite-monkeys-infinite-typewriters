using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicIndex : MonoBehaviour
{

    public AudioClip[] gameMusic;
    public AudioSource aud;
    public float index;
    public float vol;
    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.Find("DataStorage") != null)
        {
            index = GameObject.Find("DataStorage").GetComponent<LevelController>().difficulty;
            vol = GameObject.Find("DataStorage").GetComponent<LevelController>().volume;
        }
    }

    void Start()
    {
        
        aud = GetComponent<AudioSource>();
        aud.volume = vol;
        aud.clip = gameMusic[(int)index];
        aud.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
