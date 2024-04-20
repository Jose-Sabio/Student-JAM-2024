using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScritp : MonoBehaviour
{
    private Rigidbody2D fisica;
    private SpriteRenderer sprite;

    public int velocidad;
    public int fuerzaSalto;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad, fisica.velocity.y);
    }

    void Update()
    {
        // Codigo salto
        if (Input.GetKeyDown(KeyCode.Space) && TocarSuelo())
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

        }

        // Cambiar la dirección del sprite
        if (fisica.velocity.x > 0)
            sprite.flipX = false;
        else if (fisica.velocity.x < 0)
            sprite.flipX = true;
    }
    private bool TocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return toca.collider != null;
    }

}
