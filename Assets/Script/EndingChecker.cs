using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingChecker : MonoBehaviour
{
    AIGirl aIGirl;
    
    public TextMeshProUGUI TextOutput;
    public Canvas EndingCanvas;

    bool ended = false;

    public void Start()
    {
        aIGirl = FindAnyObjectByType<AIGirl>();
    }

    public void Checking()
    {
        //Mood Ending
        if (aIGirl.Happy  == 100)
        {
            Active("Ending\nHappy Girl");
        }
        else if (aIGirl.Happy == 0)
        {
            TextOutput.text = "Lose\n(Happy)";
        }

        if (aIGirl.Anger == 100)
        {
            Active("Ending\nGet Mad");
        }
        else if (aIGirl.Anger == 0)
        {
            TextOutput.text = "Lose\n(Anger)";
        }

        if (aIGirl.Sad == 100)
        {
            Active("Ending\nLeave Me Alone");
        }
        else if (aIGirl.Sad == 0)
        {
            TextOutput.text = "Lose\n(Sad)";
        }

        if (aIGirl.Confident == 100)
        {
            Active("Ending\nEgo");
        }
        else if (aIGirl.Confident == 0)
        {
            TextOutput.text = "Lose\n(Confident)";
        }

        if (aIGirl.Flirty == 100)
        {
            Active("Ending\nPervert");
        }
        else if (aIGirl.Flirty == 0)
        {
            TextOutput.text = "Lose\n(Flirty)";
        }

        //Skill Ending
        if (aIGirl.Cognitive == 10)
        {
            Active("Ending\nGenius");
        }

        if (aIGirl.Communication == 10)
        {
            Active("Ending\nBest Friend");
        }

        if (aIGirl.Creative == 10)
        {
            Active("Ending\nDream");
        }

        if (aIGirl.Data == 10)
        {
            Active("Ending\nI Know Everything");
        }

        if (aIGirl.Emotional == 10)
        {
            Active("Ending\nI feel it");
        }

        if (aIGirl.TrustBonding == 10)
        {
            Active("Ending\nI love you");
        }

        //Needy Ending
        if (aIGirl.Hunger == 0)
        {
            Active("Lose\n(Hunger)");
        }

        if (aIGirl.Energy == 0)
        {
            Active("Lose\n(Energy)");
        }

        if (aIGirl.Fun == 0)
        {
            Active("Lose\n(Fun)");
        }

        if (aIGirl.Hygiene == 0)
        {
            Active("Lose\n(Hygiene)");
        }
    }

    public void Checking(float value, string text)
    {
        Active($"You owe {value}$, {text}");
    }

    private void Active(string textOut)
    {
        var allUI = FindObjectsByType<ThisIsUI>(FindObjectsSortMode.None);

        foreach (var ui in allUI)
        {
            Destroy(ui.gameObject);
        }
        TextOutput.text = textOut;
        EndingCanvas.enabled = true;
        ended = true;
    }

    private void Update()
    {
        if (ended)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Game Over");
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
