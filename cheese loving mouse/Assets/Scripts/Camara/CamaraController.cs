using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform objetivo;
    public float velocidadCamaraX, velocidadCamaraY;
    public Vector3 desplazamiento;
    private void Start()
    {
        velocidadCamaraX = 1;
    }
    private void FixedUpdate()
    {
        Vector3 posicionDeseaday = objetivo.position + desplazamiento;
        Vector3 posicionSuavizaday = Vector3.Lerp(transform.position, posicionDeseaday, velocidadCamaraY);
        transform.position = posicionSuavizaday;
    }
    private void LateUpdate()
    {
        Vector3 posicionDeseada = objetivo.position + desplazamiento;
        Vector3 posicionSuavizada=Vector3.Lerp(transform.position, posicionDeseada, velocidadCamaraX);
        transform.position = posicionSuavizada;
    }
}
