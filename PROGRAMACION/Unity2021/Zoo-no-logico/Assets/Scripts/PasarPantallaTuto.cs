﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarPantallaTuto : MonoBehaviour {


    public GameObject Pantalla;
    public GameObject Pantalla2;
    public GameObject Pantalla3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PasarPantalla()
    {
        Pantalla.SetActive(false);
        Pantalla2.SetActive(true);
        Pantalla3.SetActive(true);

    }

    public void VolverPantalla()
    {
        Pantalla.SetActive(true);
        Pantalla2.SetActive(false);
        Pantalla3.SetActive(false);
    }
}
