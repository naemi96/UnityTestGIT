using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTrigger : MonoBehaviour
{
    public GameObject confRoomLights;

    public bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        
        if(other.tag == "Player") {
            if(isTriggered == false)
            {
                isTriggered = true;
                confRoomLights.SetActive(true);
            }
        }
  }
}
