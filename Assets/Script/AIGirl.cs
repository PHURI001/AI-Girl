using System;
using UnityEngine;

public enum Moodtype
{
    Angry,
    Confident,
    Flirty,
    Happy,
    Sad
}

public enum Needytype
{
    Hunger,
    Energy,
    Fun,
    Hygiene
}

public enum ProgressType
{
    Cognitive,
    Communication,
    Creative,
    Data,
    Emotional,
    TrustBonding
}

public class AIGirl : MonoBehaviour
{
    // Mood levels
    private int anger;
    public int Anger { get { return anger; } private set { anger = Mathf.Clamp(value, 0, 100); } }
    private int confidence;
    public int Confidence { get { return confidence; } private set { confidence = Mathf.Clamp(value, 0, 100); } }
    private int flirty;
    public int Flirty { get { return flirty; } private set { flirty = Mathf.Clamp(value, 0, 100); } }
    private int happy;
    public int Happy { get { return happy; } private set { happy = Mathf.Clamp(value, 0, 100); } }
    private int sad;
    public int Sad { get { return sad; } private set { sad = Mathf.Clamp(value, 0, 100); } }

    // Needy levels
    private int hunger;
    public int Hunger { get { return hunger; } private set { hunger = Mathf.Clamp(value, 0, 100); } }
    private int energy;
    public int Energy { get { return energy; } private set { energy = Mathf.Clamp(value, 0, 100); } }
    private int fun;
    public int Fun { get { return fun; } private set { fun = Mathf.Clamp(value, 0, 100); } }
    private int hygiene;
    public int Hygiene { get { return hygiene; } private set { hygiene = Mathf.Clamp(value, 0, 100); } }

    // Progress levels
    private int cognitive;
    public int Cognitive { get { return cognitive; } private set { cognitive = Mathf.Clamp(value, 0, 10); } }
    private int communication;
    public int Communication    { get { return communication; } private set { communication = Mathf.Clamp(value, 0, 10); } }
    private int creative;
    public int Creative { get { return creative; } private set { creative = Mathf.Clamp(value, 0, 10); } }
    private int data;
    public int Data { get { return data; } private set { data = Mathf.Clamp(value, 0, 10); } }
    private int emotional;
    public int Emotional { get { return emotional; } private set { emotional = Mathf.Clamp(value, 0, 10); } }
    private int trustBonding;
    public int TrustBonding { get { return trustBonding; } private set { trustBonding = Mathf.Clamp(value, 0, 10); } }
    public void OptionAIHandler(Enum attributeType, int value)
    {
        if (attributeType is Moodtype mood)
        {
            switch (mood)
            {
                case Moodtype.Angry:
                    Anger += value;
                    break;
                case Moodtype.Confident:
                    Confidence += value;
                    break;
                case Moodtype.Flirty:
                    Flirty += value;
                    break;
                case Moodtype.Happy:
                    Happy += value;
                    break;
                case Moodtype.Sad:
                    Sad += value;
                    break;
            }
        }
        else if (attributeType is Needytype needy)
        {
            switch (needy)
            {
                case Needytype.Hunger:
                    Hunger += value;
                    break;
                case Needytype.Energy:
                    Energy += value;
                    break;
                case Needytype.Fun:
                    Fun += value;
                    break;
                case Needytype.Hygiene:
                    Hygiene += value;
                    break;
            }
        }
        else if (attributeType is ProgressType progress)
        {
            switch (progress)
            {
                case ProgressType.Cognitive:
                    Cognitive += value;
                    break;
                case ProgressType.Communication:
                    Communication += value;
                    break;
                case ProgressType.Creative:
                    Creative += value;
                    break;
                case ProgressType.Data:
                    Data += value;
                    break;
                case ProgressType.Emotional:
                    Emotional += value;
                    break;
                case ProgressType.TrustBonding:
                    TrustBonding += value;
                    break;
            }
        }
    }

    void Test()
    {
        Debug.Log("AiGirl Test");
    }
}