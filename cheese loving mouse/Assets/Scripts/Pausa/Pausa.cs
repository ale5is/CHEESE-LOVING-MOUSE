using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject menuPausa;
    public bool pausado;
    void Start()
    {
        pausado=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(pausado)
            {
                reanudar();
            }
            else
            {
                pausar();
            }
        }
    }
    void reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        pausado = false;
    }
    void pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        pausado = true;
    }
}
