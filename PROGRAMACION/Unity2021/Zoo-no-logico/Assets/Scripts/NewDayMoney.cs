﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewDayMoney : MonoBehaviour {

    public Text newMoneyText;
    public TextAsset Cruzas;

    [System.Serializable]
    public class Cruza
    {
        public string id;
        public string nombre;
        public int dinero;
        public int popularidad;
    }

    private int cage1Money = 0;
    private int cage2Money = 0;
    private int cage3Money = 0;
    private int cage4Money = 0;
    private int cage5Money = 0;
    private float popularity = 75;
    private float cageDivisor = 2;
    private float popularityMultipliyer;
    private float newMoney;
    private int newMoneyInt;
    float Monedas;
    private int impuestoDeuda = 0;
    float impuestoDiario = 0;

    float impuestoDiarioMultiplicador;
    float impuestoPorNoHacerCruzasMultiplicador;

    [System.Serializable]
    public class CruzaList
    {
        public Cruza[] cruza;
    }

    public CruzaList myCruzaList = new CruzaList();

    // Use this for initialization
    void Start()
    {

        myCruzaList = JsonUtility.FromJson<CruzaList>(Cruzas.text);
        PlayerPrefs.SetFloat("cageDivisor", cageDivisor);


        for (int i = 0; i < 20; i++)
        {
            if (PlayerPrefs.GetString("Jaula" + i).Length > 0)
            {
                int jaul = int.Parse(PlayerPrefs.GetString("Jaula" + i));
                print(PlayerPrefs.GetInt("Jaula" + i));
                print(jaul);
                if (int.Parse(PlayerPrefs.GetString("Jaula" + i)) != 89)
                {
                    PlayerPrefs.SetInt("cage" + i + "Money", myCruzaList.cruza[int.Parse(PlayerPrefs.GetString("Jaula" + i))].dinero);
                    print(PlayerPrefs.GetString("Jaula" + i));
                }

            }
        }
    }



    

    private void Update()
    {

    }


    public void AddMoney()
    {

        popularityMultipliyer = popularity / 100 + 1;
        if (GameObject.FindGameObjectWithTag("NewTextoMonedas")) { 
        newMoneyText = GameObject.FindGameObjectWithTag("NewTextoMonedas").GetComponent<Text>();
        }

        if (PlayerPrefs.GetInt("Moneditas") < 0)
        {
            impuestoDeuda = 12;
        }
        else{
            impuestoDeuda = 0;
        }

        //impuestoDiarioMultiplicador = 0.2f * PlayerPrefs.GetInt("Dias");


        //float x = PlayerPrefs.GetInt("Dias");

        //impuestoDiarioMultiplicador = Mathf.Log(PlayerPrefs.GetInt("Dias"), 2);
        impuestoDiarioMultiplicador = 2;

        if (impuestoDiarioMultiplicador < 1)
        {
            impuestoDiarioMultiplicador = 1;
        }

        if (PlayerPrefs.GetInt("ImpuestoXDiasSinCruzas") > 3)
        {

            impuestoPorNoHacerCruzasMultiplicador = PlayerPrefs.GetInt("ImpuestoXDiasSinCruzas") + 1;
        }
        else 
        {
            impuestoPorNoHacerCruzasMultiplicador = 0;
        }
        int impuestoPopularidad = impuestoDeuda + Mathf.RoundToInt(impuestoPorNoHacerCruzasMultiplicador * impuestoDiarioMultiplicador);

        // impuestoDiario = ((PlayerPrefs.GetInt("JaulasOcupadas") * 300) + 150) * impuestoDiarioMultiplicador * impuestoPorNoHacerCruzasMultiplicador;

        impuestoDiario = ((PlayerPrefs.GetInt("JaulasOcupadas") * 400) + 150);

        PlayerPrefs.SetInt("Popularidad", PlayerPrefs.GetInt("Popularidad") - impuestoPopularidad);



        newMoney = ((PlayerPrefs.GetInt("cage0Money") / cageDivisor + PlayerPrefs.GetInt("cage1Money") / cageDivisor + PlayerPrefs.GetInt("cage2Money") / cageDivisor + PlayerPrefs.GetInt("cage3Money") / cageDivisor + PlayerPrefs.GetInt("cage4Money")/cageDivisor + PlayerPrefs.GetInt("cage5Money")/cageDivisor + PlayerPrefs.GetInt("cage6Money") / cageDivisor + PlayerPrefs.GetInt("cage7Money") / cageDivisor + PlayerPrefs.GetInt("cage8Money") / cageDivisor + PlayerPrefs.GetInt("cage9Money")/cageDivisor + PlayerPrefs.GetInt("cage10Money")/cageDivisor + PlayerPrefs.GetInt("cage11Money") / cageDivisor + PlayerPrefs.GetInt("cage12Money") / cageDivisor + PlayerPrefs.GetInt("cage13Money") / cageDivisor + PlayerPrefs.GetInt("cage14Money") / cageDivisor + PlayerPrefs.GetInt("cage15Money") / cageDivisor + PlayerPrefs.GetInt("cage16Money") / cageDivisor + PlayerPrefs.GetInt("cage17Money") / cageDivisor + PlayerPrefs.GetInt("cage18Money") / cageDivisor + PlayerPrefs.GetInt("cage19Money") / cageDivisor + PlayerPrefs.GetInt("cage20Money") / cageDivisor) * popularityMultipliyer) - (int)impuestoDiario;
        PlayerPrefs.SetFloat("popularityMultipliyer", popularityMultipliyer);
        PlayerPrefs.SetFloat("impuestoDiario", impuestoDiario);
        PlayerPrefs.SetInt("impuestoDeuda", impuestoPopularidad);
        if (newMoney < 0)
        {
            newMoneyText.color = Color.red;
        }
        else
        {
            newMoneyText.color = new Color(0.1607843f, 0.3137255f, 0.1372549f);
        }

        newMoneyInt = (int)newMoney;
        PlayerPrefs.SetInt("newMoneyInt", newMoneyInt);
        newMoneyText.text = newMoneyInt.ToString();
        Monedas = PlayerPrefs.GetInt("Moneditas");
        Monedas = Monedas + (int)newMoneyInt;
        PlayerPrefs.SetInt("Moneditas", (int)Monedas);
    }
}
