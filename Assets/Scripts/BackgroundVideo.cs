using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnLoopPointReached;

        // Start playing the video
        videoPlayer.Play();
    }

    // Called when the video reaches its end
    void OnLoopPointReached(VideoPlayer vp)
    {
        // Rewind the video to the beginning
        vp.Play();
    }

    void OnDestroy()
    {
        // Unsubscribe from the loopPointReached event to avoid memory leaks
        videoPlayer.loopPointReached -= OnLoopPointReached;
    }
}
