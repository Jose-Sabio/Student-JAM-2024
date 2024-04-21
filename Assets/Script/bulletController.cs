using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 1; // Daño que causa la bala al jugador

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
