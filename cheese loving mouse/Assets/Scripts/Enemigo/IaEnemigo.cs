using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class IaEnemigo : MonoBehaviour
{
    public Transform jugador;
    public float radioDeteccion;
    public float velocidad;
    Vector2 direccion;
    Animator eAnim;
    SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector2 movimiento;
    public EnemigoIA EnemigoIA;
    Vector3 scale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        eAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        scale = transform.localScale;
    }

    void Update()
    {
        float distanciaDeJugador = Vector2.Distance(transform.position, jugador.position);

        if(distanciaDeJugador < radioDeteccion)
        {
            direccion = (jugador.position - transform.position).normalized;

            if (direccion.x > 0)
            {
                transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                EnemigoIA.scaleValor = -scale.x;
                //sr.flipX = false;

            }
            if (direccion.x < 0)
            {
                transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
                EnemigoIA.scaleValor = scale.x;
                //sr.flipX = true;
            }
            movimiento = new Vector2(direccion.x, 0);

            EnemigoIA.cambiarScript = false;
            EnemigoIA.activar=true;
            
            
            eAnim.SetFloat("caminar", movimiento.x);
           
        }
        else
        {
            EnemigoIA.cambiarScript = true;
            EnemigoIA.direccion = true;


            movimiento = Vector2.zero;
            direccion= Vector2.zero;
            
        }

        rb.MovePosition(rb.position+movimiento*velocidad*Time.deltaTime);

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }
}
