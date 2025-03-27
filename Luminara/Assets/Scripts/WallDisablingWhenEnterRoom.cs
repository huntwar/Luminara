using UnityEngine;
public class WallDisablingWhenEnterRoom : MonoBehaviour
{
    public Grid grid; // assign this in the Inspector or find it in Start()
    public string Walls_deactivatable = "Walls_deactivatable";
    public string Doors = "Doors";
    private Transform wallsLayer;
    private Transform doorsLayer;
    private bool isActive = true;



    void Start()
    {
        wallsLayer = grid.transform.Find(Walls_deactivatable);
        if (wallsLayer == null)
            Debug.LogWarning("Layer not found in Start: " + Walls_deactivatable);

        doorsLayer = grid.transform.Find(Doors);
        if (doorsLayer == null)
            Debug.LogWarning("Layer not found in Start: " + Doors);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        // Example action: press the spacebar to disable the layer
        if (other.CompareTag("Player"))
        {
            ToggleLayer(Walls_deactivatable, Doors, isActive);
            isActive = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered entrance");
            ToggleLayer(Walls_deactivatable, Doors, true); // Enable the layers when leaving
            isActive = true;
        }
    }

    void ToggleLayer(string Walls_deactivatable, string Doors, bool isActive)
    {
        Transform layerTransform_Walls = grid.transform.Find(Walls_deactivatable);
        if (layerTransform_Walls != null)
        {
            layerTransform_Walls.gameObject.SetActive(isActive); // Fully disable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            Debug.LogWarning("Layer not found: " + Walls_deactivatable + Doors);
        }

        Transform layerTransform_Doors = grid.transform.Find(Doors);
        if (layerTransform_Doors != null)
        {
            layerTransform_Doors.gameObject.SetActive(isActive);// Fully disable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            Debug.LogWarning("Layer not found: " + Doors);
        }
    }
}
    /*void EnableLayer(string Walls_deactivatable, string Doors)
    {
        Transform layerTransform_Walls = grid.transform.Find(Walls_deactivatable);
        if (layerTransform_Walls != null)
        {
            layerTransform_Walls.gameObject.SetActive(true); // Fully enable
            Debug.Log("isActive" + isActive);
>>>>>>> Stashed changes
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = true;
        }
        else
        {
            Debug.LogWarning("Layer not found: " + Walls_deactivatable);
        }

<<<<<<< Updated upstream
        void ToggleLayer(string Walls_deactivatable, string Doors, bool isActive);
    {
        
        if (cachedLayerTransform != null)
        {
            bool isActive = cachedLayerTransform.gameObject.activeSelf;
            cachedLayerTransform.gameObject.SetActive(!isActive);
=======
        Transform layerTransform_Doors = grid.transform.Find(Doors);
        if (layerTransform_Doors != null)
        {
            layerTransform_Doors.gameObject.SetActive(true); // Fully enable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = true;
        }
        else
        {
            Debug.LogWarning("Layer not found: " + Doors);
>>>>>>> Stashed changes
        }
    }*/



