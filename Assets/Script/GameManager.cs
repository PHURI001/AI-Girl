using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AIGirl aiGirl;
    private Chroma chroma;
    private Notflex notflex;

    void Start()
    {
        GameObject Object = new GameObject("AIGirl");
        aiGirl = Object.AddComponent<AIGirl>();

        Object = new GameObject("Chroma");
        chroma = Object.AddComponent<Chroma>();

        Object = new GameObject("Notflex");
        notflex = Object.AddComponent<Notflex>();

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
}