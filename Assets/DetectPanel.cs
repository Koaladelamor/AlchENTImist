using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseData.mouseOverPanelTransform = this.transform;
        Debug.Log(MouseData.mouseOverPanelTransform.gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseData.mouseOverPanelTransform = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
