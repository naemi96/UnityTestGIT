using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestText : MonoBehaviour
{
    public Text test;
    public bool flag;

    // Use this for initialization 
    void Update()
    {
        //flag = true;

        if (flag == true)
        {
            test.text = "Gör ditt drag!";
        }
        else
        {
            test.text = "Den sista siffran är: 5";
        }
    }
}
