using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string Name { get; set; }

    public int Money { get; set; }
    public GameObject MoneyUIText;

    public void ChangeMoney(int value)
    {
        Money += value;
        MoneyUIText.GetComponent<TextMeshProUGUI>().text = Money + "$";

        if (Money < 0)
        {
            // Trigger game over sequence
        }
    }

    public void BillCheck(int days)
    {
        if (days % 5 == 0)
        {
            //water amd electricity bill
        }

        if (days % 15 == 0)
        {
            //rent bill
        }
    }
}
