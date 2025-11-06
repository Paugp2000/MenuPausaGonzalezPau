using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaMovement : MonoBehaviour
{
    Rigidbody rb;
    enum direccionMovimientoPelota { IZQUIERDA, DERECHA, ABAJO, ARRIBA}
    direccionMovimientoPelota estado;
    public float speed;
    public float changeDirectionTime;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        estado = direccionMovimientoPelota.IZQUIERDA;
        StartCoroutine("Comprovar");
       
    }
    IEnumerator Comprovar()
    { 
        yield return new WaitForSeconds(changeDirectionTime);
        comprovarEstado();
    }
    void cambioDeEstado(direccionMovimientoPelota nuevoEstado)
    {
        if (nuevoEstado != estado)
        {
            estado = nuevoEstado;
            StartCoroutine("Comprovar");
        }
    }
    public void comprovarEstado()
    {
        switch (estado)
        {
            case direccionMovimientoPelota.IZQUIERDA:
                rb.velocity = new Vector3(-1, 0, 0) * speed;
                cambioDeEstado(direccionMovimientoPelota.ARRIBA);
                Debug.Log(estado);
                break;
            case direccionMovimientoPelota.ARRIBA:
                rb.velocity = new Vector3(0, 0, 1) * speed;
                cambioDeEstado(direccionMovimientoPelota.DERECHA);
                Debug.Log(estado);
                break;
            case direccionMovimientoPelota.DERECHA:
                rb.velocity = new Vector3(1, 0, 0) * speed;
                cambioDeEstado(direccionMovimientoPelota.ABAJO);
                Debug.Log(estado);
                break;
            case direccionMovimientoPelota.ABAJO:
                rb.velocity = new Vector3(0, 0, -1) * speed;
                cambioDeEstado(direccionMovimientoPelota.IZQUIERDA);
                Debug.Log(estado);
                break;
        }
    }

}
