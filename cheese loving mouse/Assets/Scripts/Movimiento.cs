using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float velocidad,velocidadMaxima,velocidadInicial;
    public float longitudRaycast;
    public LayerMask capaSuelo, capaTrampolin;
    public float salto;
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;
    public bool saltoMejorado,saltando,suelo,rebotando;
    public float MuchaFuerza,PocaFuerza;
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
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right") || Input.GetKey("a") || Input.GetKey("left"))
        {
        }
        else
        {
            anim.SetBool("run", false);
        }
        if (Input.GetAxis("Horizontal") <0)
        {
            sr.flipX = true;
            anim.SetBool("run", true);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
            anim.SetBool("run", true);
        }
        
        float VelocidadX=Input.GetAxis("Horizontal")*Time.deltaTime*velocidad;
        Vector3 position=transform.position;
        transform.position=new Vector3(VelocidadX+position.x, position.y, position.z);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        suelo = hit.collider != null;
        
        if (Input.GetKeyDown(KeyCode.Space) && suelo)
        {
            rb2d.AddForce(new Vector2(0f, salto), ForceMode2D.Impulse);
            //rb2d.velocity = new Vector2(rb2d.velocity.x, salto);
        }
        if (Input.GetKey("k"))
        {
            anim.speed = 1;
            velocidad = velocidadMaxima;
        }
        else
        {
            anim.speed = 0.5f;
            velocidad = velocidadInicial;
        }

        if (suelo)
        {
            anim.SetBool("jump", false);
        }
        if (!suelo)
        {
            anim.SetBool("jump", true);
            anim.SetBool("run", false);
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

        if (Input.GetKeyDown("space"))
        {
            saltando = true;
        }
        if (Input.GetKeyUp("space"))
        {
            saltando = false;
        }
    }
    
}
