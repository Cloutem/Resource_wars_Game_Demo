using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Tool;
using JetBrains.Annotations;

public class Player_Input : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public float Max_Range=250;
    public GameObject two;
    public GameObject three;
    public LineRenderer lineRenderer;
    public LineRenderer lineRenderer_2;
    public Vector3 Begin;
    public Vector3 End;
    public Player Player;
    void Start()
    {
        if(GetComponent<Player>() == null)
        {
            gameObject.AddComponent<Player>();
        }
        else
        {
            Player = GetComponent<Player>();
        }
        Card_Tool.Draw_a_circle(Max_Range,lineRenderer);
        Card_Tool.Draw_a_circle(Max_Range*1.2f, lineRenderer_2,3);
        lineRenderer.enabled = false;
    }
    void Update()
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
        End = CameraRay.Instance.hit.point;
        two.transform.position = End;
        three.transform.localPosition = -( two.transform.position- transform.position).normalized*Max_Range;
        if ((transform.position - End).magnitude > Max_Range)
        {
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }  
        else
        {
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        lineRenderer.enabled = true;
        two.SetActive(true);
        three.SetActive(true);
        Begin = transform.position;
        two.transform.position = Begin;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if ((transform.position - End).magnitude <= Max_Range)//发射
        {
            Launch();
        }
        End = Vector3.zero;
        Begin = Vector3.zero;
        lineRenderer.enabled = false;
        two.SetActive(false);
        three.SetActive(false);
    }
    public void Launch()//卡牌发射时执行的方法
    {
        transform.GetComponent<Rigidbody2D>().AddForce(((Begin - End).normalized * (Begin - End).magnitude) * 100);
    }
    public void Set_Max_Range(float range)
    {
        Max_Range = range;
        Card_Tool.Draw_a_circle(Max_Range, lineRenderer);
        Card_Tool.Draw_a_circle(Max_Range * 1.2f, lineRenderer_2, 3);
    }
}
