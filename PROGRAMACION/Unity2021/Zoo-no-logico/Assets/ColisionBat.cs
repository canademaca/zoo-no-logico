using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBat : MonoBehaviour
{
    public Rigidbody2D rbd2;
    public GameObject Perdiste;
    public GameObject Animal;
    public SpriteRenderer anim;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.tag == "AnimalCapturado")
        {
            Destroy(Animal);
            Perdiste.SetActive(true);
            Destroy(anim);
        }
    }
}
