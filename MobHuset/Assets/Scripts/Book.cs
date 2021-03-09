using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeClickState()
    {
        clicked = !clicked;
    }

    // Update is called once per frame
    void Update()
    {
}
}
