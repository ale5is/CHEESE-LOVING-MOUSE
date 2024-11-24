using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float impulso,impulsoMinimo,impulsoMaximo;
    private void Start()
    {
        impulsoMinimo=impulso;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                impulso = impulsoMaximo;
            }
            else
            {
                impulso = impulsoMinimo;
            }

            collision.gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2.up*impulso);
        }
    }
}
