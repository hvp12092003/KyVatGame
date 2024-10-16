using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public GameObject image;
    public VideoPlayer videoCurrent;
    public void Start()
    {
        image = GameObject.FindGameObjectWithTag("image");
    }
    public void TurnOffImage()
    {
        image.SetActive(false);
    }
    public void PlayVideo(VideoPlayer video)
    {
        if (videoCurrent != null) videoCurrent.Stop();
        video.Play();
        videoCurrent = video;
    }
}
