using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC : MonoBehaviour
{
    public bool flipped = false;
    public bool hasBatteries = false;

    public GameObject rcController;
    public GameObject onSwitch;
    public GameObject Battery1;
    public GameObject Battery2;

    public GameObject offText;
    public GameObject onText;

    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator WaitForSecOff()
    {
        yield return new WaitForSeconds(2);
        offText.SetActive(false);
    }


    public void ChangeRotateState()
    {
        flipped = !flipped;
    }

    public void ChangeBatteryState()
    {
        if (Battery1.activeSelf && Battery2.activeSelf)
        {
            hasBatteries = true;
            //ChangeRotateState();
            car.GetComponent<CarEngine>().enabled = true;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            offText.SetActive(true);
            StartCoroutine("WaitForSecOff");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(flipped == true) //if rc is flipped
        {   
            Quaternion targetRotation = Quaternion.Euler(-180,90, 90);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 5 * Time.deltaTime);
        }
        else if (flipped == false)
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, 90, 90);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, 5 * Time.deltaTime);

        }
        else if (hasBatteries == true) //if batteries are inserted
        {
            print ("The controller has batteries.");
        }

        else if (hasBatteries == false) //if batteries are not inserted
        {
          //  RCText.SetActive(true);
           // StartCoroutine("WaitForSec");
           print("No batteries.");
        }
    }

}
