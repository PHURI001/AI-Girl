using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCanvasUI : MonoBehaviour
{
    public List<GameObject> uiCanvasPrefab;

    public void SpawnUI(GameObject ui)
    {
        if (uiCanvasPrefab != null)
        {
            RectTransform rect = ui.GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.SetParent(null);
                rect.localPosition = Vector3.zero;
                rect.localScale = Vector3.one;
            }

            Canvas canvasComp = ui.GetComponent<Canvas>();
            if (canvasComp != null)
            {
                canvasComp.renderMode = RenderMode.ScreenSpaceOverlay;
                canvasComp.sortingOrder = 100;
            }
        }
    }

    public void MyComputer()
    {
        if (FindFirstObjectByType<MyComputer>() == null && FindFirstObjectByType<Chat>() == null)
        {
            SpawnUI(Instantiate(uiCanvasPrefab[0]));
        }
    }

    public CodeQuest CodeQuest;
    public void VsCode()
    {
        if (FindFirstObjectByType<CodeQuest>() == null && !CodeQuest.Worked && FindFirstObjectByType<Chat>() == null)
        {
            SpawnUI(Instantiate(uiCanvasPrefab[1]));
        }
    }
    public void Trash()
    {
        if (FindFirstObjectByType<Trash>() == null && FindFirstObjectByType<Chat>() == null)
        {
            SpawnUI(Instantiate(uiCanvasPrefab[2]));
        }
    }
    public void Airi()
    {
        if (FindFirstObjectByType<Airi>() == null && FindFirstObjectByType<Chat>() == null)
        {
            SpawnUI(Instantiate(uiCanvasPrefab[3]));
        }
    }
    public void Notflex()
    {
        if (FindFirstObjectByType<Notflex>() == null && FindFirstObjectByType<Chat>() == null)
        {
            SpawnUI(Instantiate(uiCanvasPrefab[4]));
        }
    }
    public void Chroma()
    {
        if (FindFirstObjectByType<Chroma>() == null && FindFirstObjectByType<Chat>() == null)
        {
            SpawnUI(Instantiate(uiCanvasPrefab[5]));
        }
    }
}
