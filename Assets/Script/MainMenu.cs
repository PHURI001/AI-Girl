using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGameButton()
    {
        SceneManager.LoadScene("InGame");
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

    public Canvas MainCanvas;
    public Canvas SaveCanvas;
    public Canvas EnterNameCanvas;
    public Canvas CreditCanvas;
    
    public void MainToSave()
    {
        SaveCanvas.enabled = true;
        MainCanvas.enabled = false;
    }
    public void MainToCredit()
    {
        CreditCanvas.enabled = true;
        MainCanvas.enabled = false;
    }
    public void GoToMainInFirstScene()
    {
        MainCanvas.enabled = true;
        SaveCanvas.enabled = false;
    }

    public void SaveToEnterName()
    {
        EnterNameCanvas.enabled = true;
        SaveCanvas.enabled = false;
    }

    public TMP_InputField EnterNameInput;
    public void EnteringName()
    {
        if (EnterNameInput.text != "" &&  EnterNameInput.text != null)
        {
            PlayGameButton();
        }
    }
}
