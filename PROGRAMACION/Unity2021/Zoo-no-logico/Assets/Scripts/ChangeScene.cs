using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {


    public GameObject notificacion;
    //public int DineroNeg = 1;


    [SerializeField] private GameObject ANALYTICS;
    void Start()
    { 
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");
    }


    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
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

    public void NotifOff()
    {
        notificacion.SetActive(false);
    }



    public void Minijuego(int SceneID)
    {
        print(PlayerPrefs.GetInt("Minigame"));

        if(PlayerPrefs.GetInt("Minigame") == 0)
        {
            SceneManager.LoadScene(SceneID);
            PlayerPrefs.SetInt("Minigame", 1);
        }

    }
    

    
}
