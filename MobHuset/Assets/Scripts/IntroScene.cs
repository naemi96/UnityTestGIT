using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroScene : MonoBehaviour
{
    public VideoPlayer vp;
    public GameObject videoImage;
    public GameObject sceneAfterVid;

    // Start is called before the first frame update
    void Start()
    {
        vp.loopPointReached += LoadPanel;
    }

    public void LoadPanel(VideoPlayer vp)
    {
        sceneAfterVid.SetActive(true);
        videoImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
