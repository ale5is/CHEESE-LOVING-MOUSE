using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacio : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HpJugador>().hp = 0;
        }
    }
}
