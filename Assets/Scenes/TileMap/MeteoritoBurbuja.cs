using UnityEngine;
using UnityEngine.Tilemaps;

public class MeteoritoBurbuja : MonoBehaviour
{
    public Tilemap tilemap; // El Tilemap del meteorito
    public GameObject destructionPrefab; // Prefab de animaci�n de destrucci�n

    void Start()
    {
        
    }
    void Update()
    {
        // Detectar clic izquierdo del mouse (puedes cambiar esto por otro m�todo de ataque)

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePosition = tilemap.WorldToCell(mouseWorldPos); // Convertir la posici�n del mouse al Tilemap

            // Verificar si hay un Tile en la posici�n
            if (tilemap.HasTile(tilePosition))
            {
                DestroyTile(tilePosition);
            }
        }
    }
    void DestroyTile(Vector3Int tilePosition)
    {
        // Obtener la posici�n del centro del Tile
        Vector3 tileCenter = tilemap.GetCellCenterWorld(tilePosition);

        // Instanciar la animaci�n de destrucci�n
        Instantiate(destructionPrefab, tileCenter, Quaternion.identity);

        // Eliminar el Tile del Tilemap
        tilemap.SetTile(tilePosition, null);
    }
}
