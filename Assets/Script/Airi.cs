using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void Test()
    {
        Debug.Log($"User Type: {Input.text}");
    }
}
