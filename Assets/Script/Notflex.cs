using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum MovieType
{
    Comedy,
    Romance,
    Horror,
    Drama,
    Fantasy,
    Mystery,
    Documentary
}

public class Notflex : Application
{
    public void watching(int movieType)
    {
        switch (movieType)
        {
            case 0:  //Comedy
                aiChangeStats(ProgressType.Communication, 1);
                aiChangeStats(NeedyType.Fun, 15);
                break;
            case 1:  //Romance
                aiChangeStats(ProgressType.Emotional, 1);
                aiChangeStats(NeedyType.Fun, 10);
                aiChangeStats(MoodType.Flirty, 5);
                break;
            case 2:  //Horror
                aiChangeStats(MoodType.Happy, -10);
                aiChangeStats(MoodType.Sad, 10);
                aiChangeStats(NeedyType.Fun, 20);
                break;
            case 3:  //Drama
                aiChangeStats(ProgressType.Emotional, 1);
                aiChangeStats(MoodType.Angry, 10);
                aiChangeStats(NeedyType.Fun, 15);
                break;
            case 4:  //Fantasy
                aiChangeStats(ProgressType.Creative, 1);
                aiChangeStats(NeedyType.Fun, 10);
                aiChangeStats(MoodType.Happy, 10);
                break;
            case 5:  //Mystery
                aiChangeStats(ProgressType.Cognitive, 1);
                aiChangeStats(MoodType.Confident, 10);
                aiChangeStats(NeedyType.Fun, 10);
                break;
            case 6:  //Documentary
                aiChangeStats(ProgressType.Data, 1);
                aiChangeStats(MoodType.Confident, 5);
                aiChangeStats   (NeedyType.Fun, 5);
                break;
        }
    }
}