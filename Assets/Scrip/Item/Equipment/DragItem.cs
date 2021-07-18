using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform rect;
    CanvasGroup canvans_gr;
    Vector3 rect_original_pos;
    private void Awake()
    {
        rect = transform.Find("Place").GetComponent<RectTransform>();
        canvans_gr = transform.GetComponent<CanvasGroup>();
        

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        rect_original_pos = rect.transform.position;
        canvans_gr.alpha = 0.6f;
        canvans_gr.blocksRaycasts = false;
        Debug.Log("Begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
        Debug.Log("Ondrag drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvans_gr.alpha = 1;
        canvans_gr.blocksRaycasts = true;
        rect.transform.position = rect_original_pos;
    }
}
