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
}
