using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chat : MonoBehaviour
{
    AIGirl aiGirl;
    public GameObject ChatCanvas;
    public List<GameObject> TextLogs = new List<GameObject>();
    public Canvas RespomdCanvas;

    [System.Obsolete]
    private void Start()
    {
        aiGirl = FindObjectOfType<AIGirl>();
        //Debug.Log("Chat active");
        RandomChat();
    }
    public void Chatting()
    {
        RandomChat();
        //Clone ui to game
        if (ChatCanvas != null)
        {
            RectTransform rect = ChatCanvas.GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.SetParent(null);
                rect.localPosition = Vector3.zero;
                rect.localScale = Vector3.one;
            }

            Canvas canvasComp = ChatCanvas.GetComponent<Canvas>();
            if (canvasComp != null)
            {
                canvasComp.renderMode = RenderMode.ScreenSpaceOverlay;
                canvasComp.sortingOrder = 100;
            }
        }
    }

    int ran;
    private void RandomChat()
    {
        ran = Random.Range(0, 5);
        ChatActive(ran);
    }

    string asking;
    string respond;
    string choice1;
    string choice2;
    string choice3;
    public void ChatActive(int value)
    {
        asking = "Airi: ";
        respond = "Airi: ";
        choice1 = "A.";
        choice2 = "B.";
        choice3 = "C.";
        if (aiGirl.TrustBonding <= 3)
        {
            if (value == 0)
            {
                asking += "What kind of hobbies do you usually enjoy?";
                choice1 += "Reading or watching something relaxing.";
                choice2 += "Fighting dangerous monsters every weekend.";
                choice3 += " I don’t enjoy anything at all.";
            }
            if (value == 1)
            {
                asking += "How do you prefer to start your day?";
                choice1 += "With a calm morning routine.";
                choice2 += "By shouting loudly to wake everyone weekend.";
                choice3 += "By skipping the morning entirely.";
            }
            if (value == 2)
            {
                asking += "What kind of food do you usually like?";
                choice1 += "Only the world’s spiciest food.";
                choice2 += "I survive only on candy.";
                choice3 += "Something simple, like home-cooked meals.";
            }
            if (value == 3)
            {
                asking += "Do you enjoy talking with new people?";
                choice1 += "No, I never talk to anyone.";
                choice2 += "Yes, but slowly and comfortably.";
                choice3 += "Only if I can interrogate them.";
            }
            if (value == 4)
            {
                asking += "How would you describe your personality?";
                choice1 += "Calm or friendly, depending on the situation.";
                choice2 += "I’m always angry.";
                choice3 += "I have no personality.";
            }
        }
        else if (aiGirl.TrustBonding <= 6)
        {
            if (value == 0)
            {
                asking += "What kind of places make you feel relaxed?";
                choice1 += "Quiet places like cafés or parks.";
                choice2 += "Extremely crowded concerts.";
                choice3 += "Noisy construction sites.";
            }
            if (value == 1)
            {
                asking += "If you’re having a bad day, how do you usually cheer yourself up?";
                choice1 += "Destroying something.";
                choice2 += "Listening to music or taking a break.";
                choice3 += "Pretending the day doesn’t exist.";
            }
            if (value == 2)
            {
                asking += "What kind of conversations do you enjoy the most?";
                choice1 += "Silent staring contests.";
                choice2 += "Arguments only.";
                choice3 += "Honest and gentle ones.";
            }
            if (value == 3)
            {
                asking += "If we were to hang out together, what would you like to do?";
                choice1 += "Something simple, like chatting or walking.";
                choice2 += "Sit in silence for 6 hours.";
                choice3 += "Rob a bank.";
            }
            if (value == 4)
            {
                asking += "What kind of gift would make you happy?";
                choice1 += "A giant statue of myself.";
                choice2 += "Anything extremely expensive.";
                choice3 += "Something thoughtful, even if it’s small.";
            }
        }
        else if (aiGirl.TrustBonding <= 9)
        {
            if (value == 0)
            {
                asking += "What do you value most in someone you trust?";
                choice1 += "Nothing, trust is unnecessary.";
                choice2 += "Their ability to buy things for me.";
                choice3 += "Kindness and honesty.";
            }
            if (value == 1)
            {
                asking += "If something makes you anxious, would you tell me?";
                choice1 += "I’ll never say anything.";
                choice2 += "Yes, if I feel safe with you.";
                choice3 += "I’ll shout it in public.";
            }
            if (value == 2)
            {
                asking += "What kind of moments make you feel close to someone?";
                choice1 += "When we have calm conversations or share feelings.";
                choice2 += "When we ignore each other.";
                choice3 += "When we fight.";
            }
            if (value == 3)
            {
                asking += "What would you do if I felt lonely someday?";
                choice1 += "Keep you company and talk with you.";
                choice2 += "Laugh.";
                choice3 += "Tell you to deal with it alone.";
            }
            if (value == 4)
            {
                asking += "What kind of future moments would you like us to share?";
                choice1 += "Extreme battles.";
                choice2 += "Warm, peaceful memories together.";
                choice3 += "No memories at all.";
            }
        }

        TextLogs[0].GetComponent<TextMeshProUGUI>().text = asking;
        TextLogs[1].GetComponent<TextMeshProUGUI>().text = choice1;
        TextLogs[2].GetComponent<TextMeshProUGUI>().text = choice2;
        TextLogs[3].GetComponent<TextMeshProUGUI>().text = choice3;
    }

    bool responded = false;
    public void ChatRespond(int choose)
    {
        ChatActive(ran, choose);
    }
    public void ChatActive(int value, int choose)
    {
        responded = true;
        respond = "Airi: ";
        if (aiGirl.TrustBonding <= 3)
        {
            if (value == 0)
            {
                if (choose == 1)
                {
                    respond += "Oh, that sounds peaceful. I like that.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                }
                else if (choose == 2)
                {
                    respond += "Eh? That sounds… a bit scary.";
                    aiGirl.AiChangeStats(NeedyType.Fun, 5);
                }
                else if (choose == 3)
                {
                    respond += "O-Oh… that sounds a bit sad.";
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                    aiGirl.AiChangeStats(MoodType.Happy, -5);
                }
            }
            if (value == 1)
            {
                if (choose == 1)
                {
                    respond += "A calm start is really nice…";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                }
                else if (choose == 2)
                {
                    respond += "That’s quite energetic.";
                    aiGirl.AiChangeStats(NeedyType.Fun, 5);
                }
                else if (choose == 3)
                {
                    respond += "Skipping the morning…? I’d feel weird doing that.";
                    aiGirl.AiChangeStats(MoodType.Happy, -5);
                }
            }
            if (value == 2)
            {
                if (choose == 1)
                {
                    respond += "Uwaa…that sounds scary…";
                    aiGirl.AiChangeStats(NeedyType.Hunger, 5);
                    aiGirl.AiChangeStats(NeedyType.Fun, 5);
                }
                else if (choose == 2)
                {
                    respond += "E-Eh? That can’t be healthy…";
                    aiGirl.AiChangeStats(NeedyType.Hunger, 5);
                    aiGirl.AiChangeStats(NeedyType.Fun, 5);
                }
                else if (choose == 3)
                {
                    respond += "Simple food is comforting… I like that answer.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(NeedyType.Hunger, 5);
                }
            }
            if (value == 3)
            {
                if (choose == 1)
                {
                    respond += "Really? I hope talking with me isn’t too hard…";
                    aiGirl.AiChangeStats(MoodType.Flirty, 5);
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                }
                else if (choose == 2)
                {
                    respond += "I feel the same. Slow and gentle is nice.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Flirty, 5);
                }
                else if (choose == 3)
                {
                    respond += "Interrogate…? That’s a little intense.";
                    aiGirl.AiChangeStats(MoodType.Angry, 5);
                    aiGirl.AiChangeStats(MoodType.Happy, -5);
                }
            }
            if (value == 4)
            {
                if (choose == 1)
                {
                    respond += "That sounds balanced… I like that.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                }
                else if (choose == 2)
                {
                    respond += "A-ah… I’d be a little scared…";
                    aiGirl.AiChangeStats(MoodType.Happy, -5);
                }
                else if (choose == 3)
                {
                    respond += "Don’t say that… I’m sure you do.";
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                }
            }
        }
        else if (aiGirl.TrustBonding <= 6)
        {
            if (value == 0)
            {
                if (choose == 1)
                {
                    respond += "Me too… It’d be nice to go together someday.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Flirty, 5);
                }
                else if (choose == 2)
                {
                    respond += "Crowded places make me nervous…";
                    aiGirl.AiChangeStats(MoodType.Confident, -5);
                }
                else if (choose == 3)
                {
                    respond += "Construction sites…? Really?";
                    aiGirl.AiChangeStats(MoodType.Happy, -5);
                }
            }
            if (value == 1)
            {
                if (choose == 1)
                {
                    respond += "U-Um… I think that’s dangerous…";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, -1);
                    aiGirl.AiChangeStats(MoodType.Angry, 5);
                }
                else if (choose == 2)
                {
                    respond += "That’s healthy… I’m glad you treat yourself kindly.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Happy, 5);
                }
                else if (choose == 3)
                {
                    respond += "I get the feeling… but it might not help much.";
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                }
            }
            if (value == 2)
            {
                if (choose == 1)
                {
                    respond += "… That’s a little awkward.";
                    aiGirl.AiChangeStats(MoodType.Confident, -5);
                }
                else if (choose == 2)
                {
                    respond += "Arguing all the time sounds tiring…";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, -1);
                    aiGirl.AiChangeStats(MoodType.Angry, 5);
                }
                else if (choose == 3)
                {
                    respond += "That’s the kind of talk I like too.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Happy, 5);
                }
            }
            if (value == 3)
            {
                if (choose == 1)
                {
                    respond += "I’d like that… spending quiet time together sounds nice.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Happy, 5);
                    aiGirl.AiChangeStats(MoodType.Flirty, 5);
                }
                else if (choose == 2)
                {
                    respond += "Um… maybe that’s too long…";
                }
                else if (choose == 3)
                {
                    respond += "W-What!? No way!";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, -1);
                    aiGirl.AiChangeStats(MoodType.Angry, 5);
                }
            }
            if (value == 4)
            {
                if (choose == 1)
                {
                    respond += "Uhh… that might be embarrassing…";
                    aiGirl.AiChangeStats(MoodType.Happy, -5);
                    aiGirl.AiChangeStats(MoodType.Confident, -5);
                }
                else if (choose == 2)
                {
                    respond += "Expensive doesn’t always mean good…";
                }
                else if (choose == 3)
                {
                    respond += "That’s sweet… I like meaningful things.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Happy, 5);
                }
            }
        }
        else if (aiGirl.TrustBonding <= 9)
        {
            if (value == 0)
            {
                if (choose == 1)
                {
                    respond += "I don’t think I could be close to someone like that…";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, -1);
                }
                else if (choose == 2)
                {
                    respond += "Ehehe… that sounds a bit greedy.";
                    aiGirl.AiChangeStats(NeedyType.Fun, 5);
                }
                else if (choose == 3)
                {
                    respond += "That’s… really important to me too.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Flirty, 5);
                }
            }
            if (value == 1)
            {
                if (choose == 1)
                {
                    respond += "That would make me a little sad…";
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                }
                else if (choose == 2)
                {
                    respond += "I’d want you to feel safe with me… really.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Happy, 5);
                }
                else if (choose == 3)
                {
                    respond += "N-No, please don’t do that…";
                    aiGirl.AiChangeStats(MoodType.Confident, -5);
                }
            }
            if (value == 2)
            {
                if (choose == 1)
                {
                    respond += "I feel closest to people during moments like those too…";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Happy, 5);
                    aiGirl.AiChangeStats(MoodType.Flirty, 5);
                }
                else if (choose == 2)
                {
                    respond += "Ignoring… that sounds lonely.";
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                }
                else if (choose == 3)
                {
                    respond += "Fighting doesn’t bring people closer…";
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                    aiGirl.AiChangeStats(MoodType.Angry, 5);
                }
            }
            if (value == 3)
            {
                if (choose == 1)
                {
                    respond += "I’d be happy to stay with you… really.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Flirty, 5);
                    aiGirl.AiChangeStats(MoodType.Happy, 5);
                }
                else if (choose == 2)
                {
                    respond += "That would be mean… I wouldn’t do that.";
                    aiGirl.AiChangeStats(MoodType.Angry, 5);
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                }
                else if (choose == 3)
                {
                    respond += "I’d never leave you alone like that.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, -1);
                    aiGirl.AiChangeStats(MoodType.Angry, 5);
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                }
            }
            if (value == 4)
            {
                if (choose == 1)
                {
                    respond += "I’m not very good at fighting…";
                    aiGirl.AiChangeStats(MoodType.Angry, 5);
                    aiGirl.AiChangeStats(MoodType.Happy, -5);
                }
                else if (choose == 2)
                {
                    respond += "… That sounds really nice. I hope we can.";
                    aiGirl.AiChangeStats(ProgressType.TrustBonding, 1);
                    aiGirl.AiChangeStats(MoodType.Flirty, 5);
                    aiGirl.AiChangeStats(MoodType.Happy, 5);
                }
                else if (choose == 3)
                {
                    respond += "No memories…? I don’t want that.";
                    aiGirl.AiChangeStats(MoodType.Sad, 5);
                }
            }
        }

        RespomdCanvas.enabled = true;
        TextLogs[4].GetComponent<TextMeshProUGUI>().text = respond;
        //wait player clikc or something
    }

    private void Update()
    {
        if (responded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RespomdCanvas.enabled = false;
                responded = false;
                //Debug.Log("Chat ended");
                Destroy(this.gameObject);
            }
        }
    }
}