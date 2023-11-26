using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecompensaMiniGame : MonoBehaviour
{

    public GameObject Collectable01;
    public GameObject Collectable02;
    public GameObject Collectable03;
    public GameObject Collectable04;
    public GameObject Collectable05;

    public int Monedas = 3000;

    // Start is called before the first frame update
    void Start()
    {
        Recompensa();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Recompensa()
    {
        if (Collectable01 == null)
        {
            Monedas = Monedas + 750;
        }

        if (Collectable02 == null)
        {
            Monedas = Monedas + 750;
        }

        if (Collectable03 == null)
        {
            Monedas = Monedas + 750;
        }

        if (Collectable04 == null)
        {
            Monedas = Monedas + 750;
        }

        if (Collectable05 == null)
        {
            Monedas = Monedas + 750;
        }

    }

}

