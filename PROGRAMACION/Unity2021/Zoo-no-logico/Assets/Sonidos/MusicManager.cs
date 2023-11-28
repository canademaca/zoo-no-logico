using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
                }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            gameObject.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 0.2f;
        }
    }
}
