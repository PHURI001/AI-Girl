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

public class Notflex : Layer2
{
    public void Watching(int movieType)
    {
        switch (movieType)
        {
            case 0:  //Comedy
                OptionAIHandler(ProgressType.Communication, 1);
                //OptionAIHandler(Moodtype.Fun, 15);
                break;
            case 1:  //Romance
                OptionAIHandler(ProgressType.Emotional, 1);
                OptionAIHandler(Needytype.Fun, 10);
                OptionAIHandler(Moodtype.Flirty, 5);
                break;
            case 2:  //Horror
                OptionAIHandler(Moodtype.Happy, -10);
                OptionAIHandler(Moodtype.Sad, 10);
                OptionAIHandler(Needytype.Fun, 20);
                break;
            case 3:  //Drama
                OptionAIHandler(ProgressType.Emotional, 1);
                OptionAIHandler(Moodtype.Angry, 10);
                OptionAIHandler(Needytype.Fun, 15);
                break;
            case 4:  //Fantasy
                OptionAIHandler(ProgressType.Creative, 1);
                OptionAIHandler(Needytype.Fun, 10);
                OptionAIHandler(Moodtype.Happy, 10);
                break;
            case 5:  //Mystery
                OptionAIHandler(ProgressType.Cognitive, 1);
                OptionAIHandler(Moodtype.Confident, 10);
                OptionAIHandler(Needytype.Fun, 10);
                break;
            case 6:  //Documentary
                OptionAIHandler(ProgressType.Data, 1);
                OptionAIHandler(Moodtype.Confident, 5);
                OptionAIHandler(Needytype.Fun, 5);
                break;
        }
    }
}