﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    [SerializeField] private GameObject ANALYTICS;
    public AudioSource sound;
    public AudioClip Sonidoboton;
    [SerializeField] public CambioDeDia scriptDia;
    public int CinematicaNumero;



    void Start()
    {
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");

    }


    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void OpenCinematic()
    {
        if(PlayerPrefs.GetInt("Popularidad") >= 100 && PlayerPrefs.GetInt("Ganaste") == 0)
        {
            scriptDia.Pasar();
            PlayerPrefs.SetString("Cinematica", "GOOD_END");
            SceneManager.LoadScene(17);
            print(PlayerPrefs.GetString("Cinematica"));
        }
        else if(PlayerPrefs.GetInt("Popularidad") <= 0 && PlayerPrefs.GetInt("Ganaste") == 0)
        {
            scriptDia.Pasar();
            PlayerPrefs.SetString("Cinematica", "BAD_END");
            SceneManager.LoadScene(17);
            print(PlayerPrefs.GetString("Cinematica"));
        }
        else if(PlayerPrefs.GetInt("Dias") % 3 == 0)
        {
            scriptDia.Pasar();
            CinematicaNumero = PlayerPrefs.GetInt("CinematicaNumero");
            CinematicaNumero += 1;
            PlayerPrefs.SetInt("CinematicaNumero", CinematicaNumero);
            PlayerPrefs.SetString("Cinematica", "C0" + CinematicaNumero);
            SceneManager.LoadScene(17);
            print(PlayerPrefs.GetString("Cinematica"));
        }
        else
        {
            scriptDia.Pasar();
            print("pasar dia");
        }
        
    }

    public void VolverAJugar()
    {
        PlayerPrefs.SetInt("Dias", 0);
    }

    public void NoRestarAnimales()
    {
        PlayerPrefs.SetInt("Cantidad" + PlayerPrefs.GetString("Slot1"), PlayerPrefs.GetInt("Cantidad" + PlayerPrefs.GetString("Slot1")) + 1);
        PlayerPrefs.SetInt("Cantidad" + PlayerPrefs.GetString("Slot2"), PlayerPrefs.GetInt("Cantidad" + PlayerPrefs.GetString("Slot2")) + 1);
        PlayerPrefs.SetInt("Cantidad" + PlayerPrefs.GetString("Slot3"), PlayerPrefs.GetInt("Cantidad" + PlayerPrefs.GetString("Slot3")) + 1);
    }

    public void SumarContinuarParaAnalytics(string playerPref)
    {
        PlayerPrefs.SetInt(playerPref, PlayerPrefs.GetInt(playerPref) + 1);
    }

    public void ejecutarAccionAnalytics(string accion)
    {
        ANALYTICS.SendMessage(accion);
    }

    public void SoundButton()
    {
        sound.clip = Sonidoboton;
        sound.enabled = false;
        sound.enabled = true;
        DontDestroyOnLoad(this);
    }
}
