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

    /**************************************************************************************************************************************************
    * Purpose: Changes sprite and moves button downwards upon being left clicked
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
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

    /**************************************************************************************************************************************************
    * Purpose: Resets sprite and moves back to original position.
    * Parameters:
    *     Arguments: N/A
    *
    *     Return: N/A (void function).
    ***************************************************************************************************************************************************/
    void Unpress()
    {
        GetComponent<Image>().sprite = norm;
        childText.anchoredPosition = new Vector3(childText.localPosition.x, childText.localPosition.y + 3f, childText.localPosition.z);
    }
}
