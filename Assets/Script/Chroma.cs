using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Chroma : Layer2
{
    public List<OptionData> Data = new List<OptionData>();

    void Awake()
    {
        SaveData();
    }

    void SetUp(String name, Enum type, int value)
    {
        Data.Add(new OptionData(name, type, value));
    }

    void SaveData()
    {
        // Creative
        SetUp("art", ProgressType.Creative, 1);
        SetUp("idea", ProgressType.Creative, 1);
        SetUp("imagine", ProgressType.Creative, 1);
        SetUp("inspire", ProgressType.Creative, 1);
        SetUp("color", ProgressType.Creative, 1);
        SetUp("compose", ProgressType.Creative, 1);
        SetUp("fantasy", ProgressType.Creative, 1);
        SetUp("shape", ProgressType.Creative, 1);

        // Communicate
        SetUp("care", ProgressType.Communication, 1);
        SetUp("comfort", ProgressType.Communication, 1);
        SetUp("discuss", ProgressType.Communication, 1);
        SetUp("describe", ProgressType.Communication, 1);
        SetUp("empathize", ProgressType.Communication, 1);
        SetUp("express", ProgressType.Communication, 1);
        SetUp("mimic", ProgressType.Communication, 1);
        SetUp("share", ProgressType.Communication, 1);

        // Cognitive
        SetUp("analyze", ProgressType.Cognitive, 1);
        SetUp("arrange", ProgressType.Cognitive, 1);
        SetUp("AI", ProgressType.Cognitive, 1);
        SetUp("brain", ProgressType.Cognitive, 1);
        SetUp("calculate", ProgressType.Cognitive, 1);
        SetUp("estimate", ProgressType.Cognitive, 1);
        SetUp("data", ProgressType.Cognitive, 1);
        SetUp("logic", ProgressType.Cognitive, 1);
        SetUp("plan", ProgressType.Cognitive, 1);

        // Emotion
        SetUp("dead", ProgressType.Emotional, 1);
        SetUp("faith", ProgressType.Emotional, 1);
        SetUp("hug", ProgressType.Emotional, 1);
        SetUp("hope", ProgressType.Emotional, 1);
        SetUp("help", ProgressType.Emotional, 1);
        SetUp("love", ProgressType.Emotional, 1);
        SetUp("loyal", ProgressType.Emotional, 1);
        SetUp("respect", ProgressType.Emotional, 1);
        SetUp("trust", ProgressType.Emotional, 1);
    }
}