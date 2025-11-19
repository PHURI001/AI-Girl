using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AIGirl aiGirl;
    void Start()
    {

    }
    public static GameManager Instance;
    private int activity = 0;
    private int day = 1;
    private void Awake()
    {
        Instance = this;
    }
    public void DoActivity()
    {
        activity += 1;
        ActivityCheckAndDaySet();
    }
    void Update()
    {
        if (activity == 5)
        {
            day += 1;
            activity = 0;
        }
    }

    public void ActivityCheckAndDaySet()
    {
        if (activity == 5)
        {
            day += 1;
            activity = 0;

        }
        aiGirl.StatsChangePerActivity(activity);
        aiGirl.EventCheck();
    }
}