using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAutoScale : MonoBehaviour
{
    public CanvasScaler canvasScaler;
    public RectTransform canvasRect;
    public float delay;

    private void Reset()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        canvasRect= GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        if (delay > 0) StartCoroutine(Delay());
        else RescaleElements();
    }

    public virtual void RescaleElements()
    {
#if UNITY_EDITOR
        if (canvasRect == null) canvasRect = GetComponent<RectTransform>();
        if ((float)canvasRect.rect.width / (float)canvasRect.rect.height >= 0.6f)
            canvasScaler.matchWidthOrHeight = 1;
        else canvasScaler.matchWidthOrHeight = 0;
#else
        if ((float)Screen.width / (float)Screen.height >= 0.6f)
            canvasScaler.matchWidthOrHeight = 1;
        else canvasScaler.matchWidthOrHeight = 0;
#endif
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        RescaleElements();
    }
}
