using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    AIGirl aiGirl;
    void Start()
    {

    }
    public static GameManager Instance;
    private int activity = 0;

    private int day = 1;
    public GameObject DayText;

    private void Awake()
    {
        Instance = this;
    }
    public void DoActivity()
    {
        activity += 1;
        ActivityCheckAndDaySet();
    }

    public void ActivityCheckAndDaySet()
    {
        if (activity == 5)
        {
            day += 1;
            activity = 0;

            DayText.GetComponent<TextMeshProUGUI>().text = "DAY " + day;
        }
        aiGirl.StatsChangePerActivity(activity);
        aiGirl.EventCheck();
    }
}