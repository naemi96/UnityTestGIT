using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverDialogue : MonoBehaviour
{
    public GameObject buttonText;


    // Start is called before the first frame update
    void OnMouseOver()
    {
        buttonText.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }

}
