using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{

    [SerializeField] private VideoPlayer video;
    [SerializeField] public GameObject continuar;
    [SerializeField] public GameObject ganar;
    [SerializeField] public GameObject perder;
    [SerializeField] public GameObject saltear;
    [SerializeField] public GameObject fondo;
  

    // Start is called before the first frame update  

    void Awake() //
    {
        video = GameObject.Find(PlayerPrefs.GetString("Cinematica")).GetComponent<VideoPlayer>();

        print("ESCENA " + PlayerPrefs.GetString("Cinematica"));
    }


    // Update is called once per frame
    void Update()
    {
        video.loopPointReached += onMovieEnd;
    } 

    public void onMovieEnd(UnityEngine.Video.VideoPlayer vp)
    {
        print("Termino video");
        fondo.SetActive(true);
        video.Stop();
        saltear.SetActive(false);
        if (PlayerPrefs.GetString("Cinematica") == "GOOD_END")
        {
            ganar.SetActive(true);
        }
        else if(PlayerPrefs.GetString("Cinematica") == "BAD_END")
        {
            perder.SetActive(true);
        }
        else
        {
            continuar.SetActive(true);
        }
    }   

    
}
