using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad;
    public float salto;
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;
    public bool saltoMejorado;
    public float MuchaFuerza,PocaFuerza;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d")|| Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(velocidad,rb2d.velocity.y);
            sr.flipX = false;
            anim.SetBool("run",true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {

            rb2d.velocity = new Vector2(-velocidad, rb2d.velocity.y);
            sr.flipX = true;
            anim.SetBool("run", true);
        }
        else
        {
            rb2d.velocity=new Vector2(0,rb2d.velocity.y) ;
            anim.SetBool("run", false);
        }

        if (Input.GetKey("space")&& IsGrounded.suelo)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, salto);

        }
        if (IsGrounded.suelo)
        {
            anim.SetBool("jump", false);
        }
        if (!IsGrounded.suelo)
        {
            anim.SetBool("jump", true);
            anim.SetBool("run", false);
        }

        if (saltoMejorado)
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * MuchaFuerza * Time.deltaTime;
            }
            if (rb2d.velocity.y > 0&!Input.GetKey("space"))
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * PocaFuerza * Time.deltaTime;
            }
        }
        
    }
}
