using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasWindowController : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    public RectTransform windowPanel;
    public RectTransform headerBar;

    public void DeleteWindow()
    {
        if (canvas != null)
            Destroy(canvas.gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (headerBar != null && RectTransformUtility.RectangleContainsScreenPoint(headerBar, eventData.position, eventData.pressEventCamera))
        {
            Vector2 move = eventData.delta / canvas.scaleFactor;

            if (windowPanel != null)
                windowPanel.anchoredPosition += move;
        }
    }
}
