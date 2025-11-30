using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    AIGirl aiGirl;
    public Airi Airi;
    public GameObject ChatObj;
    EndingChecker endingChecker;
    public GameObject NextDayCanvas;
    Player player;
    public CodeQuest CodeQuest;

    public static GameManager Instance;
    private int activity = 0;

    private int day = 1;
    public TextMeshProUGUI DayText;
    public TextMeshProUGUI TimeText;

    [Header("For Next Day UI")]
    public List<Image> ArrowImage;
    public List<TextMeshProUGUI> SkipDayUIText;
    public List<Image> SkipDayUILine;


    private void Awake()
    {
        Instance = this;
        //test chat
        //Instantiate(ChatObj);

        //Music.Play();
    }
    private void Start()
    {
        aiGirl = FindAnyObjectByType<AIGirl>();
        endingChecker = FindAnyObjectByType<EndingChecker>();
        player = FindAnyObjectByType<Player>();
    }

    public void DoActivity()
    {
        activity += 1;
        ActivityCheckAndDaySet();
    }

    bool nextAct = true;
    public void ActivityCheckAndDaySet()
    {
        var allUI = FindObjectsByType<ThisIsUI>(FindObjectsSortMode.None);
        foreach (var ui in allUI)
        {
            Destroy(ui.gameObject);
        }
        NextDayCanvas.GetComponent<Canvas>().enabled = true;
        nextAct = true;

        for (int i = 0; i < ArrowImage.Count; i++)
        {
            ArrowImage[i].enabled = false;
            if (activity == i)
            {
                ArrowImage[i].enabled = true;
            }
            else if ( activity == 5)
            {
                ArrowImage[0].enabled = true;
            }
        }

        if (activity == 1)
        {
            TimeText.text = "09:00:00 AM";
        }
        else if (activity == 2)
        {
            TimeText.text = "12:00:00 PM";
        }
        else if (activity == 3)
        {
            TimeText.text = "06:00:00 PM";
        }
        else if (activity == 4)
        {
            TimeText.text = "12:00:00 AM";
        }

        if (activity == 5)
        {
            day += 1;
            activity = 0;
            DayText.text = "DAY " + day;
            TimeText.text = "06:00:00 AM";
            //NextDayText.text = DayText.text;
            Airi.Event(day);
            CodeQuest.EventCheck();

            SkipDayUIText[0].text = $"Day {day - 2}";
            SkipDayUIText[1].text = $"Day {day - 1}";
            SkipDayUIText[2].text = $"Day {day}";
            SkipDayUIText[3].text = $"Day {day + 1}";
            SkipDayUIText[4].text = $"Day {day + 2}";

            if (day == 2)
            {
                SkipDayUILine[0].enabled = false;
                SkipDayUILine[1].enabled = true;
                SkipDayUIText[1].enabled = true;
            }
            else if (day == 3)
            {
                SkipDayUILine[1].enabled = false;
                SkipDayUILine[2].enabled = true;
                SkipDayUIText[0].enabled = true;
            }
        }
        aiGirl.StatsChangePerActivity(activity);
        endingChecker.Checking();
    }

    public void Update()
    {
        if (nextAct)
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextDayCanvas.GetComponent<Canvas>().enabled = false;
                nextAct = false;
                if (activity == 0) 
                {
                    Instantiate(ChatObj); 
                }
            }
        }
    }
}