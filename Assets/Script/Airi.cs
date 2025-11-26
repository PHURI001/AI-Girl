using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

enum RoomType
{
    LivingRoom,
    BathRoom,
    BedRoom,
    Kitchen
}
public class Airi : Application
{
    public Trash trash;

    public Canvas CommandCanvas;
    public Canvas MoodCanvas;
    public Canvas NeedyCanvas;
    public Canvas SkillCanvas;

    public List<GameObject> MoodText;
    public List<GameObject> NeedyText;
    public List<GameObject> SkillText;

    public TMP_InputField Input;

    static private RoomType currentRoom;
    public TextMeshProUGUI TestTextCheckRoom;
    private List<string> livingRoomCommand = new List<string>()
    {
        "Airi.MoveTo(\"BathRoom\")",
        "Airi.MoveTo(\"BedRoom\")",
        "Airi.MoveTo(\"Kitchen\")",
        "Airi.WatchTV()",
        "Airi.RemoveTrash()"  //Move to trush app
    };
    private List<string> bathRoomCommand = new List<string>()
    {
        "Airi.MoveTo(\"LivingRoom\")",
        "Airi.TakeShower()"  //+20Hygiene
    };
    private List<string> bedRoomCommand = new List<string>()
    {
        "Airi.MoveTo(\"LivingRoom\")",
        "Airi.Sleep()"  //+40Energy
    };
    private List<string> kitchenCommand = new List<string>()
    {
        "Airi.MoveTo(\"LivingRoom\")",
        "Airi.Eat(http://"
    };

    public TextMeshProUGUI CommandListText;

