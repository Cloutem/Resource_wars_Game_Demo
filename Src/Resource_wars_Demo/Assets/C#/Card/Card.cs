using Skills;
namespace Cards
{
    public enum Type
    {
        Item,//物品
        Biotic,//生物
        NPC,//NPC
        ProP,//道具
        Outfit,//装备
        Arm,//武器
        Function,//功能
        Resource//资源
    }
    public interface Card//卡牌状态机
    {
        public int Id { get; set; }//卡牌Id
        public string Name { get; set; }//卡牌名称
        public Type Type { get; set; }//卡牌类型
        public string Describe { get; set; }//卡牌描述
        public Skill Effect { get; set; }//卡牌效果
        public void Start_Card();//初始化卡牌
        public void Enter();//进入卡牌后执行的方法
        public void Run();//卡牌执行中的方法
        public void Exit();//卡牌退出的方法

    }
}

