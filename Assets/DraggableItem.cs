using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject mainCanvas;

    private void Awake()
    {
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("onBeginDrag");
        MouseData.tempItemBeingDragged = Instantiate(this.gameObject, mainCanvas.transform);
        MouseData.tempItemBeingDragged.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("onDrag");
        if (MouseData.tempItemBeingDragged != null) {
            RectTransform rectTransform = MouseData.tempItemBeingDragged.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("onEndDrag");
        //tempItemBeingDragged.transform.SetParent(parentAfterDragEnd);
    }

}

public static class MouseData
{
    public static GameObject tempItemBeingDragged = null;
    public static Transform mouseOverPanelTransform = null;
}
