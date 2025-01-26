using UnityEngine;
using UnityEngine.Tilemaps;

public class MeteoritoBurbuja : MonoBehaviour
{
    public Tilemap tilemap; // El Tilemap del meteorito
    public GameObject destructionPrefab; // Prefab de animación de destrucción

    void Start()
    {
        
    }
    void Update()
    {
        // Detectar clic izquierdo del mouse (puedes cambiar esto por otro método de ataque)

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePosition = tilemap.WorldToCell(mouseWorldPos); // Convertir la posición del mouse al Tilemap

            // Verificar si hay un Tile en la posición
            if (tilemap.HasTile(tilePosition))
            {
                DestroyTile(tilePosition);
            }
        }
    }
    void DestroyTile(Vector3Int tilePosition)
    {
        // Obtener la posición del centro del Tile
        Vector3 tileCenter = tilemap.GetCellCenterWorld(tilePosition);

        // Instanciar la animación de destrucción
        Instantiate(destructionPrefab, tileCenter, Quaternion.identity);

        // Eliminar el Tile del Tilemap
        tilemap.SetTile(tilePosition, null);
    }
}
