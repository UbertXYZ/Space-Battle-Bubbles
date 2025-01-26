using UnityEngine;

public class Alien : MonoBehaviour
{
    private bool EnMoviento = false;
    private Vector3 Objetivo;
    private Vector3 Direccion;
    public float Velocidad = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Objetivo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnMoviento)
        {
            // Capturar entrada del jugador
            Vector3 input = Vector3.zero;
            if (Input.GetAxis("Horizontal") < 0) input += Vector3.left;
            else if (Input.GetAxis("Horizontal") > 0) input += Vector3.right;
            else if (Input.GetAxis("Vertical") < 0) input += Vector3.down;
            else if (Input.GetAxis("Vertical") > 0) input += Vector3.up;
            Debug.Log(input);
            if (input != Vector3.zero)
            {
                Direccion = input;
                Objetivo = transform.position + input; // Calcular posición objetivo
                EnMoviento = true;
            }
        }
        if (EnMoviento)
        {
            Vector3 movimiento = new Vector3(Direccion.x, Direccion.y, 0) * Velocidad * Time.deltaTime;
            transform.position += movimiento / 2;

            // Verificar si el jugador alcanzó la posición objetivo
            if (Vector3.Distance(transform.position, Objetivo) < 0.1f)
            {
                transform.position = Objetivo;
                EnMoviento = false;
            }
        }
    }
}