using UnityEngine;

public class Global_timer : MonoBehaviour
{
    //ȫ�ּ�ʱ��
    public static Global_timer instance;
    public float time;//�ѹ�ʱ��
    public int Data = 0;//����
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (time>=120)
        {
            Data += 1;
            time = 0;
            return;
        }
        time += Time.deltaTime;
    }
}
