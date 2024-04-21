using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    // Referencia al prefab del efecto de explosión
    public GameObject explosionPrefab;

    // Tiempo después del cual se destruirá el proyectil
    public float tiempoDestruccion = 5f;

    void Update () {
       
             var rot = transform.rotation;
            rot.x += Time.deltaTime * 30;
            transform.rotation = rot;
        
        }
    // Método que se llama cuando el collider del proyectil colisiona con otro collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto con el que colisionó tiene el tag "Enemigo"
        if (other.CompareTag("Enemigo"))
        {
            // Destruir el enemigo
            Destroy(other.gameObject);

            // Instanciar el efecto de explosión en la posición de la colisión
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Obtener la duración de la animación de la explosión
            Animator explosionAnimator = explosion.GetComponent<Animator>();
            float duracionAnimacion = explosionAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length;

            // Destruir el objeto de la explosión después de que termine la animación
            Destroy(explosion, duracionAnimacion);
        }

        // Destruir el proyectil después de un cierto tiempo
        Destroy(gameObject, tiempoDestruccion);
    }
}
