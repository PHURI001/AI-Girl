using UnityEngine;

public class SpawnCanvasUI : MonoBehaviour
{
    public GameObject uiCanvasPrefab;

    public void SpawnUI()
    {
        if (uiCanvasPrefab != null)
        {
            GameObject newUI = Instantiate(uiCanvasPrefab);

            RectTransform rect = newUI.GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.SetParent(null);
                rect.localPosition = Vector3.zero;
                rect.localScale = Vector3.one;
            }

            Canvas canvasComp = newUI.GetComponent<Canvas>();
            if (canvasComp != null)
            {
                canvasComp.renderMode = RenderMode.ScreenSpaceOverlay;
                canvasComp.sortingOrder = 100;
            }
        }
    }
}
