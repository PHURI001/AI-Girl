using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WordData
{
    public string word;
    public ProgressType type;
    public int value;
    //public String Description;
}

public class Chroma : Layer2
{
    public List<WordData> Data;

    public Canvas HomeCanvas;
    public TMP_InputField HomeInput;

    public Canvas SearchCanvas;
    public TMP_InputField SearchInput;
    public Canvas Scroll;

    public List<GameObject> Webs;

    public void Search()
    {
        if (HomeInput.text != "" && SearchCanvas.enabled == false)
        {
            HomeCanvas.enabled = false;
            SearchCanvas.enabled = true;

            SearchInput.text = HomeInput.text;
            webSetUp(0);
        }
        else if (SearchCanvas.enabled == true && SearchInput.text != "")
        {
            webSetUp(1);
        }
    }

    public void Home()
    {
        HomeCanvas.enabled = true;
        SearchCanvas.enabled = false;

        HomeInput.text = "";
        SearchInput.text = "";
    }

    private void webSetUp(int searchForm)  // 0 = home to web, 1 = web to web
    {
        bool found = false;
        string input;
        switch (searchForm)
        {
            case 0:
                input = HomeInput.text.ToLower();
                break;
            case 1:
                input = SearchInput.text.ToLower();
                break;
            default:
                input = "";
                break;
        }
        for (int i = 0; i < Data.Count; i++)
        {
            if (Data[i].word.ToLower() == input)
            {
                found = true;
            }
        }

        if (found)
        {
            //Debug.Log("Words found in Data.");
            Scroll.enabled = true;

            Webs[0].transform.Find("Title").GetComponent<TextMeshProUGUI>().text = $"Wiwi - What is {input}?";
            Webs[1].transform.Find("Title").GetComponent<TextMeshProUGUI>().text = $"Let's talk about {input}.";
            Webs[2].transform.Find("Title").GetComponent<TextMeshProUGUI>().text = $"Explore the meaning of {input}.";
            Webs[3].transform.Find("Title").GetComponent<TextMeshProUGUI>().text = $"A deeper look into {input}.";
            Webs[4].transform.Find("Title").GetComponent<TextMeshProUGUI>().text = $"Discover the essence of {input}.";
        }
        else
        {
            //Debug.Log("No words found in Data.");
            Scroll.enabled = false;
        }
    }

    public TextMeshProUGUI HomeDetectedText;
    public TextMeshProUGUI WebDetectedText;
    public void DetectWord()
    {
        //detect words that start with the same letter as front input
        /*HomeDetectedText.GetComponent<TextMeshProUGUI>().text = "";

        for (int i = 0; i < Data.Count; i++)
        {
            if (HomeInput.text.Length > 0 && char.ToLower(HomeInput.text[0]) == char.ToLower(Data[i].word[0]))
            {
                if (HomeDetectedText.GetComponent<TextMeshProUGUI>().text.Length == 0)
                {
                    HomeDetectedText.GetComponent<TextMeshProUGUI>().text += "Words detected: ";
                }
                HomeDetectedText.GetComponent<TextMeshProUGUI>().text += $"{Data[i].word}, ";
            }
            if (SearchInput.text.Length > 0 && char.ToLower(SearchInput.text[0]) == char.ToLower(Data[i].word[0]))
            {
                if (WebDetectedText.GetComponent<TextMeshProUGUI>().text.Length == 0)
                {
                    WebDetectedText.GetComponent<TextMeshProUGUI>().text += "Words detected: ";
                }
                WebDetectedText.GetComponent<TextMeshProUGUI>().text += $"{Data[i].word}, ";
            }
        }*/

        //detect words that start with the same string as all input
        HomeDetectedText.GetComponent<TextMeshProUGUI>().text = "";
        WebDetectedText.GetComponent<TextMeshProUGUI>().text = "";

        for (int i = 0; i < Data.Count; i++)
        {
            if (!string.IsNullOrEmpty(HomeInput.text))
            {
                int len = HomeInput.text.Length;
                string inputPart = HomeInput.text.Substring(0, len).ToLower();
                string wordPart = Data[i].word.Length >= len ? Data[i].word.Substring(0, len).ToLower() : "";

                if (inputPart == wordPart)
                {
                    if (HomeDetectedText.GetComponent<TextMeshProUGUI>().text.Length == 0)
                        HomeDetectedText.GetComponent<TextMeshProUGUI>().text = "Words detected: ";

                    HomeDetectedText.GetComponent<TextMeshProUGUI>().text += Data[i].word + ", ";
                }
            }

            if (!string.IsNullOrEmpty(SearchInput.text))
            {
                int len = SearchInput.text.Length;
                string inputPart = SearchInput.text.Substring(0, len).ToLower();
                string wordPart = Data[i].word.Length >= len ? Data[i].word.Substring(0, len).ToLower() : "";

                if (inputPart == wordPart)
                {
                    if (WebDetectedText.GetComponent<TextMeshProUGUI>().text.Length == 0)
                        WebDetectedText.GetComponent<TextMeshProUGUI>().text = "Words detected: ";

                    WebDetectedText.GetComponent<TextMeshProUGUI>().text += Data[i].word + ", ";
                }
            }
        }
    }
}