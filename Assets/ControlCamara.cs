using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 5f;
    public float desplazamientoY = 1f;

    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Calcula la posición a la que debe ir la cámara (conservando su Z en -10)
            Vector3 posicionDeseada = new Vector3(
                objetivo.position.x, 
                objetivo.position.y + desplazamientoY, 
                transform.position.z
            );

            // Mueve la cámara suavemente desde donde está hacia la posición deseada
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);
        }
    }
}