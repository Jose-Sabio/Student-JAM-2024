using UnityEngine;

public class MarcianController : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;
    public GameObject balaPrefab; // Prefab de la bala
    public float tiempoEntreDisparos = 1f; // Tiempo entre cada disparo
    public Transform direccionDisparo; // Dirección del disparo
    public float distanciaMinimaParaDisparar = 5f; // Distancia mínima para disparar al jugador
    private float tiempoUltimoDisparo; // Tiempo del último disparo

    private Vector3 posicionInicio;
    private bool movimientoAFin;

    private Transform jugador; // Referencia al jugador

    void Start()
    {
        posicionInicio = transform.position;
        movimientoAFin = true;
        tiempoUltimoDisparo = Time.time;

        // Busca al jugador al inicio
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoverEnemigo();

        // Dispara solo si el jugador está a una distancia mínima
        if (Vector3.Distance(transform.position, jugador.position) <= distanciaMinimaParaDisparar)
        {
            if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos)
            {
                Disparar();
                tiempoUltimoDisparo = Time.time;
            }
        }
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

    private void Disparar()
    {
        // Instancia la bala
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);

        // Obtiene la dirección del disparo
        Vector2 direccion = (direccionDisparo.position - transform.position).normalized;

        // Calcula el ángulo de disparo
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Aplica rotación al proyectil
        bala.transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);

        // Aplica fuerza a la bala en la dirección del disparo
        bala.GetComponent<Rigidbody2D>().velocity = direccion * 10f; // Ajusta la velocidad como desees

        // Destruye la bala después de un tiempo
        Destroy(bala, 2f); // Cambia el valor de tiempo como desees
    }
}
