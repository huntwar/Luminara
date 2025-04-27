using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public TMP_InputField myPickUpKey;


    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
