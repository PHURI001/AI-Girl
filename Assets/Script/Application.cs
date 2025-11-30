using System;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public abstract class Application : MonoBehaviour, IDragHandler
{
    protected AIGirl aiGirl;

    Canvas canvas;
    RectTransform windowPanel;
    RectTransform headerBar;

    [Obsolete]
    protected virtual void Awake()
    {
        aiGirl = FindObjectOfType<AIGirl>();
        canvas = GetComponentInParent<Canvas>();
        windowPanel = GetComponent<RectTransform>();
        headerBar = (RectTransform)GetComponent<RectTransform>().FindChild("TopBar");
    }

    protected void aiChangeStats(Enum valueType ,int value)
    {
        aiGirl = FindAnyObjectByType<AIGirl>();
        aiGirl.AiChangeStats(valueType, value);
    }

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