using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
Cuando le agregas un CanvasGroup A una Imagen entonces  
las areas/objetos debajo de la carta  pueden detectarla 
(a la misma carta) como si fuese un onTriggerEnter. Pero el evento 
se llama onDrop y el atributo que recibe es la misma carta, 
entonces pudes colocar la carta en el medio del area.
*/
public class Dropable : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop "+transform.position);
        if(eventData.pointerDrag != null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<Dragable>().place = "dropable";
            
        }
    }
}
