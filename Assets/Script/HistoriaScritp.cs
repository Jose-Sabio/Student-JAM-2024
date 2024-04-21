using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoriaScritp : MonoBehaviour
{
     public Sprite newSprite; // Sprite que se asignará después de 10 segundos
    public Sprite terceraimagen; // Tercer sprite que se asignará después de 15 segundos
    
    private float timer = 0f;
    private bool firstSwap = false;
    private bool secondSwap = false;

    void Update()
    {
        // Incrementar el temporizador
        timer += Time.deltaTime;

        // Verificar si han pasado 10 segundos y si el primer sprite no ha sido cambiado aún
        if (timer >= 10f && !firstSwap)
        {
            // Cambiar el primer sprite
            GetComponent<SpriteRenderer>().sprite = newSprite;
            firstSwap = true; // Marcar que el primer sprite ha sido cambiado
        }

        // Verificar si han pasado 15 segundos y si el segundo sprite no ha sido cambiado aún
        if (timer >= 15f && !secondSwap)
        {
            // Cambiar el segundo sprite
            GetComponent<SpriteRenderer>().sprite = terceraimagen;
            secondSwap = true; // Marcar que el segundo sprite ha sido cambiado
        }

         if (timer >= 20f)
        {
            // Cargar la escena "nivel1"
            SceneManager.LoadScene("Nivel1");
        }
    }
}
