using JetBrains.Annotations;
using UnityEngine;

public class WallDisablingWhenEnterRoom : MonoBehaviour
{
    public Grid grid; // assign this in the Inspector or find it in Start()
    public string Walls_deactivatable = "Walls_deactivatable";
    public string Doors = "Doors";
    private Transform wallsLayer;
    private Transform doorsLayer;

    void Start()
    {
        wallsLayer = grid.transform.Find(Walls_deactivatable);
        if (wallsLayer == null)
            Debug.LogWarning("Layer not found in Start: " + Doors);
        doorsLayer = grid.transform.Find(Doors);
        if (doorsLayer == null)
            Debug.LogWarning("Layer not found in Start: " + Walls_deactivatable);
    }
    void Update()
    {
        // Example action: press the spacebar to disable the layer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleLayer(Walls_deactivatable, Doors);
        }
    }

    void DisableLayer(string Walls_deactivatable, string Doors)
    {
        Transform layerTransform_Walls = grid.transform.Find(Walls_deactivatable);
        Transform layerTransform_Doors = grid.transform.Find(Doors);
        if (layerTransform_Walls && layerTransform_Doors != null)
        {
            layerTransform_Walls.gameObject.SetActive(false);
            layerTransform_Doors.gameObject.SetActive(false);// Fully disable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            Debug.LogWarning("Layer not found: " + Walls_deactivatable + Doors);
        }
    }
    void EnableLayer(string Walls_deactivatable, string Doors)
    {
        Transform layerTransform_Walls = grid.transform.Find(Walls_deactivatable);
        Transform layerTransform_Doors = grid.transform.Find(Doors);
        if (layerTransform_Walls && layerTransform_Doors != null)
        {
            layerTransform_Walls.gameObject.SetActive(true);
            layerTransform_Doors.gameObject.SetActive(true); // Fully enable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = true;
        }
        else
        {
            Debug.LogWarning("Layer not found: " + Walls_deactivatable);
        }
    }

    void ToggleLayer(string Walls_deactivatable, string Doors)
    {
        
        if (Walls_deactivatable != null)
        {
            bool isActive = wallsLayer.gameObject.activeSelf;
            wallsLayer.gameObject.SetActive(!isActive);
        }
        if (Doors != null)
        {
            bool isActive = doorsLayer.gameObject.activeSelf;
            doorsLayer.gameObject.SetActive(!isActive);
        }
    }
}
