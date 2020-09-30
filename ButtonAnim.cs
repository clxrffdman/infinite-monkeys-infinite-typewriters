using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonAnim : MonoBehaviour, IPointerDownHandler
{
    
    
    public Sprite norm;
    public Sprite hover;
    public Sprite pressed;
    public Button button;

    public RectTransform childText;

    public Action unpress;

    // Start is called before the first frame update
    void Start()
    {
        unpress = Unpress;
        childText = transform.GetChild(0).GetComponent<RectTransform>();
        button = GetComponent<Button>();
        GetComponent<Image>().sprite = norm;
    }


    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //When user left-clicks on button...
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            //change sprite to pressed state
            GetComponent<Image>().sprite = pressed;
            childText.anchoredPosition = new Vector3(childText.localPosition.x, childText.localPosition.y - 3f, childText.localPosition.z);
            LeanTween.delayedCall(gameObject, 0.35f, unpress).setIgnoreTimeScale(true);
        }
    }

    //Resets press sprites and moves button back to original position
    void Unpress()
    {
        GetComponent<Image>().sprite = norm;
        childText.anchoredPosition = new Vector3(childText.localPosition.x, childText.localPosition.y + 3f, childText.localPosition.z);
    }
}
