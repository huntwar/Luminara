using UnityEngine;
using UnityEngine.SceneManagement;
using Luminara.SoundManager;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);

        SoundManager.PlaySound(SoundType.GameOver);

        StartCoroutine(WaitAndReload());
    }

    private System.Collections.IEnumerator WaitAndReload()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}