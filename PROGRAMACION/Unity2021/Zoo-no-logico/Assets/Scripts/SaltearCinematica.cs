using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SaltearCinematica : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] public GameObject script;

    void Awake()
    {
        video = GameObject.Find(PlayerPrefs.GetString("Cinematica")).GetComponent<VideoPlayer>();
    }

    public void Saltear()
    {
        script.SendMessage("onMovieEnd", video);
    }
}
