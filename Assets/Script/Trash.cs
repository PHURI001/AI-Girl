using TMPro;
using UnityEngine;

public class Trash : Application
{
    public static int TrashValue;
    //change text in trash Canvas text
    public TextMeshProUGUI Text;

    public void AddTrash(int value)
    {
        //TrashValue += value;
        TrashValue += 1;
        Text.text = TrashValue.ToString();
    }

    public void TrashDelete()
    {
        TrashValue = 0;
        Text.text = TrashValue.ToString();
    }


}
