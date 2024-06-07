using Buffs;
using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Desktop_Data
    {
        public Dictionary<Card,Vector3> Card_Dict = new Dictionary<Card, Vector3>();//�����ϵĿ������� <����,��������>
        public List<Buff> Buff_List = new List<Buff>(); //��ǰ�����buff
        public Vector2 Size= new Vector2();//�����С(Ĭ��Ϊ1920x1080)
        public Desktop_Data Lift =null;//�����������������
        public Desktop_Data Rigth =null;//���ұ�������������
        public Desktop_Data Top = null;//���ϱ�������������
        public Desktop_Data Bottom = null;//���±�������������
        public Desktop_Data(Desktop_Data Lift = null, Desktop_Data Rigth = null, Desktop_Data Top = null, Desktop_Data Bottom=null) {
            this.Lift = Lift;
            this.Rigth = Rigth;
            this.Top = Top;
            this.Bottom = Bottom;
        }
    }
}

