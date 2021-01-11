﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, 
        IPointerDownHandler,
        IBeginDragHandler,
        IEndDragHandler,
        IDragHandler,
        ///////////////////
        IPointerEnterHandler, 
        IPointerExitHandler
{
    private RectTransform rectTransform;

    [SerializeField]
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 position2;
    public string place;
    public static bool isDragin = false;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        place = "";
        // GetComponent<RectTransform>().anchoredPosition 
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("OnPointerDown "+transform.position);
        position2 = GetComponent<RectTransform>().anchoredPosition;
        isDragin = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragin = false;
        Debug.Log("OnEndDrag "+transform.position);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if(place != "dropable"){
            rectTransform.anchoredPosition = position2;
        }
        place = "";
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor ;
    }

    ///////////////////////////////////////
    ///////////////////////////////////////
    ///////////////////////////////////////
    ///////////////////////////////////////
    public bool isOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("Mouse enter");
        isOver = true;
        // rectTransform.localScale  *= 1.5f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("Mouse exit");
        isOver = false;
        // rectTransform.localScale  /= 1.5f;
    }

}