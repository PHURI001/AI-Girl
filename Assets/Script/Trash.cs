using TMPro;
using UnityEngine;

public class Trash : Application
{
    public static int TrashValue;
    public TextMeshProUGUI Text;
    private void Start()
    {
        Text.text = TrashValue.ToString();
    }

    public override void AddTrash(int value)
    {
        TrashValue += value;
    }

    public override void RemoveTrash()
    {
        TrashValue = 0;
        Text.text = TrashValue.ToString();

        GameManager.Instance.DoActivity();
    }
}
