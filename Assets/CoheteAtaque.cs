using UnityEngine;

public class CoheteAtaque : MonoBehaviour
{
    private float Velocidad = 5f;
    private bool Volando = true;
    public bool OrdenAterrizar = false;
    private Animator animator;
    [SerializeField] public Vector3 Direccion;
    [SerializeField] public float TiempoAterrizaje;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Volando)
        {
            Vector3 movimiento = new Vector3(Direccion.x, Direccion.y, 0) * Velocidad * Time.deltaTime;
            transform.position += movimiento / 2;
        }
        if(OrdenAterrizar)
        {
            Aterrizar();
            TiempoAterrizaje -= Time.deltaTime;
            if (TiempoAterrizaje <= 0)
            {
                Volando = false;
                OrdenAterrizar = false;
            }
        }
    }
    void Aterrizar()
    {
        animator.SetBool("Aterrizar", true);
    }
}
