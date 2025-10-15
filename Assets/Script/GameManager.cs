using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AIGirl aiGirl;
    private Chroma chroma;

    void Start()
    {
        GameObject Object = new GameObject("AIGirl");
        aiGirl = Object.AddComponent<AIGirl>();

        Object = new GameObject("Chroma");
        chroma = Object.AddComponent<Chroma>();
        chroma.aiGirl = aiGirl;

        /*aiGirl.OptionAIHandler(Moodtype.Happy, 15550);
        Debug.Log("Happy: " + aiGirl.Happy);*/

        /*chroma.OptionAIHandler(Moodtype.Happy, 15550);
        Debug.Log("Happy: " + aiGirl.Happy);*/

        //check chroma data
        /*foreach (var data in chroma.data)
        {
            Debug.Log($"{data.name}, {data.type}, {data.value}");
        }*/
    }
}