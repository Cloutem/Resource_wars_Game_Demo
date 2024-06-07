using System.Collections.Generic;
using Cards;
namespace Backpacks
{
    public class Backpack
    {
        List<Card> cards = new List<Card>();//存储卡片的列表
        List<Card> cards_trash_can = new List<Card>();//卡片垃圾桶,删除缓存
        public Backpack() {
            init();
        }
        public virtual void init()//初始化的操作
        {
            
        }
        public virtual void Operate_execute()//修改背包值时执行的操作
        {

        }
        public virtual void BackPackNull()//当背包为空时执行的操作
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

