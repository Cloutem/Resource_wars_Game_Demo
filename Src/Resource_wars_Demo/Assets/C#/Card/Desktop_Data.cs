using Buffs;
using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Desktop_Data
    {
        public Dictionary<Card,Vector3> Card_Dict = new Dictionary<Card, Vector3>();//桌面上的卡牌数据 <卡牌,卡牌坐标>
        public List<Buff> Buff_List = new List<Buff>(); //当前桌面的buff
        public Vector2 Size= new Vector2();//桌面大小(默认为1920x1080)
        public Desktop_Data Lift =null;//与左边桌面数据连接
        public Desktop_Data Rigth =null;//与右边桌面数据连接
        public Desktop_Data Top = null;//与上边桌面数据连接
        public Desktop_Data Bottom = null;//与下边桌面数据连接
        public Desktop_Data(Desktop_Data Lift = null, Desktop_Data Rigth = null, Desktop_Data Top = null, Desktop_Data Bottom=null) {
            this.Lift = Lift;
            this.Rigth = Rigth;
            this.Top = Top;
            this.Bottom = Bottom;
        }
    }
}

