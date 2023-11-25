using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAceptar : MonoBehaviour
{

    public GameObject BotonAccept;
    public GameObject PopUp;
    public GameObject Cerrar;
    public bool cartel = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {
        if(cartel == false)
        {
            BotonAccept.SetActive(false);
            PopUp.SetActive(false);
            cartel = true;
            Cerrar.SetActive(true);

        }

        cartel = true;
    }
}
