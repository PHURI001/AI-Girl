using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        /*GameObject Object = new GameObject("AIGirl");
        aiGirl = Object.AddComponent<AIGirl>();*/

        /*Object = new GameObject("Chroma");
        chroma = Object.AddComponent<Chroma>();

        Object = new GameObject("Notflex");
        notflex = Object.AddComponent<Notflex>();*/

        /*aiGirl.OptionAIHandler(Moodtype.Happy, 15550);
        Debug.Log("Happy: " + aiGirl.Happy);*/

        /*chroma.OptionAIHandler(Moodtype.Happy, 15550);
        Debug.Log("Happy: " + aiGirl.Happy);*/

        //check chroma data
        /*foreach (var data in chroma.Data)
        {
            Debug.Log($"{data.name}, {data.type}, {data.value}");
        }*/
    }
    public static GameManager Instance;
    private int ActivityPoint = 0;
    private int day = 1;
    private void Awake()
    {
        Instance = this;
    }
    public void AddActivityPoint()
    {
        ActivityPoint += 1;
        Debug.Log("Activity Point: " + ActivityPoint);
        Debug.Log("Day: " + day);
    }
    void Update()
    {
        if (ActivityPoint == 5)
        {
            day += 1;
            ActivityPoint = 0;
        }
    }

    public void SetDay()
    {
        //later
    }
}