    private List<WordData> data = new List<WordData>();
    private void Start()
    {
        //test trash
        TestTrashText.text = $"Trash: {totalTrash}";

        commandListSetUp(currentRoom);
        TestTextCheckRoom.text = currentRoom.ToString();
        //Debug.Log(currentRoom);

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

    public void MoodShow()
    {
        if (MoodCanvas.enabled)
        {
            MoodCanvas.enabled = false;
        }
        else
        {
            MoodCanvas.enabled = true;
        }
    }
    public void NeedyShow()
    {
        if (NeedyCanvas.enabled)
        {
            NeedyCanvas.enabled = false;
        }
        else
        {
            NeedyCanvas.enabled = true;
        }
    }

    public void SkillShow()
    {
        if (SkillCanvas.enabled)
        {
            SkillCanvas.enabled = false;
        }
        else
        {
            SkillCanvas.enabled = true;
        }
    }

    public void CommandShow()
    {
        if (CommandCanvas.enabled)
        {
            CommandCanvas.enabled = false;
        }
        else
        {
            CommandCanvas.enabled = true;
        }
    }

    private void commandListSetUp(RoomType room)
    {
        if (room == RoomType.LivingRoom)
        {
            CommandListText.text = "Commands:\n";
            foreach (var text in livingRoomCommand)
            {
                CommandListText.text += text + "\n";
            }
        }
        else if (room == RoomType.BathRoom)
        {
            CommandListText.text = "Commands:\n";
            foreach (var text in bathRoomCommand)
            {
                CommandListText.text += text + "\n";
            }
        }
        else if (room == RoomType.BedRoom)
        {
            CommandListText.text = "Commands:\n";
            foreach (var text in bedRoomCommand)
            {
                CommandListText.text += text + "\n";
            }
        }
        else if (room == RoomType.Kitchen)
        {
            CommandListText.text = "Commands:\n";
            foreach (var text in kitchenCommand)
            {
                CommandListText.text += text + "\n";
            }
        }
    }

    private void Update()
    {
        MoodText[0].GetComponent<TextMeshProUGUI>().text = "Anger: " + aiGirl.Anger;
        MoodText[1].GetComponent<TextMeshProUGUI>().text = "Confidence: " + aiGirl.Confident;
        MoodText[2].GetComponent<TextMeshProUGUI>().text = "Flirty: " + aiGirl.Flirty;
        MoodText[3].GetComponent<TextMeshProUGUI>().text = "Happy: " + aiGirl.Happy;
        MoodText[4].GetComponent<TextMeshProUGUI>().text = "Sad: " + aiGirl.Sad;

        NeedyText[0].GetComponent<TextMeshProUGUI>().text = "Fun: " + aiGirl.Fun;
        NeedyText[1].GetComponent<TextMeshProUGUI>().text = "Hunger: " + aiGirl.Hunger;
        NeedyText[2].GetComponent<TextMeshProUGUI>().text = "Energy: " + aiGirl.Energy;
        NeedyText[3].GetComponent<TextMeshProUGUI>().text = "Hygiene: " + aiGirl.Hygiene;

        SkillText[0].GetComponent<TextMeshProUGUI>().text = "Cognitive: " + aiGirl.Cognitive;
        SkillText[1].GetComponent<TextMeshProUGUI>().text = "Communication: " + aiGirl.Communication;
        SkillText[2].GetComponent<TextMeshProUGUI>().text = "Creative: " + aiGirl.Creative;
        SkillText[3].GetComponent<TextMeshProUGUI>().text = "Data: " + aiGirl.Data;
        SkillText[4].GetComponent<TextMeshProUGUI>().text = "Emotional: " + aiGirl.Emotional;
        SkillText[5].GetComponent<TextMeshProUGUI>().text = "TrustBonding: " + aiGirl.TrustBonding;
    }

    public void CommandActive()
    {
        bool commandFound = false;
        switch (currentRoom)
        {
            case RoomType.LivingRoom:
                foreach (string command in livingRoomCommand)
                {
                    if (Input.text == command)
                    {
                        commandFound = true;
                        break;
                    }
                }
                break;
            case RoomType.BathRoom:
                foreach (string command in bathRoomCommand)
                {
                    if (Input.text == command)
                    {
                        commandFound = true;
                        break;
                    }
                }
                break;
            case RoomType.BedRoom:
                foreach (string command in bedRoomCommand)
                {
                    if (Input.text == command)
                    {
                        commandFound = true;
                        break;
                    }
                }
                break;
            case RoomType.Kitchen:
                foreach (string command in kitchenCommand)
                {
                    if (Input.text == command)
                    {
                        commandFound = true;
                        break;
                    }
                }
                break;
        }

        if (commandFound)
        {
            if (Input.text.Contains("MoveTo"))
            {
                if (Input.text.Contains("BathRoom"))
                {
                    currentRoom = RoomType.BathRoom;
                }
                else if (Input.text.Contains("BedRoom"))
                {
                    currentRoom = RoomType.BedRoom;
                }
                else if (Input.text.Contains("Kitchen"))
                {
                    currentRoom = RoomType.Kitchen;
                }
                else if (Input.text.Contains("LivingRoom"))
                {
                    currentRoom = RoomType.LivingRoom;
                }
                commandListSetUp(currentRoom);
            }
            else if (Input.text.Contains("WatchTV"))
            {
                aiChangeStats(NeedyType.Fun, 15);
                GameManager.Instance.DoActivity();
            }
            else if (Input.text.Contains("TakeShower"))
            {
                aiChangeStats(NeedyType.Hygiene, 20);
                GameManager.Instance.DoActivity();
            }
            else if (Input.text.Contains("Sleep"))
            {
                aiChangeStats(NeedyType.Energy, 40);
                GameManager.Instance.DoActivity();
            }
            else if (Input.text.Contains("Eat"))
            {
                if (Input.text.Contains("Wiwi.com/") || Input.text.Contains("YouNube.com/") || Input.text.Contains("KoCoColor.com/") || Input.text.Contains("EverMuse.com/") || Input.text.Contains("QuietRiver.com/"))
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (Input.text.Contains(data[i].Word))
                        {
                            aiChangeStats(data[i].Type, data[i].Value);
                            aiChangeStats(NeedyType.Hunger, 30);
                            aiChangeStats(NeedyType.Energy, -5);
                            aiChangeStats(MoodType.Confident, 10);
                            GameManager.Instance.DoActivity();
                        }
                    }
                }
                else
                {
                    Input.text = "error: web not found";
                };
            }
            else if (Input.text.Contains("RemoveTrash"))
            {
                RemoveTrash();
                GameManager.Instance.DoActivity();
            }
        }
        TestTextCheckRoom.text = currentRoom.ToString();
    }

    int maxTrash = 7;
    int addTrashValue = 2;
    int totalTrash;

    public TextMeshProUGUI TestTrashText;
    public void AddTrash(int value)
    {
        totalTrash += value;
        if (totalTrash > maxTrash)
        {
            totalTrash = maxTrash;
        }
    }

    public void TrashActive()
    {
        aiChangeStats(NeedyType.Hygiene, totalTrash * 2);
    }

    public void RemoveTrash()
    {
        trash.AddTrash(totalTrash);
        totalTrash = 0;
        TestTrashText.text = $"Trash: {totalTrash}";
    }

    public void Event(int day)
    {
        if (day%2 == 0)
        {
            AddTrash(addTrashValue);
        }

        if (totalTrash != 0)
        {
            TrashActive();
        }
    }
}
