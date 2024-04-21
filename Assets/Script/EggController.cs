using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour
{
    public Sprite spriteAlColisionar; // Sprite a cambiar al colisionar con el suelo
    public float velocidadJugadorReducida = 0.5f; // Velocidad reducida del jugador al tocar el objeto
    public float duracionParpadeo = 1f; // Duración del parpadeo


    private PlayerScript playerScript;
    private bool haColisionado = false;
    private Rigidbody2D rb2D;
    private Collider2D eggCollider;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        eggCollider = GetComponent<Collider2D>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") && !haColisionado)
        {
            haColisionado = true;
            CambiarSprite();
            ParpadearYDestruir();

            // Desactivar gravedad y convertir el collider en trigger
            rb2D.gravityScale = 0f;
            eggCollider.isTrigger = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.quitarVida();
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            RalentizarJugador();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerScript != null)
            {
                playerScript.RestaurarVelocidad(); // Restaurar la velocidad original del jugador
            }
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
        if (playerScript != null)
        {
            playerScript.Ralentizar(velocidadJugadorReducida); // Ralentizar al jugador a la mitad de su velocidad
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
