using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour  {
    
    public bool open = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 360f;
    public float smooth = 2f;


    public void ChangeDoorState()
    {
        open = !open;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame - rotation of door
    void Update()
    {
        if(open) //if open == true
        {   
            Quaternion targetRotation = Quaternion.Euler(0,doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime); 
;
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0,doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);

        }

}
}
