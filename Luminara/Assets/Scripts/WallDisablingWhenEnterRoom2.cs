using UnityEngine;

public class WallDisablingWhenEnterRoom2 : MonoBehaviour
{
    public Grid grid; // assign this in the Inspector or find it in Start()
    public string Walls_deactivatable = "Room2_Walls_deactivatable";
    public string Doors = "Room2_Doors";
    //public string ChandelierOutsideL = "ChandelierOutsideLeft";
    //public string ChandelierOutsideR = "ChandelierOutsideRight";
    private Transform walls;
    private Transform door;
    //private Transform chandelierLeft;
    //private Transform chandelierRight;
    private bool isActive = true;

    void Start()
    {
        walls = grid.transform.Find(Walls_deactivatable);
        if (walls == null)
            Debug.LogWarning("Layer not found in Start: " + Walls_deactivatable);
        door = grid.transform.Find(Doors);
        if (door == null)
            Debug.LogWarning("Layer not found in Start: " + Doors);
        /*chandelierLeft = grid.transform.Find(ChandelierOutsideL);
        if (chandelierLeft == null)
            Debug.LogWarning("Layer not found in Start: " + ChandelierOutsideL);
        chandelierRight = grid.transform.Find(ChandelierOutsideR);
        if (chandelierRight == null)
            Debug.LogWarning("Layer not found in Start: " + ChandelierOutsideR);*/
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleLayer(Walls_deactivatable, Doors, /*ChandelierOutsideL, ChandelierOutsideR,*/ true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleLayer(Walls_deactivatable, Doors, /*ChandelierOutsideL, ChandelierOutsideR,*/ false);
        }
    }

    void ToggleLayer(string Walls_deactivatable, string Doors, /*string ChandelierOutsideL, string ChandelierOutsideR,*/ bool isActive)
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
        /*Transform ChandelierL = grid.transform.Find(ChandelierOutsideL);
        if (ChandelierOutsideL != null)
        {
            ChandelierL.gameObject.SetActive(!isActive); // Fully disable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            ChandelierL.gameObject.SetActive(isActive);
            Debug.LogWarning("Layer not found: " + ChandelierOutsideL);
        }
        Transform ChandelierR = grid.transform.Find(ChandelierOutsideR);
        if (ChandelierOutsideR != null)
        {
            ChandelierR.gameObject.SetActive(!isActive); // Fully disable
            // Or: layerTransform.GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            ChandelierR.gameObject.SetActive(isActive);
            Debug.LogWarning("Layer not found: " + ChandelierOutsideR);
        }*/
    }
}