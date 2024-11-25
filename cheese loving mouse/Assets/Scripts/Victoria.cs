using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    //public GameObject CVictoria;
    public Reinicio Reinicio;
    private void Start()
    {
        //CVictoria.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //CVictoria.SetActive(true);
            if (Reinicio.numScene == 1)
            {
                SceneManager.LoadScene(2);
                
            }
            if (Reinicio.numScene == 2)
            {
                SceneManager.LoadScene(3);
                
            }
            if (Reinicio.numScene == 3)
            {
                SceneManager.LoadScene(4);
                
            }

        }
    }
}
