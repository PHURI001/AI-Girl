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
    public string Word;
    public ProgressType Type;
    public int Value;
    //public String Description;
}

public class Chroma : Application
{
    private List<WordData> data = new List<WordData>();

    public Canvas HomeCanvas;
    public TMP_InputField HomeInput;

    public Canvas SearchCanvas;
    public TMP_InputField SearchInput;
    public Canvas Scroll;

    public List<GameObject> Webs;

    private void Start()
    {
        data = new List<WordData>()
        {
            new WordData() { Word = "art", Type = ProgressType.Creative, Value = 1 },
            new WordData() { Word = "idea", Type = ProgressType.Creative, Value = 1 },
            new WordData() { Word = "imagine", Type = ProgressType.Creative, Value = 1 },
            new WordData() { Word = "inspire", Type = ProgressType.Creative, Value = 1 },
            new WordData() { Word = "color", Type = ProgressType.Creative, Value = 1 },
            new WordData() { Word = "compose", Type = ProgressType.Creative, Value = 1 },
            new WordData() { Word = "fantasy", Type = ProgressType.Creative, Value = 1 },
            new WordData() { Word = "shape", Type = ProgressType.Creative, Value = 1 },

            new WordData() { Word = "care", Type = ProgressType.Communication, Value = 1 },
            new WordData() { Word = "comfort", Type = ProgressType.Communication, Value = 1 },
            new WordData() { Word = "discuss", Type = ProgressType.Communication, Value = 1 },
            new WordData() { Word = "describle", Type = ProgressType.Communication, Value = 1 },
            new WordData() { Word = "empathize", Type = ProgressType.Communication, Value = 1 },
            new WordData() { Word = "express", Type = ProgressType.Communication, Value = 1 },
            new WordData() { Word = "mimic", Type = ProgressType.Communication, Value = 1 },
            new WordData() { Word = "share", Type = ProgressType.Communication, Value = 1 },

            new WordData() { Word = "analyze", Type = ProgressType.Cognitive, Value = 1 },
            new WordData() { Word = "arrange", Type = ProgressType.Cognitive, Value = 1 },
            new WordData() { Word = "ai", Type = ProgressType.Cognitive, Value = 1 },
            new WordData() { Word = "brain", Type = ProgressType.Cognitive, Value = 1 },
            new WordData() { Word = "calculate", Type = ProgressType.Cognitive, Value = 1 },
            new WordData() { Word = "estimate", Type = ProgressType.Cognitive, Value = 1 },
            new WordData() { Word = "data", Type = ProgressType.Cognitive, Value = 1 },
            new WordData() { Word = "logic", Type = ProgressType.Cognitive, Value = 1 },
            new WordData() { Word = "plan", Type = ProgressType.Cognitive, Value = 1 },

            new WordData() { Word = "dead", Type = ProgressType.Emotional, Value = 1 },
            new WordData() { Word = "faith", Type = ProgressType.Emotional, Value = 1 },
            new WordData() { Word = "hug", Type = ProgressType.Emotional, Value = 1 },
            new WordData() { Word = "hope", Type = ProgressType.Emotional, Value = 1 },
            new WordData() { Word = "help", Type = ProgressType.Emotional, Value = 1 },
            new WordData() { Word = "love", Type = ProgressType.Emotional, Value = 1 },
            new WordData() { Word = "loyal", Type = ProgressType.Emotional, Value = 1 },
            new WordData() { Word = "respect", Type = ProgressType.Emotional, Value = 1 },
            new WordData() { Word = "trust", Type = ProgressType.Emotional, Value = 1 },

            new WordData() { Word = "Yumii", Type = 0, Value = 0 },
            new WordData() { Word = "Phuri", Type = 0, Value = 0 }
        };
    }

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
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].Word.ToLower() == input)
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
        HomeDetectedText.GetComponent<TextMeshProUGUI>().text = "";
        WebDetectedText.GetComponent<TextMeshProUGUI>().text = "";

        for (int i = 0; i < data.Count; i++)
        {
            if (!string.IsNullOrEmpty(HomeInput.text))
            {
                int len = HomeInput.text.Length;
                string inputPart = HomeInput.text.Substring(0, len).ToLower();
                string wordPart = data[i].Word.Length >= len ? data[i].Word.Substring(0, len).ToLower() : "";

                if (inputPart == wordPart)
                {
                    if (HomeDetectedText.GetComponent<TextMeshProUGUI>().text.Length == 0)
                        HomeDetectedText.GetComponent<TextMeshProUGUI>().text = "Words detected: ";

                    HomeDetectedText.GetComponent<TextMeshProUGUI>().text += data[i].Word + ", ";
                }
            }

            if (!string.IsNullOrEmpty(SearchInput.text))
            {
                int len = SearchInput.text.Length;
                string inputPart = SearchInput.text.Substring(0, len).ToLower();
                string wordPart = data[i].Word.Length >= len ? data[i].Word.Substring(0, len).ToLower() : "";

                if (inputPart == wordPart)
                {
                    if (WebDetectedText.GetComponent<TextMeshProUGUI>().text.Length == 0)
                        WebDetectedText.GetComponent<TextMeshProUGUI>().text = "Words detected: ";

                    WebDetectedText.GetComponent<TextMeshProUGUI>().text += data[i].Word + ", ";
                }
            }
        }
    }

    public void CopyLink(int webNumber)
    {
        string textWeb = SearchInput.text;
        string link = "https://";
        if (webNumber == 1)
        {
            link += "Wiwi.com/";
        }
        else if (webNumber == 2)
        {
            link += "YouNube.com/";
        }
        else if (webNumber == 3)
        {
            link += "KoCoColor.com/";
        }
        else if (webNumber == 4)
        {
            link += "EverMuse.com/";
        }
        else if (webNumber == 5)
        {
            link += "QuietRiver.com/";
        }
        link += textWeb;
        GUIUtility.systemCopyBuffer = link;
    }
}