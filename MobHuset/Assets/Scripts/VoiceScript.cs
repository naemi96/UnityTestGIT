using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class VoiceScript : MonoBehaviour {

    public bool played = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider other){
        
        if(other.tag == "Player") {
            if(played == false)
            {
                played = true;
                this.GetComponent<AudioSource>().Play();
                Debug.Log("Played Sound!");
            }
        }
  }
}

