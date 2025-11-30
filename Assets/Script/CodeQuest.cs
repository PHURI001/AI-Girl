using System.Collections;
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
    public static bool Worked = false;
    //ui

    public Canvas Home;
    public Canvas Done;

    public List<Canvas> AllQuestCanvas;
    public List <Canvas> Quest1Canvas;
    public List <Canvas> Quest2Canvas;


    public List<GameObject> Quest1;
    public List<GameObject> Quest2;

    void Start()
    {
        if (Worked)
        {
            Home.enabled = false;
            Done.enabled = true;
        }
        player = FindAnyObjectByType<Player>();
        //test
        //QuestPicking(1);

        if (!Worked && due > 0)
        {
            Home.enabled = false;
            AllQuestCanvas[currentQuestion].enabled = true;
            if (currentQuestion == 0)
            {
                Quest1Canvas[allAnswer.Count - due].enabled = true;
            }
            else if (currentQuestion == 1)
            {
                Quest2Canvas[allAnswer.Count - due].enabled = true;
            }
        }
    }

    public void QuestPicking(int choose)
    {
        currentQuestion = choose;
        allAnswer = new Dictionary<string, List<string>>();
        List<string> answers = new List<string>();

        if (choose == 0)
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
            Quest1Canvas[0].enabled = true;
        }
        else if (choose == 1)
        {
            reward = 100;
            due = 1;
            level = DifficultyLevel.Easy;
            answers = new List<string> { "span", "span", "div", "span", "className" };
            allAnswer["quiz1"] = answers;
            answers = new List<string> { "div", "button", "className", "div", "footer"};
            allAnswer["quiz2"] = answers;
            Quest2Canvas[0].enabled = true;
        }


        Home.enabled = false;
        AllQuestCanvas[currentQuestion].enabled = true;
        //Debug.Log(allAnswer["quiz1"][1]);
    }

    [System.Obsolete]
    private IEnumerator checkAnswer()
    {
        int thisQuiz = (allAnswer.Count - due) + 1;
        int findQuest = thisQuiz - 1;
        //allUI[currentQuestion].GetComponent<RectTransform>().FindChild($"Input{i}").GetComponentInChildren<TMP_InputField>().text
        int correctAnswers = 0;
        for (int i = 1; i < 6; i++)
        {
            if (currentQuestion == 0)
            {
                if (Quest1[findQuest].GetComponent<RectTransform>().FindChild($"Input{i}").GetComponentInChildren<TMP_InputField>().text == allAnswer[$"quiz{thisQuiz}"][i - 1])
                {
                    correctAnswers++;
                }
                else
                {
                    mistakes += 1;
                    Quest1[findQuest].GetComponent<RectTransform>().FindChild($"Input{i}").GetComponentInChildren<TMP_InputField>().text = "wrong";
                }
            }
            else if (currentQuestion == 1)
            {
                if (Quest2[findQuest].GetComponent<RectTransform>().FindChild($"Input{i}").GetComponentInChildren<TMP_InputField>().text == allAnswer[$"quiz{thisQuiz}"][i - 1])
                {
                    correctAnswers++;
                }
                else
                {
                    mistakes += 1;
                    Quest1[findQuest].GetComponent<RectTransform>().FindChild($"Input{i}").GetComponentInChildren<TMP_InputField>().text = "wrong";
                }
            }
        }
        Worked = true;
        if (correctAnswers == 5)
        {
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
        else
        {
            yield return new WaitForSeconds(2f);
        }
        GameManager.Instance.DoActivity();
    }

    /*public void Answer(int value)
    {
        int thisQuiz = (allAnswer.Count - due) + 1;
        if (allAnswer[$"quiz{thisQuiz}"][value] == "1")
        {

        }
    }*/

    public void FinishButton()
    {
#pragma warning disable CS0612 // Type or member is obsolete
        StartCoroutine(checkAnswer());
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

    public void EventCheck()
    {
        Worked = false;
    }
}
