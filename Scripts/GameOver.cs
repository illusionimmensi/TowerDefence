
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    public string menuSceneName;

    public SceneFader sceneFader;

    public static bool gameOver = true;

    public void Retry ()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu ()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    
}
