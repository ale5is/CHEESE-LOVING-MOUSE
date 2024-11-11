using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    public GameObject CVictoria;
    private void Start()
    {
        CVictoria.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CVictoria.SetActive(true);
        }
    }
}
