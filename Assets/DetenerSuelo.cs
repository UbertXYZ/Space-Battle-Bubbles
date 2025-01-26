using UnityEngine;

public class DetenerSuelo : MonoBehaviour
{
    private bool Unavez = true;
    
    private CoheteAtaque coheteAtaque;
    private void Start()
    {
        coheteAtaque = GetComponent<CoheteAtaque>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el colisionador pertenece al suelo del meteoro
        if (other.gameObject.CompareTag("Suelo") && Unavez)
        {
            coheteAtaque.OrdenAterrizar = true;
        }
    }
}
