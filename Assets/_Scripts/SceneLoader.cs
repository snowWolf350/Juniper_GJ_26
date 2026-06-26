using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
