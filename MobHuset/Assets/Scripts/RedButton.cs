using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour  {
    
    public bool clicked = false;
    public GameObject libraryLampTurnOn;
    public GameObject libraryLampMaterial;
    public GameObject libraryLampMaterial1;
    public Material lightOn;


    void Start ()
    {

    }

    public void ChangeClickState()
    {
        clicked = !clicked;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame - rotation of door
    void Update()
    {
        if(clicked)
        {   
            libraryLampMaterial.GetComponent<MeshRenderer>().material = lightOn;
            libraryLampMaterial1.GetComponent<MeshRenderer>().material = lightOn;
            libraryLampTurnOn.SetActive(true);

        }

}
}
