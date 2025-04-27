using Luminara.SoundManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);

        SoundManager.PlaySound(SoundType.GameOver);

        Invoke(nameof(ReloadScene), 2f);


    }



    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}