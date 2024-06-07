using UnityEngine;

public class Global_timer : MonoBehaviour
{
    //全局计时器
    public static Global_timer instance;
    public float time;//已过时间
    public int Data = 0;//日期
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
