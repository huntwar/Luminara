using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E; // Default pickup key

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Haunted Castle");
    }

    public void Settings()
    {

    }

    public void PersonalizeKey()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                Debug.Log($"new key set: {keyCode}");
                pickupKey = keyCode;
                break;
            }
        }
    }

}

/* Volume settings
 * Pause game
 * Personalize Keys
 */
