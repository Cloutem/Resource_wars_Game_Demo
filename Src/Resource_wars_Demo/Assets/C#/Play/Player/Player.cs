using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    [Header("属性上限")]
    public float Health_Max=100;
    public float Satiety_Max=100;
    public float Thirst_Max = 100;
    public float Weight_Max = 100;
    public float Physical_Max = 100;
    [Header("基本属性")]
    private float Health;//生命值
    private float Satiety;//饱食度
    private float Thirst;//口渴度
    private float Weight;//重量
    private float Physical;//体力
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Start_Attribute(float Health=100,float Satiety = 100,float Thirst = 100,float Weight = 100,float Physical = 100)
    {
        this.Health = Health;
        this.Satiety = Satiety;
        this.Thirst = Thirst;
        this.Weight = Weight;
        this.Physical = Physical;
    }
    public float Set_Health(float Value)
    {
        Health += Value;
        if (Health>=Health_Max)
        {
            Health = Health_Max;
            return Health_Max;
        }
        if (Health <= 0)
        {
            Health -= Value;
            return Health;
        }
        return Health;
    }//生命值
    public float Set_Satiety(float Value)
    {
        Satiety += Value;
        if (Satiety >= Satiety_Max)
        {
            Satiety = Satiety_Max;
            return Satiety_Max;
        }
        if (Satiety <= 0)
        {
            Satiety -=Value;
            return Satiety;
        }
        return Satiety;
    }//饱食度
    public float Set_Weight(float Value)
    {
        Weight += Value;
        if (Weight >= Weight_Max)
        {
            Weight = Weight_Max;
            return Weight_Max;
        }
        if (Weight <= 0)
        {
            Weight -=Value;
            return Weight;
        }
        return Weight;
    }//重量
    public float Set_Thirst(float Value)
    {
        Thirst += Value;
        if (Thirst >= Thirst_Max)
        {
            Thirst = Thirst_Max;
            return Thirst_Max;
        }
        if (Thirst <= 0)
        {
            Thirst -=Value;
            return Thirst;
        }
        return Thirst;
    }//口渴度
    public float Set_Physical(float Value)
    {
        Physical += Value;
        if (Physical >= Physical_Max)
        {
            Physical = Physical_Max;
            return Physical_Max;
        }
        if (Physical <= 0)
        {
            Physical -= Value;
            return Physical;
        }
        return Physical;
    }//体力
}
