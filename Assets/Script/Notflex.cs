using System;
using System.Collections.Generic;
using UnityEngine;

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

public class Notflex : Layer2
{
    public void Watching(Enum movieType)
    {
        switch (movieType)
        {
            case MovieType.Comedy:
                OptionAIHandler(ProgressType.Communication, 1);
                OptionAIHandler(Moodtype.Fun, 15);
                break;
            case MovieType.Romance:
                OptionAIHandler(ProgressType.Emotional, 1);
                OptionAIHandler(Moodtype.Fun, 10);
                OptionAIHandler(Moodtype.Flirty, 5);
                break;
            case MovieType.Horror:
                OptionAIHandler(Moodtype.Happy, -10);
                OptionAIHandler(Moodtype.Sad, 10);
                OptionAIHandler(Moodtype.Fun, 20);
                break;
            case Moodtype.Drama:
                OptionAIHandler(ProgressType.Emotional, 1);
                OptionAIHandler(Moodtype.Angry, 10);
                OptionAIHandler(Moodtype.Fun, 15);
                break;
            case MovieType.Fantasy:
                OptionAIHandler(ProgressType.Creative, 1);
                OptionAIHandler(Moodtype.Fun, 10);
                OptionAIHandler(Moodtype.Happy, 10);
                break;
            case MovieType.Mystery:
                OptionAIHandler(ProgressType.Cognitive, 1);
                OptionAIHandler(Moodtype.Confident, 10);
                OptionAIHandler(Moodtype.Fun, 10);
                break;
            case MovieType.Documentary:
                OptionAIHandler(ProgressType.Data, 1);
                OptionAIHandler(Moodtype.Confident, 5);
                OptionAIHandler(Moodtype.Fun, 5);
                break;
        }
    }
}