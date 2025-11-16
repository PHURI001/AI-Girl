using NUnit.Framework;
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
public class Airi : Layer2
{
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
        "Airi.Yummy(http://"
    };

    public TextMeshProUGUI CommandListText;
    private void Start()
    {
        CommandListSetUp(currentRoom);
        TestTextCheckRoom.text = currentRoom.ToString();
        Debug.Log(currentRoom);
    }

    public void MoodSwitch()
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

    private void CommandListSetUp(RoomType room)
    {
        if (room == RoomType.LivingRoom)
        {
            CommandListText.text = "Commands:\nAiri.MoveTo(\"BathRoom\")\nAiri.MoveTo(\"BedRoom\")\nAiri.MoveTo(\"Kitchen\")\nAiri.WatchTV()\nAiri.PickUpItem(\"Trash\")";
        }
        else if (room == RoomType.BathRoom)
        {
            CommandListText.text = "Commands:\nAiri.MoveTo(\"LivingRoom\")\nAiri.TakeShower()";
        }
        else if (room == RoomType.BedRoom)
        {
            CommandListText.text = "Commands:\nAiri.MoveTo(\"LivingRoom\")\nAiri.Sleep()";
        }
        else if (room == RoomType.Kitchen)
        {
            CommandListText.text = "Commands:\nAiri.MoveTo(\"LivingRoom\")\nAiri.Yummy(http://)";
        }
    }

    public void NeedySwitch()
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

    public void SkillSwitch()
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

    private void Update()
    {
        MoodText[0].GetComponent<TextMeshProUGUI>().text = "Anger: " + aiGirl.Anger;
        MoodText[1].GetComponent<TextMeshProUGUI>().text = "Confidence: " + aiGirl.Confidence;
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

    public void AddTrash()
    {
        //later
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
                CommandListSetUp(currentRoom);
            }
            else if (Input.text.Contains("WatchTV"))
            {
                OptionAIHandler(Needytype.Fun, 15);
            }
            else if (Input.text.Contains("TakeShower"))
            {
                OptionAIHandler(Needytype.Hygiene, 20);
                GameManager.Instance.AddActivityPoint();
            }
            else if (Input.text.Contains("Sleep"))
            {
                OptionAIHandler(Needytype.Energy, 40);
            }
            else if (Input.text.Contains("Yummy"))
            {
                OptionAIHandler(Needytype.Hunger, 30);
            }
            else if (Input.text.Contains("PickUpItem"))
            {
                //later
            }
        }
        TestTextCheckRoom.text = currentRoom.ToString();
    }
}
