using Skills;
namespace Cards
{
    public enum Type
    {
        Item,//��Ʒ
        Biotic,//����
        NPC,//NPC
        ProP,//����
        Outfit,//װ��
        Arm,//����
        Function,//����
        Resource//��Դ
    }
    public interface Card//����״̬��
    {
        public int Id { get; set; }//����Id
        public string Name { get; set; }//��������
        public Type Type { get; set; }//��������
        public string Describe { get; set; }//��������
        public Skill Effect { get; set; }//����Ч��
        public void Start_Card();//��ʼ������
        public void Enter();//���뿨�ƺ�ִ�еķ���
        public void Run();//����ִ���еķ���
        public void Exit();//�����˳��ķ���

    }
}

