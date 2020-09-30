using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = GameObject.Find("DataStorage").GetComponent<LevelController>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("DataStorage").GetComponent<LevelController>().volume = slider.value;
    }
}
