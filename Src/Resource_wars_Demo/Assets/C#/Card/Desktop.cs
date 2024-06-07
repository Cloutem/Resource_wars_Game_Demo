using Data;
using System.Collections.Generic;
using UnityEngine;

public class Desktop : MonoBehaviour
{
    public static Desktop Instance;
    public List<Desktop_Data> desktop_list;
    public Desktop_Data Current;//当前的桌面数据
    public GameObject Bg;
    public GameObject Top;
    public GameObject Left;
    public GameObject Right;
    public GameObject Bottom;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Load_map_data();
        if(desktop_list == null)
        {
            Set_Map_Size(new Vector2(1920*2,1080*2));
        }
    }
    void Update()
    {

    }
    public void Load_map_data(List<Desktop_Data> desktop_list=null,Desktop_Data Current=null)
    {
        this.desktop_list = desktop_list;
        this.Current = Current;
    }
    public void Start_Map(Desktop_Data StartMap)//初始化地图
    {
        Current = StartMap;
        Set_Map_Size(Current.Size);
        foreach(var i in Current.Card_Dict.Keys)
        {

        }
    }
    public void Set_Map_Size(Vector2 Size)//设置桌面尺寸
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Size.x+60,Size.y+45);
        Bg.GetComponent<BoxCollider>().size = Size;
        Top.GetComponent<BoxCollider2D>().size = new Vector2(Size.x+60, Top.GetComponent<BoxCollider2D>().size.y);
        Bottom.GetComponent<BoxCollider2D>().size = new Vector2(Size.x+60, Bottom.GetComponent<BoxCollider2D>().size.y);
        Left.GetComponent<BoxCollider2D>().size = new Vector2(Size.y+45, Left.GetComponent<BoxCollider2D>().size.y);
        Right.GetComponent<BoxCollider2D>().size = new Vector2(Size.y+45, Right.GetComponent<BoxCollider2D>().size.y);
    }
}
