using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string Name { get; set; }

    public float Money { get; set; }
    public GameObject MoneyUIText;

    EndingChecker endingChecker;

    private void Start()
    {
        endingChecker = FindAnyObjectByType<EndingChecker>();
    }
    public void ChangeMoney(float value, string text)
    {
        Money += value;
        MoneyUIText.GetComponent<TextMeshProUGUI>().text = Money + "$";

        if (Money < 0)
        {
            // Trigger game over
            endingChecker.Checking(value, text);
        }
    }

    float rent = 300;
    float otherPay = 50;
    float multiplyPay = 1.5f;
    public void BillCheck(int days)
    {
        if (days % 5 == 0)
        {
            //water amd electricity bill
            if (days != 5)
            {
                otherPay = otherPay * multiplyPay;
            }
            ChangeMoney(otherPay, "water amd electricity bill");
        }

        if (days % 15 == 0)
        {
            //rent bill
            ChangeMoney(rent, "rent bill");
        }
    }
}
