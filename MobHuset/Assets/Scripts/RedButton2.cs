using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton2 : MonoBehaviour
{

    public bool clicked = false;
    public GameObject Text3;
    public GameObject hintLight;
    public GameObject femfyra;
    public GameObject office1Lights;


     public void ChangeClickState()
        {
            clicked = !clicked;
            GetComponent<AudioSource>().Play();
        }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            Text3.SetActive(true);
           
            hintLight.SetActive(true);
            femfyra.SetActive(true);
            office1Lights.SetActive(true);
        }
        
    }
}
