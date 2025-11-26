using TMPro;
using UnityEngine;

public class Trash : Application
{
    public static int TrashValue;
    //change text in trash Canvas text
    public TextMeshProUGUI Text;
    private void Start()
    {
        Text.text = TrashValue.ToString();
    }

    public void AddTrash(int value)
    {
        //TrashValue += value;
        TrashValue += value;
    }

    public void TrashDelete()
    {
        TrashValue = 0;
        Text.text = TrashValue.ToString();

        //add activity in game manager
        GameManager.Instance.DoActivity();
    }
}
