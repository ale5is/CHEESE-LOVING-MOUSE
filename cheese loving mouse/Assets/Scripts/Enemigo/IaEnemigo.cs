using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaEnemigo : MonoBehaviour
{
    public Transform jugador;
    public float radioDeteccion;
    public float velocidad;

    private Rigidbody2D rb;
    private Vector2 movimiento;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaDeJugador = Vector2.Distance(transform.position, jugador.position);

        if(distanciaDeJugador < radioDeteccion)
        {
            Vector2 direccion = (jugador.position - transform.position).normalized;
            movimiento = new Vector2(direccion.x, 0);
        }
        else
        {
            movimiento = Vector2.zero;
        }
        rb.MovePosition(rb.position+movimiento*velocidad*Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }
}
