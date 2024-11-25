using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpJugador : MonoBehaviour
{
    public int hp;
    public float invulnerable,reinicio;
    public bool golpeado;
    public Camera cam;
    public bool escondido;
    public GameObject Derrota,hp1,hp2,hp3,Victoria;
    private void Start()
    {
        golpeado = false;
        reinicio = invulnerable;
        Derrota.SetActive(false);
        Victoria.SetActive(false);
    }
    private void Update()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            cam.transform.SetParent(null);
            Derrota.SetActive(true);
            hp1.SetActive(false);
            hp2.SetActive(false);
            hp3.SetActive(false);
        }
        if (hp == 3)
        {
            hp1.SetActive(true);
            hp2.SetActive(true);
            hp3.SetActive(true);
        }
        if (hp == 2 )
        {
            hp1.SetActive(false);
            hp2.SetActive(true);
            hp3.SetActive(true);
        }
        if (hp == 1)
        {
            hp1.SetActive(false);
            hp2.SetActive(false);
            hp3.SetActive(true);
        }
        
        if (golpeado)
        {
            if (invulnerable <= 0)
            {
                invulnerable = reinicio;
                golpeado = false;
            }
            else
            {
                invulnerable -= Time.deltaTime;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Escondite"))
        {
            gameObject.layer = 8;
            escondido = true;
            
        }
        if (collision.CompareTag("Queso"))
        {
            Victoria.SetActive(true);
            gameObject.SetActive(false);
            cam.transform.SetParent(null);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Escondite"))
        {
            gameObject.layer = 8;
            escondido = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Escondite"))
        {
            escondido = false;
            gameObject.layer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") && !escondido)
        {
            if (invulnerable == reinicio & !golpeado)
            {
            golpeado = true;
            hp = hp - 2;
            }
        }

        if (collision.gameObject.CompareTag("EnemigoAplastable"))
        {
            if (invulnerable == reinicio & !golpeado)
            {
                golpeado = true;
                hp--;
            }
        }
        if (collision.gameObject.CompareTag("pinchos"))
        {
            if (invulnerable == reinicio & !golpeado)
            {
                golpeado = true;
                hp-=2;
            }
        }
    }
}
