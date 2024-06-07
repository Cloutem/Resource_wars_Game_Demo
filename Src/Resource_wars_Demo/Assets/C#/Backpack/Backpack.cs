using System.Collections.Generic;
using Cards;
namespace Backpacks
{
    public class Backpack
    {
        List<Card> cards = new List<Card>();//�洢��Ƭ���б�
        List<Card> cards_trash_can = new List<Card>();//��Ƭ����Ͱ,ɾ������
        public Backpack() {
            init();
        }
        public virtual void init()//��ʼ���Ĳ���
        {
            
        }
        public virtual void Operate_execute()//�޸ı���ֵʱִ�еĲ���
        {

        }
        public virtual void BackPackNull()//������Ϊ��ʱִ�еĲ���
        {

        }
        public Card Add(Card card)
        {
            cards.Add(card);
            Operate_execute();
            return card;
        }
        public Card Remove(Card card)
        {
            cards.Remove(card);
            Operate_execute();
            if (cards.Count == 0)
                BackPackNull();
            return card;
        }
        public void Find(Card card)
        {
            cards.Find(x => x.Equals(card));
        }
        public List<Card> Clear()
        {
            cards_trash_can.Clear();
            foreach (Card card in cards)
            {
                cards.Remove(card);
                cards_trash_can.Add(card);
            }
            Operate_execute();
            BackPackNull();
            return cards_trash_can;
        }
        public List<Card> Find_trash_can()
        {
            return cards_trash_can;
        }
    }
}

