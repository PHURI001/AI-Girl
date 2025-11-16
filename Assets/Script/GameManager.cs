using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {

    }
    public static GameManager Instance;
    private int Activity = 0;
    private int day = 1;
    private void Awake()
    {
        Instance = this;
    }
    public void DoActivity()
    {
        Activity += 1;
        Debug.Log("Activity Point: " + Activity);
        Debug.Log("Day: " + day);
    }
    void Update()
    {
        if (Activity == 5)
        {
            day += 1;
            Activity = 0;
        }
    }

    public void setDay()
    {
        //later
    }
}