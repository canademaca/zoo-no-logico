using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{

    private float velocidad = 3.9f;
    private float salto = 12;
    private bool PuedeSaltar;
    private bool PuedeAgachar;
    private float horizontal;
    private int vidas;
    private bool isFacingRight = false;



    public enum GameState { Vivo, Muerto, Revivir }

    public RawImage fondo;
    public float velocidadfondo;

    public RawImage nubes;
    public float velnubes;

    public RawImage ciudad;
    public float velciudad;

    public GameState estado;
    public Animator animpl;


    [SerializeField] Rigidbody2D rb2d;
    SpriteRenderer spritepl;
    public BoxCollider2D Collider;
    public Vector2 StandingHeight;
    public Vector2 CrouchingHeight;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spritepl = GetComponent<SpriteRenderer>();
        StandingHeight = Collider.size;

        estado = GameState.Vivo;
        vidas = 3;

        animpl.SetBool("Idle", false);
        animpl.SetBool("Correr", false);
        animpl.SetBool("Salto", false);
        animpl.SetBool("Muerte", false);
        animpl.SetBool("Crouch", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == GameState.Vivo)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (horizontal != 0)
            {

                float velocidadFinal = velocidadfondo * Time.deltaTime * horizontal;
                fondo.uvRect = new Rect(fondo.uvRect.x + velocidadFinal, 0f, 1f, 1f);

                float velFinal = velnubes * Time.deltaTime * horizontal;
                nubes.uvRect = new Rect(nubes.uvRect.x + velFinal, 0f, 1f, 1f);

                float veloFinal = velciudad * Time.deltaTime * horizontal;
                ciudad.uvRect = new Rect(ciudad.uvRect.x + veloFinal, 0f, 1f, 1f);


            }

            if (Input.GetKey("d"))
            {
                rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y);
                spritepl.flipX = false;
                animpl.SetBool("Idle", false);
                animpl.SetBool("Correr", true);

            }

            else
            {
                animpl.SetBool("Correr", false);
            }


            if (Input.GetKey("a"))
            {
                rb2d.velocity = new Vector2(-velocidad, rb2d.velocity.y);
                spritepl.flipX = true;
                animpl.SetBool("Idle", false);
                animpl.SetBool("Correr", true);

            }

            else
            {
                animpl.SetBool("Correr", false);
            }

            if (Input.GetKey("w") && PuedeSaltar)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, salto);
                PuedeSaltar = false;
                animpl.SetBool("Salto", true);
            }

            else
            {

                animpl.SetBool("Salto", false);


            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                animpl.SetBool("Crouch", true);
                Collider.size = CrouchingHeight;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                animpl.SetBool("Crouch", false);
                Collider.size = StandingHeight;
            }


        }
        }

    private void FlipSp()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataformas" || estado == GameState.Vivo)
        {
            PuedeSaltar = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataformas" || estado == GameState.Vivo)
        {
            PuedeSaltar = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            animpl.SetBool("Muerte", true);
            animpl.SetBool("Idle", false);
        }

        else
        {
            animpl.SetBool("Muerte", false);
        }
    }




}



