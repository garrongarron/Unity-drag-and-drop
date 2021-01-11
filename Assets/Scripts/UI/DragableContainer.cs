using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableContainer : MonoBehaviour,
        IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!Dragable.isDragin){
            transform.SetSiblingIndex(1);
        }
    }
}
