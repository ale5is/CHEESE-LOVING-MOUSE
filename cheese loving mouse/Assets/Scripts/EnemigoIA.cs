using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    public float distanciaX, distanciaY, velocidad;
    SpriteRenderer sprite;
    Vector2 inicio, final;
    bool cambiar;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        inicio = transform.position;
        final = inicio + new Vector2(distanciaX, distanciaY);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.Equals(inicio))
        {
            cambiar = true;
        }
        if (transform.position.Equals(final))
        {
            cambiar = false;
        }

        if (cambiar)
        {
            transform.position = Vector2.MoveTowards(transform.position, final, velocidad * Time.deltaTime);
            sprite.flipX = true;

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, inicio, velocidad * Time.deltaTime);
            sprite.flipX = false;
        }
    }
}
