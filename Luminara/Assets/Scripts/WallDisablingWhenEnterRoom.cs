using UnityEngine;

public class WallDisablingWhenEnterRoom : MonoBehaviour
{
    public Grid grid; // assign this in the Inspector or find it in Start()
    public string Walls_deactivatable = "Walls_deactivatable";
    private Transform cachedLayerTransform;

    void Start()
    {
        cachedLayerTransform = grid.transform.Find(Walls_deactivatable);
        if (cachedLayerTransform == null)
            Debug.LogWarning("Layer not found in Start: " + Walls_deactivatable);
    }
    void Update()
    {
        // Example action: press the spacebar to disable the layer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleLayer(Walls_deactivatable);
        }
    }

    void DisableLayer(string Walls_deactivatable)
    {
        Transform layerTransform = grid.transform.Find(Walls_deactivatable);
        if (layerTransform != null)
        {
            layerTransform.gameObject.SetActive(false); // Fully disable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            Debug.LogWarning("Layer not found: " + Walls_deactivatable);
        }
    }
    void EnableLayer(string Walls_deactivatable)
    {
        Transform layerTransform = grid.transform.Find(Walls_deactivatable);
        if (layerTransform != null)
        {
            layerTransform.gameObject.SetActive(true); // Fully enable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = true;
        }
        else
        {
            Debug.LogWarning("Layer not found: " + Walls_deactivatable);
        }
    }

    void ToggleLayer(string Walls_deactivatable)
    {
        
        if (cachedLayerTransform != null)
        {
            bool isActive = cachedLayerTransform.gameObject.activeSelf;
            cachedLayerTransform.gameObject.SetActive(!isActive);
        }
    }
}
