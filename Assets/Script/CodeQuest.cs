using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum DifficultyLevel
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}

public class CodeQuest : Application
{
    Player player;
    static int reward = 0;
    static int due;
    static int mistakes;
    static int currentQuestion;
    static DifficultyLevel level;

    static Dictionary<string, List<string>> allAnswer;

    static int totalReward;

    //ui
    public List<GameObject> allUI; // 0 = Home, 1-6 = quests

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        //test
        //QuestPicking(1);

        if (due == 0)
        {
            //???
        }
        else
        {
            allUI[0].GetComponent<Canvas>().enabled = false;
            allUI[currentQuestion].GetComponent<Canvas>().enabled = true;
        }
    }

    public void QuestPicking(int choose)
    {
        currentQuestion = choose;
        allAnswer = new Dictionary<string, List<string>>();
        List<string> answers = new List<string>();

        if (choose == 1)
        {
            reward = 120;
            due = 3;
            level = DifficultyLevel.Easy;
            answers = new List<string> { "header", "h1", "p", "className", "className" };
            allAnswer["quiz1"] = answers;
            answers = new List<string> { "option", "option", "div", "h3", "div" };
            allAnswer["quiz2"] = answers;
            answers = new List<string> { "div", "p", "span", "article", "h2" };
            allAnswer["quiz3"] = answers;
        }
        else if (choose == 2)
        {
            reward = 100;
            due = 1;
            level = DifficultyLevel.Easy;
            answers = new List<string> { "span", "span", "div", "span", "className" };
            allAnswer["quiz1"] = answers;
            answers = new List<string> { "div", "button", "className", "div", "footer"};
            allAnswer["quiz2"] = answers;
        }


        allUI[0].GetComponent<Canvas>().enabled = false;
        allUI[currentQuestion].GetComponent<Canvas>().enabled = true;
        //Debug.Log(allAnswer["quiz1"][1]);
    }

    [System.Obsolete]
    private void checkAnswer()
    {
        //allUI[currentQuestion].GetComponent<RectTransform>().FindChild($"Input{i}").GetComponentInChildren<TMP_InputField>().text
        int thisQuiz = (allAnswer.Count - due) + 1;
        int correctAnswers = 0;
        for (int i = 1; i < 6; i++)
        {
            if (allUI[currentQuestion].GetComponent<RectTransform>().FindChild($"Input{i}").GetComponentInChildren<TMP_InputField>().text == allAnswer[$"quiz{thisQuiz}"][i-1])
            {
                //Debug.Log($"Correct");
                correctAnswers += 1;
            }
            else
            {
                //Debug.Log($"Wrong");
                mistakes += 1;
                allUI[currentQuestion].GetComponent<RectTransform>().FindChild($"Input{i}").GetComponentInChildren<TMP_InputField>().text = "";
            }
        }
        if (correctAnswers == 5)
        {
            GameManager.Instance.DoActivity();
            due -= 1;
            if (due == 0)
            {
                payOut();
                base.DeleteWindow();
            }
            else
            {
                base.DeleteWindow();
            }
        }
    }

    public void EnterAnswer()
    {
#pragma warning disable CS0612 // Type or member is obsolete
        checkAnswer();
#pragma warning restore CS0612 // Type or member is obsolete
    }

    private void payOut()
    {

        if (mistakes > 0)
        {
            totalReward = reward - (reward / ((allAnswer.Count * 5 * (int)level) * mistakes));
        }
        else { totalReward = reward; }
        player.ChangeMoney(totalReward, "");
    }
}
