using System.Collections.Generic;
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
        SpawnUI(Instantiate(uiCanvasPrefab[0]));
    }
    public void VsCode()
    {
        SpawnUI(Instantiate(uiCanvasPrefab[1]));
    }
    public void Trash()
    {
        SpawnUI(Instantiate(uiCanvasPrefab[2]));
    }
    public void Airi()
    {
        SpawnUI(Instantiate(uiCanvasPrefab[3]));
    }
    public void Notflex()
    {
        SpawnUI(Instantiate(uiCanvasPrefab[4]));
    }
    public void Chroma()
    {
        SpawnUI(Instantiate(uiCanvasPrefab[5]));
    }
}
