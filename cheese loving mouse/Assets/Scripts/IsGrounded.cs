using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public static bool suelo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plataforma"))
        {
            collision.tag = "grounded";
            
        }
        if (collision.CompareTag("grounded"))
        {
            suelo = true;
        }
        if (collision.CompareTag("ZonaDa�able"))
        {
            transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * 8);
            collision.GetComponent<Da�oEnemigo>().padre.SetActive(false);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("grounded"))
        {
            suelo = false;
        }
    }
  
}
