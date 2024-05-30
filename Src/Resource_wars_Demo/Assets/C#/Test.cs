using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using UnityEngine.EventSystems;
public class Test : MonoBehaviour,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("´¥·¢");
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
