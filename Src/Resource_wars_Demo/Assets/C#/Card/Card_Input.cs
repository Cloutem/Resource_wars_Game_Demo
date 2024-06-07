using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Card_Input : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler, IBeginDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Top;
    public GameObject Bottom;
    public GameObject ls;
    public bool IsStack = true;//该卡是否可被堆叠
    public bool IsMove = true;//该卡是否能被移动
    public int Max = 10;
    private int TopsortingOrder;//顶部画布值
    private float P_x;//偏差x
    private float P_y;//偏差y
    private bool IsPlayer = false;//摄像机是否存在Player脚本
    private bool IsDown = false;//是否按下
    private bool IsDown_2 = false;//按下_2用于动画的控制
    private bool IsTD = false;//用于判断是否拖动
    private Card_Animation Card_Animation;
    private BoxCollider2D BoxCollider2D;
    private Rigidbody2D Rigidbody2D;
    [SerializeField]
    private Canvas Canvas;
    private void Awake()
    {

    }
    private void Start()
    {
        if (Camera.main.gameObject.GetComponent<CameraRay>() == null)
        {
            IsPlayer = false;
            Debug.LogWarning("主摄像机没有Player脚本,可能会影响程序的运行");
        }
        else
        {
            IsPlayer = true;
        }
        if (GetComponent<Card_Animation>() == null)
        {
            Card_Animation = gameObject.AddComponent<Card_Animation>();
        }
        else
        {
            Card_Animation = GetComponent<Card_Animation>();
        }
        if (GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        }
        else
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        if (GetComponent<BoxCollider2D>())
        {
            BoxCollider2D = GetComponent<BoxCollider2D>();
        }
        else
        {
            BoxCollider2D = GetComponent<BoxCollider2D>();
        }
    }
    private void Update()
    {
        if (IsStack)
        {
            //牌组跟随控制
            if (Bottom != null && !IsDown)
            {
                transform.position = Vector3.Lerp(transform.position, Bottom.transform.position + new Vector3(0, -25f * transform.localScale.y, 0), Time.deltaTime * 30);
            }
        }
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)//拖动开始
    {
        IsTD = true;
        if (IsStack)
        {
            if (Bottom != null)
            {
                Bottom.GetComponent<BoxCollider2D>().enabled = true;
            }
        }

    }

    void IDragHandler.OnDrag(PointerEventData eventData)//拖动
    {
        //跟随鼠标移动
        if (IsPlayer&&IsMove)
        {
            transform.DOMove(new Vector2(CameraRay.Instance.hit.point.x + P_x, CameraRay.Instance.hit.point.y + P_y), 0.1f);
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)//拖动结束
    {
        
        if (IsStack)
        {
            if (ls != null)
            {
                if (ls.GetComponent<Card_Input>().IsStack)
                {
                    if (Bottom != null)
                    {
                        Bottom.GetComponent<Card_Input>().Top = null;
                        Bottom = null;
                    }
                    Start_sort_Value(0);
                    TopsortingOrder = GetTop().GetComponent<Card_Input>().Canvas.sortingOrder + 1;
                    Bottom = ls;
                    Bottom.GetComponent<Card_Input>().Top = gameObject;
                    Bottom.GetComponent<Card_Input>().BoxCollider2D.enabled = false;
                    Start_sort_Value(0);
                    if (Bottom.GetComponent<Card_Input>().Canvas.sortingOrder+1> Max || ((Bottom.GetComponent<Card_Input>().Canvas.sortingOrder + 1) + (TopsortingOrder) > Max))//最大堆叠限制
                    {
                        Bottom.GetComponent<BoxCollider2D>().enabled = true;
                        Bottom.GetComponent<Card_Input>().Top = null;
                        Bottom = null;
                    }
                }
            }
            else if (Bottom != null)
            {
                Bottom.GetComponent<BoxCollider2D>().enabled = true;
                Bottom.GetComponent<Card_Input>().Top = null;
                Bottom = null;
            }
            else if (Bottom == null && Top != null)
            {
                Start_sort_Value(0);
            }
            else if (Bottom == null && Top == null)
            {
                BoxCollider2D.enabled = true;
                Canvas.sortingOrder = 0;
            }
            //
            if (Top != null)
            {
                Top_List_IsDown(false);
                Card_End();
            }
            ls = null;
            BoxCollider2D.isTrigger = false;
            Start_sort_Value(0);
        }
        IsTD = false;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)//鼠标按下
    {
        if (IsStack)
        {
            IsDown = true;
            if (Top == null)
            {
                BoxCollider2D.enabled = true;//启动当前的碰撞器
            }
            else
            {
                Top_List_IsDown(true);
            }
            BoxCollider2D.isTrigger = true;//启动为触发器(用于移动卡牌时取消碰撞)
            if (Top != null)
            {
                Card_Begin();
            }
            if (IsPlayer)//处理卡牌移动偏移
            {
                P_x = transform.localPosition.x - CameraRay.Instance.hit.point.x;
                P_y = transform.localPosition.y - CameraRay.Instance.hit.point.y;
            }
            Start_sort_Value(11);
        }

    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)//鼠标松开
    {
        //设置参数以及碰撞检测
        if (IsStack)
        {
            IsDown = false;
            if (!IsTD)
            {
                if (Top != null)
                {
                    Top_List_IsDown(false);
                    Card_End();
                }
                
                ls = null;
                BoxCollider2D.isTrigger = false;
                Start_sort_Value(0);
            }
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)//鼠标进入
    {
        //用于控制动画
        if (IsMove)
        {
            if (!IsDown)
            {
                if (!IsDown_2)
                {
                    if (Top == null)
                    {
                        Card_Animation.Lift(true);
                    }
                    else
                    {
                        Top_List_Lift_Animation(true);
                    }
                }
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)//鼠标退出
    {
        //用于控制动画
        if (IsMove)//是否移动
        {
            if (!IsDown)//是否点击_1
            {
                if (!IsDown_2)//是否点击_2
                {
                    if (Top == null)
                    {
                        Card_Animation.Lift(false);
                    }
                    else
                    {
                        Top_List_Lift_Animation(false);
                    }
                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsStack)
        {
            if(collision.tag.Equals("Card"))
                ls = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsStack)
        {
            ls = null;
        }
    }
    public void Card_Begin()//仅启动起点牌
    {
        if (Bottom == null)
        {
            BoxCollider2D.enabled = true;
        }
        if (Top == null)
        {
            return;
        }
        Top.GetComponent<Card_Input>().Card_Begin();
        Top.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Card_End()//仅启动末尾牌
    {
        if (Top == null)
        {
            BoxCollider2D.enabled = true;
            return;
        }
        BoxCollider2D.enabled = false;
        Top.GetComponent<Card_Input>().Card_End();
    }
    public void Start_sort_Value(int index)//初始化显示排序顺序
    {
        if (Bottom == null)
        {
            Canvas.sortingOrder = index;
        }
        else
        {
            Canvas.sortingOrder = Bottom.GetComponent<Card_Input>().Canvas.sortingOrder + 1;
        }
        if (Top == null)
        {
            return;
        }
        Top.GetComponent<Card_Input>().Start_sort_Value(index);
    }
    public void Top_List_Lift_Animation(bool istf)
    {
        Card_Animation.Lift(istf);
        if (Top == null)
            return;
        Top.GetComponent<Card_Input>().Top_List_Lift_Animation(istf);

    }//链式抬起动画
    public void Top_List_IsDown(bool istf)
    {
        IsDown_2 = istf;
        if (Top == null)
            return;
        Top.GetComponent<Card_Input>().Top_List_IsDown(istf);
    }//链式设置是否点击参数
    public GameObject GetTop()
    {
        if(Top==null && Bottom == null)
        {
            return gameObject;
        }
        if (Top == null && Bottom!=null)
        {
            return gameObject;
        }
        return Top.GetComponent<Card_Input>().GetTop();
    }//获取顶部卡牌
    public void Lock_Vector3(bool istf)
    {
        if (istf)
        {
            Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            Rigidbody2D.constraints = RigidbodyConstraints2D.None;
            Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}