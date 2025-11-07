using TMPro;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public static int TrashValue;
    //change text in trash Canvas text
    public TextMeshProUGUI Text;

    void Awake()
    {
        Text.text = TrashValue.ToString();
    }

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
