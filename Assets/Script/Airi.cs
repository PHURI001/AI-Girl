using NUnit.Framework;
using System;
using System.Collections;
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

    static private RoomType currentRoom = RoomType.LivingRoom;
    public TextMeshProUGUI ShowCurrentRoom;
    private List<string> livingRoomCommand = new List<string>()
    {
        "Airi.MoveTo(\"BathRoom\")",
        "Airi.MoveTo(\"BedRoom\")",
        "Airi.MoveTo(\"Kitchen\")",
        "Airi.Use(\"TV\")",
        "Airi.PickUpItem(\"Trash\")"  //Move to trush app
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
        "Airi.Yummy("
    };

    private List<WordData> data = new List<WordData>();
    private void Start()
    {
        //test trash
        //TestTrashText.text = $"Trash: {totalTrash}";
        AddTrash(0);

        //commandListSetUp(currentRoom);
        ShowCurrentRoom.text = currentRoom.ToString();

        switch (currentRoom)
        {
            case RoomType.LivingRoom:
                RoomImage[0].enabled = true;
                break;
            case RoomType.BathRoom:
                RoomImage[1].enabled = true;
                break;
            case RoomType.Kitchen:
                RoomImage[2].enabled = true;
                break;
            case RoomType.BedRoom:
                RoomImage[3].enabled = true;
                break;
        }

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
        NeedyCanvas.enabled = false;
        SkillCanvas.enabled = false;
        commandOpened = true;
        CommandShow();
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
        MoodCanvas.enabled = false;
        SkillCanvas.enabled = false;
        commandOpened = true;
        CommandShow();
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
        MoodCanvas.enabled = false;
        NeedyCanvas.enabled = false;
        commandOpened = true;
        CommandShow();
        if (SkillCanvas.enabled)
        {
            SkillCanvas.enabled = false;
        }
        else
        {
            SkillCanvas.enabled = true;
        }
    }

    public List<Image> CommandImage;
    bool commandOpened = false;
    public void CommandShow()
    {
        MoodCanvas.enabled = false;
        NeedyCanvas.enabled = false;
        SkillCanvas.enabled = false;

        if (commandOpened)
        {
            commandOpened = false;
        }
        else { commandOpened = true; }

        if (currentRoom == RoomType.LivingRoom)
        {
            if (totalTrash > 0)
            {
                CommandImage[0].enabled = commandOpened;
            }
            else
            {
                CommandImage[1].enabled = commandOpened;
            }
        }
        else if (currentRoom == RoomType.BathRoom)
        {
            CommandImage[2].enabled = commandOpened;
        }
        else if (currentRoom == RoomType.Kitchen)
        {
            CommandImage[3].enabled = commandOpened;
        }
        else if (currentRoom == RoomType.BedRoom)
        {
            CommandImage[4].enabled = commandOpened;
        }
    }

    private void isCommandShowing()
    {
        if (commandOpened)
        {
            foreach (Image image in CommandImage)
            {
                image.enabled = false;
            }
            commandOpened = false;
            CommandShow();
        }
    }

    private void Update()
    {
        MoodText[0].GetComponent<TextMeshProUGUI>().text = aiGirl.Anger + "%";
        MoodText[1].GetComponent<TextMeshProUGUI>().text = aiGirl.Confident + "%";
        MoodText[2].GetComponent<TextMeshProUGUI>().text = aiGirl.Flirty + "%";
        MoodText[3].GetComponent<TextMeshProUGUI>().text = aiGirl.Happy + "%";
        MoodText[4].GetComponent<TextMeshProUGUI>().text = aiGirl.Sad + "%";

        NeedyText[0].GetComponent<TextMeshProUGUI>().text = aiGirl.Fun + "%";
        NeedyText[1].GetComponent<TextMeshProUGUI>().text = aiGirl.Hunger + "%";
        NeedyText[2].GetComponent<TextMeshProUGUI>().text = aiGirl.Energy + "%";
        NeedyText[3].GetComponent<TextMeshProUGUI>().text = aiGirl.Hygiene + "%";

        SkillText[0].GetComponent<TextMeshProUGUI>().text = aiGirl.Cognitive * 10 + "%";
        SkillText[1].GetComponent<TextMeshProUGUI>().text = aiGirl.Communication * 10 + "%";
        SkillText[2].GetComponent<TextMeshProUGUI>().text = aiGirl.Creative * 10 + "%";
        SkillText[3].GetComponent<TextMeshProUGUI>().text = aiGirl.Data * 10 + "%";
        SkillText[4].GetComponent<TextMeshProUGUI>().text = aiGirl.Emotional * 10 + "%";
        SkillText[5].GetComponent<TextMeshProUGUI>().text = aiGirl.TrustBonding * 10 + "%";
    }

    public List<Canvas> RoomImage;
    public void CommandActive()
    {
        bool commandFound = false;
        Input.text = Input.text.ToUpper();
        //Debug.Log("Active");
        switch (currentRoom)
        {
            case RoomType.LivingRoom:
                foreach (string command in livingRoomCommand)
                {
                    if (Input.text == command.ToUpper())
                    {
                        commandFound = true;
                        break;
                    }
                }
                break;
            case RoomType.BathRoom:
                foreach (string command in bathRoomCommand)
                {
                    if (Input.text == command.ToUpper())
                    {
                        commandFound = true;
                        break;
                    }
                }
                break;
            case RoomType.BedRoom:
                foreach (string command in bedRoomCommand)
                {
                    if (Input.text == command.ToUpper())
                    {
                        commandFound = true;
                        break;
                    }
                }
                break;
            case RoomType.Kitchen:
                foreach (string command in kitchenCommand)
                {
                    if (Input.text.Contains(command.ToUpper()))
                    {
                        commandFound = true;
                        break;
                    }
                }
                break;
        }

        if (commandFound && aiGirl.IsFree)
        {
            if (Input.text.Contains("MOVETO"))
            {
                foreach (Canvas image in RoomImage)
                {
                    image.enabled = false;
                }
                if (Input.text.Contains("BATHROOM"))
                {
                    currentRoom = RoomType.BathRoom;
                    RoomImage[1].enabled = true;
                }
                else if (Input.text.Contains("BEDROOM"))
                {
                    currentRoom = RoomType.BedRoom;
                    RoomImage[3].enabled = true;
                }
                else if (Input.text.Contains("KITCHEN"))
                {
                    currentRoom = RoomType.Kitchen;
                    RoomImage[2].enabled = true;
                }
                else if (Input.text.Contains("LIVINGROOM"))
                {
                    currentRoom = RoomType.LivingRoom;
                    RoomImage[0].enabled = true;
                }
                //commandListSetUp(currentRoom);
                isCommandShowing();
            }
            else if (Input.text.Contains("TV"))
            {
                aiChangeStats(NeedyType.Energy, -5);

                var allUI = FindObjectsByType<ThisIsUI>(FindObjectsSortMode.None);
                foreach (var ui in allUI)
                {
                    if (ui.GetComponentInChildren<Airi>() != null) continue;
                    if (ui.GetComponentInChildren<Notflex>() != null) continue;

                    Destroy(ui.gameObject);
                }
#pragma warning disable CS0618 // Type or member is obsolete
                SpawnCanvasUI spawnCanvasUI = FindObjectOfType<SpawnCanvasUI>();
#pragma warning restore CS0618 // Type or member is obsolete

                spawnCanvasUI.Airi();
                spawnCanvasUI.Notflex();

                aiGirl.IsFree = false;
            }
            else if (Input.text.Contains("TAKESHOWER"))
            {
                aiChangeStats(NeedyType.Hygiene, 20);
                GameManager.Instance.DoActivity();
            }
            else if (Input.text.Contains("SLEEP"))
            {
                aiChangeStats(NeedyType.Energy, 40);
                GameManager.Instance.DoActivity();
            }
            else if (Input.text.Contains("YUMMY"))
            {
                if (Input.text.Contains("WIWI.COM/") || Input.text.Contains("YOUNUBE.COM/") || Input.text.Contains("KOCOCOLOR.COM/") || Input.text.Contains("EVERMUSE.COM/") || Input.text.Contains("QUIETRIVER.COM/"))
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (Input.text.Contains(data[i].Word.ToUpper()))
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
            else if (Input.text.Contains("TRASH"))
            {
                RemoveTrash();
            }
        }
        else if (!aiGirl.IsFree)
        {
            Input.text = "Do Your Act Until Done.";
        }
        else
        {
            Input.text = "error: what are you going to do, bro?";
        }
            ShowCurrentRoom.text = currentRoom.ToString();
    }

    int maxTrash = 7;
    int addTrashValue = 2;
    static int totalTrash;

    public List<Image> TrashImage;
    public override void AddTrash(int value)
    {
        totalTrash += value;
        if (totalTrash > 0)
        {
            foreach (Image image in TrashImage)
            {
                image.enabled = true;
            }
        }

        if (totalTrash > maxTrash)
        {
            totalTrash = maxTrash;
        }
    }

    public void TrashActive()
    {
        aiChangeStats(NeedyType.Hygiene, totalTrash * 2);
    }

    public override void RemoveTrash()
    {
        trash.AddTrash(totalTrash);
        totalTrash = 0;
        foreach (Image image in TrashImage)
        {
            image.enabled = false;
        }
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
        
        int random = UnityEngine.Random.Range(1, 5);
        switch (random)
        {
            case 1:
                currentRoom = RoomType.LivingRoom;
                break;
            case 2:
                currentRoom = RoomType.BathRoom;
                break;
            case 3:
                currentRoom = RoomType.BedRoom;
                break;
            case 4:
                currentRoom = RoomType.Kitchen;
                break;
        }
    }
}
