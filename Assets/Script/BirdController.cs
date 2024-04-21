using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;
    public GameObject objetoPrefab; // Prefab del objeto a soltar
    public float tiempoEntreSoltados = 1f; // Tiempo entre cada objeto soltado
    private float tiempoUltimoSoltado; // Tiempo del último objeto soltado

    private Vector3 posicionInicio;
    private bool movimientoAFin;

    private void Start()
    {
        posicionInicio = transform.position;
        movimientoAFin = true;
        tiempoUltimoSoltado = Time.time;
    }

    private void Update()
    {
        MoverEnemigo();
        if (Time.time - tiempoUltimoSoltado >= tiempoEntreSoltados)
        {
            Soltar();
            tiempoUltimoSoltado = Time.time;
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

    private void Soltar()
    {
        // Instancia el objeto a soltar
        Vector3 posicionCreacion = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        GameObject objetoSoltado = Instantiate(objetoPrefab, posicionCreacion, Quaternion.identity);

        // Destruye el objeto después de un tiempo (opcional)
        //Destroy(objetoSoltado, 2f); // Cambia el valor de tiempo como desees
    }
}
