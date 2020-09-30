using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBOokHover : MonoBehaviour
{
    public GameObject back;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBook()
    {
        anim.Play("bookClose");
    }

    public void CloseBook()
    {
        
        GameObject.Find("LevelControlLoader").GetComponent<MainMenuControlLoader>().ActivateAllBooks();
        back.GetComponent<Animator>().Play("backBookOpen");
        anim.Play("bookOpen");
        GetComponent<Image>().raycastTarget = false;
    }
}
