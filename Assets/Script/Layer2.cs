using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public abstract class Layer2 : Application
{
    public AIGirl aiGirl;

    public void OptionAIHandler(Enum valueType ,int value)
    {
        aiGirl.OptionAIHandler(valueType, value);
    }
}