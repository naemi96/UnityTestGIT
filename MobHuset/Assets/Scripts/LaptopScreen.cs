using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopScreen : MonoBehaviour
{
    public bool isPlaying = false;

    // Start is called before the first frame update
    public void ChangePlayState ()
    {
        var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
        isPlaying = !isPlaying;

        if(!isPlaying)
        {
            vp.Pause();
        }

        else 
        {
            vp.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
