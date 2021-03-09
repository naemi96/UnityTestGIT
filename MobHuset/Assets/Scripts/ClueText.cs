using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueText : MonoBehaviour
{
    public bool isPlaying = false;

    public void ChangePlayState()
    {
        print ("Animation startar");
        Animator anim = gameObject.GetComponent<Animator>();
        isPlaying = !isPlaying;

        if (!isPlaying)
        {
            //anim.SetTrigger("Active");
        }

        else
        {
            anim.SetTrigger("Active");
        }
    }

}
