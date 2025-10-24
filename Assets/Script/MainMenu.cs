using UnityEngine;
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
}
