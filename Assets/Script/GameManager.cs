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

    public static GameManager Instance;
    private int activity = 0;

    private int day = 1;
    public GameObject DayText;

    private void Awake()
    {
        Instance = this;
        //test chat
        Instantiate(ChatObj);


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

    bool nextDay = false;
    public void ActivityCheckAndDaySet()
    {
        if (activity == 5)
        {
            var allUI = FindObjectsByType<ThisIsUI>(FindObjectsSortMode.None);

            foreach (var ui in allUI)
            {
                Destroy(ui.gameObject);
            }

            NextDayCanvas.GetComponent<Canvas>().enabled = true;
            nextDay = true;

            day += 1;
            activity = 0;
            DayText.GetComponent<TextMeshProUGUI>().text = "DAY " + day;

            Airi.Event(day);
        }
        aiGirl.StatsChangePerActivity(activity);
        aiGirl.EventCheck();
        endingChecker.Checking();
    }

    public void Update()
    {
        if (nextDay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextDayCanvas.GetComponent<Canvas>().enabled = false;
                nextDay = false;
                Instantiate(ChatObj);
            }
        }
    }
}