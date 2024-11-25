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
            Vector2 direccionDa�o = new Vector2(transform.position.x, 0);
            collision.gameObject.GetComponent<Movimiento>().recibeDa�o(direccionDa�o, 1);
        }
    }

}
