using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float velocidad,velocidadMaxima,velocidadInicial;
    public float salto;
    public float longitudRaycast;
    public float fuerzaRebote;

    public LayerMask capaSuelo, capaTrampolin;

    
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;

    public bool saltoMejorado,saltando,suelo,rebotando;
    public float MuchaFuerza,PocaFuerza;

    bool daño;
    public HpJugador hpJugador;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        velocidadMaxima = velocidad + 3;
        velocidadInicial = velocidad;
        saltando = false;
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position,transform.position+Vector3.down*longitudRaycast);
    }
    private void Update()
    {
        
        float VelocidadX=Input.GetAxis("Horizontal")*Time.deltaTime*velocidad;
        anim.SetFloat("run", VelocidadX*velocidad);

        if (VelocidadX < 0)
        {
            //transform.localScale=new Vector3(-7,7,1);
            sr.flipX = true;

        }
        if (VelocidadX > 0)
        {
            //transform.localScale = new Vector3(7, 7, 1);
            sr.flipX = false;
        }

        Vector3 position=transform.position;

        if (!daño)
        {
            transform.position = new Vector3(VelocidadX + position.x, position.y, position.z); 
        }
        

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        suelo = hit.collider != null;
        
        if (Input.GetKeyDown(KeyCode.Space) && suelo&&!daño)
        {
            rb2d.AddForce(new Vector2(0f, salto), ForceMode2D.Impulse);
            //rb2d.velocity = new Vector2(rb2d.velocity.x, salto);
        }

        if (Input.GetKey("k"))
        {
            anim.speed = 1.2f;
            velocidad = velocidadMaxima;
        }
        else
        {
            anim.speed = 0.6f;
            velocidad = velocidadInicial;
        }

        if (saltoMejorado)
        {
            if (rb2d.velocity.y < 0)
            {

                rb2d.velocity += Vector2.up * Physics2D.gravity.y * MuchaFuerza * Time.deltaTime;
            }
            if (rb2d.velocity.y > 0 & !Input.GetKey("space"))
            {

                rb2d.velocity += Vector2.up * Physics2D.gravity.y * PocaFuerza * Time.deltaTime;
            }
        }

        anim.SetBool("ensuelo", suelo);
        anim.SetBool("recibeDaño", daño);

    }
    
    public void recibeDaño(Vector2 direccion, int cantDaño)
    {
        if (!daño)
        {
            daño = true;
            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 0.5f).normalized;
            rb2d.AddForce(rebote * fuerzaRebote, ForceMode2D.Impulse);
        }
    }

    public void desactiveDaño()
    {
        daño = false;
        rb2d.velocity = Vector2.zero;
    }
}
