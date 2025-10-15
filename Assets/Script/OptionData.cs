using System;
using UnityEngine;

[Serializable]
public class OptionData
{
    public string name;
    public Enum type;
    public int value;

    public OptionData(string name, Enum type, int value)
    {
        this.name = name;
        this.type = type;
        this.value = value;
    }
}
