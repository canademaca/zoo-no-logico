using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SaltearCinematica : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] public GameObject script;

    [SerializeField] private GameObject ANALYTICS;

    void Start()
    {
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");
    }

    void Awake()
    {
        video = GameObject.Find(PlayerPrefs.GetString("Cinematica")).GetComponent<VideoPlayer>();
    }

    public void Saltear()
    {
        PlayerPrefs.SetInt("cinematicasSalteadas", PlayerPrefs.GetInt("cinematicasSalteadas") + 1);
        ANALYTICS.SendMessage("saltear_cinematica");
        script.SendMessage("onMovieEnd", video);
    }
}
