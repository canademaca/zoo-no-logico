using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoBoton: MonoBehaviour
{
    public Button button;
    private AudioSource audioSource;

    void Start()
    {
        // Busca el objeto persistente GameManager
        GameObject gameManagerObj = GameObject.Find("GameManager");

        // Obtén el AudioSource del objeto persistente
        audioSource = gameManagerObj.GetComponent<AudioSource>();

        // Agregar un listener al botón para llamar a la función cuando se hace clic
        button.onClick.AddListener(PlayButtonClickSound);
    }

    void PlayButtonClickSound()
    {
        // Reproducir el sonido desde el objeto persistente
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
