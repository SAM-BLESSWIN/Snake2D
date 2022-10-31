using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager 
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadFreeRoam()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadBoundary()
    {
        SceneManager.LoadScene(2);
    }

    public static void LoadCoop()
    {
        SceneManager.LoadScene(3);
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
