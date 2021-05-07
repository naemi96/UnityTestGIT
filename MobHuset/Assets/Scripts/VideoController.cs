using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class VideoController : MonoBehaviour
{
    public string url;
    VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.url = Path.Combine(Application.streamingAssetsPath + url);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
