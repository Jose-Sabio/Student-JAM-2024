using UnityEngine;

public class EfectoParallax : MonoBehaviour
{
    public float efectoParallax;
    private Transform camara;
    private Vector3 ultimaPosicionCamara;

    void Start()
    {
        camara = Camera.main.transform;
        ultimaPosicionCamara = camara.position;
    }

    private void LateUpdate()
    {
        Vector3 desplazamientoCamara = camara.position - ultimaPosicionCamara;
        Vector3 nuevaPosicion = transform.position + new Vector3(desplazamientoCamara.x * efectoParallax, 0, 0);
        transform.position = nuevaPosicion;
        ultimaPosicionCamara = camara.position;
    }
}
