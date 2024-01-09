using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        ShiftCanvas(-100f);
    }

    public void ShowCanvas()
    {
        ShiftCanvas(100f);
        canvas.enabled = true;
    }
    private void ShiftCanvas(float len)
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector3 currentPosition = canvasRect.anchoredPosition;
        currentPosition.x -= len;
        canvasRect.anchoredPosition = currentPosition;
    }
}
