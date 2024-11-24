using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    public GameObject padre;
    void Start()
    {
        padre = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DañarEnemigo"))
        {
            collision.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * 9);
            padre.SetActive(false);
        }
    }
}
