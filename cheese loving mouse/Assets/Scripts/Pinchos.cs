using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pinchos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direccionDaño = new Vector2(transform.position.x, 0);
            collision.gameObject.GetComponent<Movimiento>().recibeDaño(direccionDaño, 1);
        }
    }

}
