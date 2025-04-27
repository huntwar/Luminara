using UnityEngine;

public class WallDisablingWhenEnterRoom3 : MonoBehaviour
{
    public Grid grid; // assign this in the Inspector or find it in Start()
    public string Walls_deactivatable = "Room3/Room3_Walls_deactivatable";
    public string Doors = "Room3/Room3_Doors";
    //public string ChandelierOutsideLeft = "Room1_ChandelierOutsideLeft";
    //public string ChandelierOutsideRight = "Room1_ChandelierOutsideRight";
    private Transform walls;
    private Transform door;
    //private Transform chandelierLeft;
    //private Transform chandelierRight;

    void Start()
    {
        walls = grid.transform.Find(Walls_deactivatable);
        if (walls == null)
            Debug.LogWarning("Layer not found in Start: " + Walls_deactivatable);
        door = grid.transform.Find(Doors);
        if (door == null)
            Debug.LogWarning("Layer not found in Start: " + Doors);
        /*chandelierLeft = grid.transform.Find(ChandelierOutsideLeft);
        if (chandelierLeft == null)
            Debug.LogWarning("Layer not found in Start: " + ChandelierOutsideLeft);
        chandelierRight = grid.transform.Find(ChandelierOutsideRight);
        if (chandelierRight == null)
            Debug.LogWarning("Layer not found in Start: " + ChandelierOutsideRight);*/
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleLayer(false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleLayer(true);
        }
    }

    void ToggleLayer(bool activeState)
    {
        if (walls != null)
            walls.gameObject.SetActive(activeState);

        if (door != null)
            door.gameObject.SetActive(activeState);

        /*if (chandelierLeft != null)
            chandelierLeft.gameObject.SetActive(activeState);

        if (chandelierRight != null)
            chandelierRight.gameObject.SetActive(activeState);*/
    }
}