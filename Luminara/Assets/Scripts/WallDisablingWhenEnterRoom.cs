using UnityEngine;

public class WallDisablingWhenEnterRoom : MonoBehaviour
{
    public Grid grid; // assign this in the Inspector or find it in Start()
    public string Walls_deactivatable = "Walls_deactivatable";
    public string Doors = "Doors";
    private Transform walls;
    private Transform door;
    private bool isActive = true;

    void Start()
    {
        walls = grid.transform.Find(Walls_deactivatable);
        if (walls == null)
            Debug.LogWarning("Layer not found in Start: " + Walls_deactivatable);
        door = grid.transform.Find(Doors);
        if (door == null)
            Debug.LogWarning("Layer not found in Start: " + Doors);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleLayer(Walls_deactivatable, Doors, true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleLayer(Walls_deactivatable, Doors, false);
        }
    }

    void ToggleLayer(string Walls_deactivatable, string Doors, bool isActive)
    {
        Transform Walls = grid.transform.Find(Walls_deactivatable);
        if (Walls != null)
        {
            Walls.gameObject.SetActive(!isActive); // Fully disable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            Walls.gameObject.SetActive(isActive);
            Debug.LogWarning("Layer not found: " + Walls_deactivatable);
        }

        Transform Door = grid.transform.Find(Doors);
        if (Doors != null)
        {
            Door.gameObject.SetActive(!isActive); // Fully disable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            Door.gameObject.SetActive(isActive);
            Debug.LogWarning("Layer not found: " + Doors);
        }
    }
}