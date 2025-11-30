using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingChecker : MonoBehaviour
{
    AIGirl aIGirl;
    
    public TextMeshProUGUI TextOutput;
    public TextMeshProUGUI Description;
    public Canvas EndingCanvas;

    public void Start()
    {
        aIGirl = FindAnyObjectByType<AIGirl>();
    }

    public void Checking()
    {
        //Mood Ending
        if (aIGirl.Happy  == 100)
        {
            Active("Ending : Happy Girl.", "YOU REACH MAX HAPPY");
        }
        else if (aIGirl.Happy == 0)
        {
            Active("Game Over", "Happy is at 0");
        }

        if (aIGirl.Anger == 100)
        {
            Active("Ending : Get Mad.", "YOU REACH MAX ANGRY");
        }
        else if (aIGirl.Anger == 0)
        {
            Active("Game Over", "Angry is at 0");
        }

        if (aIGirl.Sad == 100)
        {
            Active("Ending : Leave Me Alon.", "YOU REACH MAX SAD");
        }
        else if (aIGirl.Sad == 0)
        {
            Active("Game Over", "Sad is at 0");
        }

        if (aIGirl.Confident == 100)
        {
            Active("Ending : Ego.", "YOU REACH MAX CONFIDENT");
        }
        else if (aIGirl.Confident == 0)
        {
            Active("Game Over", "Confident is at 0");
        }

        if (aIGirl.Flirty == 100)
        {
            Active("Ending : Pervert.", "YOU REACH MAX FLIRTY");
        }
        else if (aIGirl.Flirty == 0)
        {
            Active("Game Over", "Flirty is at 0");
        }

        //Skill Ending
        if (aIGirl.Cognitive == 10)
        {
            Active("Ending : Genius.", "YOU REACH COGNITIVE LEVEL 10");
        }

        if (aIGirl.Communication == 10)
        {
            Active("Ending : Best Friend.", "YOU REACH COMMUNICATION LEVEL 10");
        }

        if (aIGirl.Creative == 10)
        {
            Active("Ending : Dream.", "YOU REACH CREATIVE LEVEL 10");
        }

        if (aIGirl.Data == 10)
        {
            Active("Ending : I Know Everything.", "YOU REACH DATA LEVEL 10");
        }

        if (aIGirl.Emotional == 10)
        {
            Active("Ending : I Feel It.", "YOU REACH EMOTIONAL LEVEL 10");
        }

        if (aIGirl.TrustBonding == 10)
        {
            Active("Ending : I Love You.", "YOU REACH TRUST BONDING LEVEL 10");
        }

        //Needy Ending
        if (aIGirl.Hunger == 0)
        {
            Active("Game Over", "Starving");
        }

        if (aIGirl.Energy == 0)
        {
            Active("Game Over", "Low battery");
        }

        if (aIGirl.Fun == 0)
        {
            Active("Game Over", "No More Fun");
        }

        if (aIGirl.Hygiene == 0)
        {
            Active("Game Over", "Hygiene is at 0");
        }
    }

    public void Checking(float value, string text)
    {
        Active($"You owe {value}$, {text}", "Poor Guy");
    }

    private void Active(string textOut, string des)
    {
        var allUI = FindObjectsByType<ThisIsUI>(FindObjectsSortMode.None);

        foreach (var ui in allUI)
        {
            Destroy(ui.gameObject);
        }
        TextOutput.text = textOut;
        Description.text = des;
        EndingCanvas.enabled = true;
    }
}
