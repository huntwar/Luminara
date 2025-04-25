using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Haunted Castle");
    }

}

/* Volume settings
 * Pause game
 * Personalize Keys
 */
