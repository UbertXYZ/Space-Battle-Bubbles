using UnityEngine;

public class Colision : MonoBehaviour
{
    public float speed = 2f; // Velocidad inicial del cohete
    private float nextSpeedChangeTime = 0f; // Tiempo en el que debe cambiar la velocidad
    public float speedChangeInterval = 2f; // Intervalo de tiempo entre cambios de velocidad

    // Update se llama una vez por frame
    void Update()
    {
        // Cambiar la velocidad de forma aleatoria cada cierto intervalo
        if (Time.time >= nextSpeedChangeTime)
        {
            speed = Random.Range(0f, 1f); // Genera un valor aleatorio entre 0 y 1
            nextSpeedChangeTime = Time.time + speedChangeInterval; // Establece el próximo cambio de velocidad
        }

        // Mueve el cohete hacia arriba con la velocidad actual
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // Detecta la colisión con la burbuja
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el cohete colisiona con un objeto con el tag "Burbuja"
        if (other.CompareTag("Burbuja"))
        {
            Destroy(other.gameObject); // Destruye la burbuja
            Destroy(gameObject); // Destruye el cohete
        }
    }

    // Detecta si el cohete se sale de la pantalla y lo destruye
    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Destruye el cohete cuando se sale de la pantalla
    }
}
