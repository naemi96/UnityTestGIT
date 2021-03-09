using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public bool flipped = false;
    public float smooth = 2f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeCarState()
    {
        flipped = !flipped;
        //GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(flipped == true) //if car is flipped
        {   
            Quaternion targetRotation = Quaternion.Euler(0,90, -90);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, 90, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);

        }
    }
}

