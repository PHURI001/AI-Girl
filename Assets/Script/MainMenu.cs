using UnityEditor;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void CreditButton()
    {
        SceneManager.LoadScene("Credit");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        UnityEngine.Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
