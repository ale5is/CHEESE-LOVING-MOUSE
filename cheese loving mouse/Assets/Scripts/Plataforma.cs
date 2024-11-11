using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float esperar,reincio,distanciaX,distanciaY,velocidad;
    PlatformEffector2D effector2D;
    Vector2 inicio, final;
    bool cambiar;
    public Activar activador;
    // Start is called before the first frame update
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
        inicio = transform.position;
        final = inicio + new Vector2(distanciaX, distanciaY);
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.activado)
        {
            if (transform.position.Equals(inicio))
            {
                cambiar=true;
            }
            if (transform.position.Equals(final))
            {
                cambiar = false;
            }
            
            if (cambiar)
            {
                transform.position = Vector2.MoveTowards(transform.position, final, velocidad * Time.deltaTime);
                
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, inicio, velocidad * Time.deltaTime);
            }
        }
            
        
        if (Input.GetKeyUp(KeyCode.DownArrow)||Input.GetKeyUp(KeyCode.S))
        {
            esperar = reincio;
        }
        if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
        {
            if (esperar <= 0)
            {
                effector2D.rotationalOffset = 180f;
                esperar = reincio;
            }
            else
            {
                esperar-=Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector2D.rotationalOffset = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
