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

    public void AddTrash(int value)
    {
        TrashValue += value;
    }

    public void TrashDelete()
    {
        TrashValue = 0;
        Text.text = TrashValue.ToString();

        GameManager.Instance.DoActivity();
    }
}
