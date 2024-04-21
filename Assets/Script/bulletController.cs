using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 1; // Da�o que causa la bala al jugador
    public AnimationClip animacion; // Animaci�n que se reproducir� al crearse la bala

    private Animator animator;

    private void Awake()
    {
        // Obtener el componente Animator
        animator = GetComponent<Animator>();

        // Reproducir la animaci�n si est� asignada
        if (animator != null && animacion != null)
        {
            animator.Play(animacion.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si la bala colisiona con el jugador, le quita una vida
        if (other.CompareTag("Player"))
        {
            PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            if (player != null)
            {
                player.quitarVida();
                Destroy(gameObject);
            }
        }
        // Si la bala colisiona con otro objeto, se destruye
        else
        {
            Destroy(gameObject);
        }
    }
}
