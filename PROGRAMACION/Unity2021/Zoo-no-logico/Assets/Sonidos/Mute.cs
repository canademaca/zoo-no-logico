using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoManager : MonoBehaviour
{
    public static SonidoManager instance;

    public AudioSource[] allAudioSources;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Obtener todas las instancias de AudioSource en el juego
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    public void ToggleAllSound(bool isMuted)
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.mute = isMuted;
        }
    }
}
    

