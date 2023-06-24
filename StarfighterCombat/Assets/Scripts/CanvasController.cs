using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas canvas;

    public void HideCanvas()
    {
        canvas.enabled = false;
    }

    public void ShowCanvas()
    {
        canvas.enabled = true;
    }
}
