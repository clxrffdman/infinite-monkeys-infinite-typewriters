using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSample : MonoBehaviour
{
    public AudioSource aud;
    public float lifetime;
    public float blend;
    public AudioClip clip;
    public bool playing;

    void Awake()
    {
        aud = GetComponent<AudioSource>();
        playing = false;
        lifetime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            lifetime = lifetime - Time.deltaTime;
        }

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    /**************************************************************************************************************************************************
    * Purpose: Sets aud parameters based on input values, set by the object instantiating this object.
    * Parameters:
    *     Arguments: AudioClip a, float b, float vol
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    public void SpawnSound(AudioClip a, float b, float vol)
    {
        lifetime = a.length;
        aud.volume = vol;
        aud.clip = a;
        aud.panStereo = b;
        playing = true;
        PlaySound();
    }

    /**************************************************************************************************************************************************
    * Purpose: Plays the AudioClip clip through aud, the AudioSource on this gameObject.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    void PlaySound()
    {
        aud.Play();
    }
}
