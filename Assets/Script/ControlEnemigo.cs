using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;

    private Vector3 posicionInicio;
    private bool movimientoAFin;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicio = transform.position;
        movimientoAFin = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
        


    }

    private void MoverEnemigo()
    {
        Vector3 posicionDestino = (movimientoAFin) ? posicionFin : posicionInicio;

        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);
        if (transform.position == posicionFin)
            movimientoAFin = false;
        if (transform.position == posicionInicio)
            movimientoAFin = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerScript>().QuitarVida();
        }
    }

}
