using System;
using UnityEngine;

public enum MoodType
{
    Angry,
    Confident,
    Flirty,
    Happy,
    Sad
}

public enum NeedyType
{
    Fun,
    Hunger,
    Energy,
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
    private int confident;
    public int Confident { get { return confident; } private set { confident = Mathf.Clamp(value, 0, 100); } }
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
    public void AiChangeStats(Enum attributeType, int value)
    {
        if (attributeType is MoodType mood)
        {
            switch (mood)
            {
                case MoodType.Angry:
                    Anger += value;
                    break;
                case MoodType.Confident:
                    Confident += value;
                    break;
                case MoodType.Flirty:
                    Flirty += value;
                    break;
                case MoodType.Happy:
                    Happy += value;
                    break;
                case MoodType.Sad:
                    Sad += value;
                    break;
            }
        }
        else if (attributeType is NeedyType needy)
        {
            switch (needy)
            {
                case NeedyType.Hunger:
                    Hunger += value;
                    break;
                case NeedyType.Energy:
                    Energy += value;
                    break;
                case NeedyType.Hygiene:
                    Hygiene += value;
                    break;
                case NeedyType.Fun:
                    Fun += value;
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

    int cooldownEventIDontWantToEat = 0;
    public void Eat(string input)  // Input from Airi App To learn something
    {
        if (cooldownEventIDontWantToEat == 0)
        {

        }
        else
        {
            cooldownEventIDontWantToEat--;
        }
    }

    public void StatsChangePerActivity(int activity)
    {
        //Mood changes
        AiChangeStats(MoodType.Happy, -2);
        AiChangeStats(MoodType.Sad, 2);
        AiChangeStats(MoodType.Angry, -2);
        AiChangeStats(MoodType.Confident, -2);
        AiChangeStats(MoodType.Flirty, -2);

        //Neeedy changes
        AiChangeStats(NeedyType.Hunger, -3);
        AiChangeStats(NeedyType.Energy, -7);
        AiChangeStats(NeedyType.Fun, -3);
        AiChangeStats(NeedyType.Hygiene, -3);

        //Progress changes per even day
        if (activity == 0)
        {
            AiChangeStats(ProgressType.Cognitive, -1);
            AiChangeStats(ProgressType.Communication, -1);
            AiChangeStats(ProgressType.Creative, -1);
            AiChangeStats(ProgressType.Data, -1);
            AiChangeStats(ProgressType.Emotional, -1);
            AiChangeStats(ProgressType.TrustBonding, -1);
        }
    }

    public void EndingCheck()
    {
        //Mood endings
        if (Happy == 100)
        {
            
        }
        else if (Happy == 0)
        {
        }

        if (Anger == 100)
        {
        }
        else if (Anger == 0)
        {
        }

        if (Sad == 100)
        {
        }
        else if (Sad == 0)
        {
        }

        if (Confident == 100)
        {
        }
        else if (Confident == 0)
        {
        }

        if (Flirty == 100)
        {
        }
        else if (Flirty == 0)
        {
        }

        //Needy endings
        if (Hunger == 0)
        {
        }
        if (Energy == 0)
        {
        }
        if (Fun == 0)
        {
        }
        if (Hygiene == 0)
        {
        }

        //Skill endings
        if (Cognitive == 10)
        {
        }
        if (Communication == 10)
        {
        }
        if (Creative == 10)
        {
        }
        if (Data == 10)
        {
        }
        if (Emotional == 10)
        {
        }
        if (TrustBonding == 10)
        {
        }
    }

    /*public void DailyChatEvent()
    {
        //random number between 1-5
        int randomChatEvent = UnityEngine.Random.Range(1, 6);
        if (TrustBonding <= 3)
        {
            TrustBonding0To3(randomChatEvent);
        }
        else if (TrustBonding <= 6)
        {
            TrustBonding4To6(randomChatEvent);
        }
        else if (TrustBonding <= 9)
        {
            TrustBonding7To9(randomChatEvent);
        }
    }*/

    int overHungryDays = 0;
    int overEnergyDays = 0;
    public void EventCheck()
    {
        if (Hunger > 80)
        {
            EventIDontWantToEat();
        }
        else
        {
            overHungryDays = 0;
        }

        if (Energy > 90)
        {
            EventEnergetic();
        }
        else
        {
            overEnergyDays = 0;
        }

        //down the stats
        AiChangeStats(MoodType.Happy, -2);
        AiChangeStats(MoodType.Angry, -2);
        AiChangeStats(MoodType.Sad, -2);
        AiChangeStats(MoodType.Confident, -2);
        AiChangeStats(MoodType.Flirty, -2);
        
        AiChangeStats(NeedyType.Hunger, -3);
        AiChangeStats(NeedyType.Energy, -7);
        AiChangeStats(NeedyType.Fun, -3);
        AiChangeStats(NeedyType.Hygiene, -3);
    }


    public void EventIDontWantToEat()
    {
        overHungryDays++;
        if (overHungryDays >= 3 && cooldownEventIDontWantToEat == 0)
        {
            cooldownEventIDontWantToEat = 2;
        }
        else
        {
            overHungryDays = 0;
        }
    }

    int cooldownEventEnergetic = 0;
    public void EventEnergetic()
    {
        overEnergyDays++;
        if (overEnergyDays >= 3 && cooldownEventEnergetic == 0)
        {
            cooldownEventEnergetic = 2;
        }
        else
        {
            overEnergyDays = 0;
        }

        if (cooldownEventEnergetic > 0)
        {
            AiChangeStats(NeedyType.Energy, 100);
            AiChangeStats(NeedyType.Fun, 100);
            cooldownEventEnergetic--;
        }
    }

    private void Start()
    {
        Anger = 50;
        Confident = 50;
        Flirty = 50;
        Happy = 50;
        Sad = 50;

        Fun = 50;
        Hunger = 50;
        Energy = 100;
        Hygiene = 50;
    }
}