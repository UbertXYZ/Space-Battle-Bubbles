using UnityEngine;

public class TiempodeVida : MonoBehaviour
{
    [SerializeField]
    public float TiempoVida = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, TiempoVida);
    }
}
