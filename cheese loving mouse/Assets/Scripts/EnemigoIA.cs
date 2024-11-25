using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemigoIA : MonoBehaviour
{
    public float distanciaX, distanciaY, velocidad;
    SpriteRenderer sprite;
    Vector2 inicio, final;
    public bool direccion,activar;
    public bool cambiar;
    public bool cambiarScript;
    public bool direSprite;
    Animator eAnim;
    Vector3 scale;
    public float scaleValor;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        inicio = transform.position;
        final = inicio + new Vector2(distanciaX, distanciaY);
        direccion=false;
        eAnim = GetComponent<Animator>();
        scale= transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if(cambiarScript)
        {
            eAnim.SetFloat("caminar", 1);
            float distanciaDerecha = Vector2.Distance(transform.position, inicio);
            float distanciaIzquierda = Vector2.Distance(transform.position, final);

            float distanciaDireccion = distanciaDerecha - distanciaIzquierda;
            if (transform.position.Equals(inicio))
            {
                cambiar = true;
                scaleValor = scale.x;
            }
            if (transform.position.Equals(final))
            {
                cambiar = false;
                scaleValor = -scale.x;
            }

            if (scale.x == scaleValor)
            {
                cambiar = true;
            }
            else
            {
                cambiar = false;
            }

            if (cambiar)
            {
                transform.position = Vector2.MoveTowards(transform.position, final, velocidad * Time.deltaTime);
                transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
                
                //sprite.flipX = true;
            }
            else
            {
                transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                transform.position = Vector2.MoveTowards(transform.position, inicio, velocidad * Time.deltaTime);
                
                //sprite.flipX = false;
            }
        }
        
    }

    void cambiarD()
    {
        activar = false;
        direccion = false;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direccionDaño = new Vector2(transform.position.x, 0);
            collision.gameObject.GetComponent<Movimiento>().recibeDaño(direccionDaño, 1);
        }
    }
}
