﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioDeDia : MonoBehaviour {


    public Text textoTurno;
    public int numTurno;
    public GameObject Pantalla;
    public GameObject PantallaPostEvento;
    public GameObject PantallaPerder;
    public GameObject PantallaGanar;
    public int Popularidad;

    // Use this for initialization
    void Start () {
        textoTurno = GameObject.FindGameObjectWithTag("TextoDias").GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
        numTurno = PlayerPrefs.GetInt("Dias");
        textoTurno.text = "DIA: "+numTurno.ToString();
        Popularidad = PlayerPrefs.GetInt("Popularidad");
    }


    public void Pasar()
    {
        if (!PantallaPostEvento)
        {
            numTurno++;
            textoTurno.text = "DIA: " + numTurno.ToString();
            Pantalla.SetActive(false);
            PlayerPrefs.SetInt("Dias", numTurno);
        }
        else
        {
            Pantalla.SetActive(false);
        }
    }

    public void AbrirPantalla()
    {
        if (Popularidad >= 100 && PlayerPrefs.GetInt("Ganaste")==0)
        {
            PantallaGanar.SetActive(true);
            PlayerPrefs.SetInt("Ganaste", 1);
        }
        else if (Popularidad <= 0 && PlayerPrefs.GetInt("Ganaste") == 0)
        {
            PantallaPerder.SetActive(true);
        }
        else 
        {
            Pantalla.SetActive(true);
        }

    }

    public void OnPantallaPostEvento()
    {
        if (PantallaPostEvento)
        {
            PantallaPostEvento.SetActive(true);
        }
    }
}


