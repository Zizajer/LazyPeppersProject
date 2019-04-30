using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEnding : MonoBehaviour
{
    public VideoPlayer video;
    public string SceneToLoadName;

    // Start is called before the first frame update
    void Start()
    {
        video.loopPointReached += EndReached;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneToLoadName);
        }
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneToLoadName);
    }
}
