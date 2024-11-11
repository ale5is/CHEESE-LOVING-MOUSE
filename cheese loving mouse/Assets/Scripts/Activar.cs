using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite sprite1,sprite2;
    public bool activado;
    // Update is called once per frame
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite1 = sprite.sprite;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Movimiento.activar)
            {
                sprite.sprite = sprite2;
                activado=true;
            }
            else
            {
                sprite.sprite = sprite1;
            }
        }
    }
}