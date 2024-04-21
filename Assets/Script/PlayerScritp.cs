using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D fisica;
    public SpriteRenderer sprite;

    public GameObject prefabProyectil;
    public float velocidadNormal;
    public float velocidadSprint;
    public int fuerzaSalto;
    public int fuerzaDisparo = 10;
    public AudioClip saltoSfx;
    public AudioClip disparosfx;

    public int vidas;

    private AudioSource audioSource;
    private float velocidadOriginal;
    private float velocidadOriginalRun;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        velocidadOriginal = velocidadNormal;
        velocidadOriginalRun = velocidadSprint;
    }

    private void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadSprint : velocidadNormal;
        fisica.velocity = new Vector2(entradaX * velocidadActual, fisica.velocity.y);
    }

    void Update()
    {
        // Codigo salto
        if (Input.GetKeyDown(KeyCode.Space) && TocarSuelo())
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            audioSource.PlayOneShot(saltoSfx);
        }

        // Cambiar la dirección del sprite
        if (fisica.velocity.x > 0)
            sprite.flipX = false;

        else if (fisica.velocity.x < 0)
            sprite.flipX = true;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            Disparar();
        }
    }

    private bool TocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return toca.collider != null;
    }

    void Disparar()
    {
        // Determinar la dirección del disparo según la escala del jugador
        Vector2 direccionDisparo = sprite.flipX ? Vector2.left : Vector2.right;

        // Obtener la posición actual del jugador
        Vector3 posicionDisparo = transform.position;

        // Ajustar la posición del disparo para que el proyectil no aparezca en el jugador
        posicionDisparo += new Vector3(direccionDisparo.x * 0.5f, 0f, 0f);

        // Instanciar el proyectil en la posición del jugador
        GameObject proyectil = Instantiate(prefabProyectil, posicionDisparo, Quaternion.identity);

        // Obtener el componente Rigidbody2D del proyectil
        Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();

        // Configurar la velocidad del proyectil solo en la dirección horizontal
        rbProyectil.velocity = new Vector2(direccionDisparo.x * fuerzaDisparo, 0f);

        // Desactivar la gravedad del proyectil para que no caiga
        rbProyectil.gravityScale = 0f;
        audioSource.PlayOneShot(disparosfx);
    }

    public void Ralentizar(float factorRalentizacion)
    {
        velocidadNormal *= factorRalentizacion; // Ralentizar multiplicando la velocidad actual por un factor
        velocidadSprint *= factorRalentizacion;
    }

    public void RestaurarVelocidad()
    {
        velocidadNormal = velocidadOriginal; // Ralentizar multiplicando la velocidad actual por un factor
        velocidadSprint = velocidadOriginalRun;
    }

    public void quitarVida()
    {
        vidas--;

    }

}
