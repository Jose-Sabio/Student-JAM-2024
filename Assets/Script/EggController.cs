using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour
{
    public Sprite spriteAlColisionar; // Sprite a cambiar al colisionar con el suelo
    public float velocidadJugadorReducida = 0.5f; // Velocidad reducida del jugador al tocar el objeto
    public float duracionParpadeo = 1f; // Duración del parpadeo

    private bool haColisionado = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") && !haColisionado)
        {
            haColisionado = true;
            CambiarSprite();
            Invoke("ParpadearYDestruir", duracionParpadeo);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            RalentizarJugador();
        }
    }

    private void CambiarSprite()
    {
        if (spriteAlColisionar != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = spriteAlColisionar;
            }
        }
    }

    private void RalentizarJugador()
    {
        Rigidbody2D rbJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        if (rbJugador != null)
        {
            rbJugador.velocity *= velocidadJugadorReducida;
        }
    }

    private void ParpadearYDestruir()
    {
        StartCoroutine(ParpadearYDestruirCoroutine());
    }

    private IEnumerator ParpadearYDestruirCoroutine()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            for (float timer = 0; timer < duracionParpadeo; timer += Time.deltaTime)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                yield return null;
            }
        }

        Destroy(gameObject);
    }
}
