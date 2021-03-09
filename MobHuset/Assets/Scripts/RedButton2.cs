using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton2 : MonoBehaviour
{

    public bool clicked = false;
    public GameObject SL1;
    public GameObject SL2;
    public GameObject PL;
    public GameObject Text3;
    public GameObject o1Lights;


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
            SL1.SetActive(true);
            SL2.SetActive(true);
            PL.SetActive(true);
            Text3.SetActive(true);
            o1Lights.SetActive(true);
        }
        
    }
}
