using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card_Animation : MonoBehaviour
{
    //该脚本用于控制卡牌动画是一个卡牌的效果库
    [SerializeField]
    private Transform Plane;
    [SerializeField]
    private GameObject Front;//正面
    [SerializeField]
    private GameObject Back;//背面
    [SerializeField]
    private Shadow shadow;//阴影
    [SerializeField]
    private bool isLift = true;//是否抬起(true/false<否/是>)
    private bool Liftstop = true; //翻面是否停止
    [Header("正反面(true/false)")]
    public bool istf = false;//用于判断正面还是反面
    public bool Dynamic_shadows = true;//是否启用动态阴影
    private Camera Camera;//用于存储主摄像机
    private void Start()//初始化
    {

        if (Plane == null)
        {
            Debug.LogError("请将Plane添加进该脚本");
        }

        if (Camera.main == null)
        {
            Debug.LogError("请添加主摄像机");
        }
        else
        {
            Camera = Camera.main;
        }
        if (Front.activeInHierarchy)
        {
            Back.SetActive(false);
            istf = true;
        }
        else
        {
            Back.SetActive(true);
            Front.SetActive(false);
            istf = false;
        }
    }
    private void Update()
    {
        if (Dynamic_shadows)
        {
            shadow.effectDistance = Vector2.Lerp(shadow.effectDistance, (Camera.transform.position - transform.position).normalized * 10, Time.deltaTime * 10);//阴影过渡
        }
        if (!isLift)
        {
            Plane.transform.position = Vector2.Lerp(Plane.position, transform.position + new Vector3(0,10f,0), Time.deltaTime * 10);
        }
        else
        {
            Plane.transform.position = Vector2.Lerp(Plane.position, transform.position, Time.deltaTime * 10);
        }
    }//实时计算动态阴影
    public bool Set_istf_Counter(bool istf)
    {
        if (istf)
        {
            Back.SetActive(true);
            Front.SetActive(false);
            return false;
        }
        else
        {
            Back.SetActive(false);
            Front.SetActive(true);
            return true;
        }
    }//取反工具
    public void Turn_over(float speed = 0.1f)//反转切换
    {
        if (Liftstop)
        {
            Liftstop = false;
            if (!isLift)
            {
                if (istf)
                {
                    Plane.DORotate(new Vector3(Plane.eulerAngles.x, 90, Plane.eulerAngles.z), speed).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        istf = Set_istf_Counter(istf);
                        Plane.DORotate(new Vector3(Plane.eulerAngles.x, 180, Plane.eulerAngles.z), speed).OnComplete(() => { Liftstop = true; });
                    });
                }
                else
                {
                    Plane.DORotate(new Vector3(Plane.eulerAngles.x, 90, Plane.eulerAngles.z), speed).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        istf = Set_istf_Counter(istf);
                        Plane.DORotate(new Vector3(Plane.eulerAngles.x, 0, Plane.eulerAngles.z), speed).OnComplete(() => { Liftstop = true; });
                    });
                }
            }
            else
            {
                if (istf)
                {
                    Plane.DOMove(transform.position + new Vector3(0, 10f, 0), speed * 2).OnComplete(() =>
                    {
                        Plane.DORotate(new Vector3(Plane.eulerAngles.x, 90, Plane.eulerAngles.z), speed).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            istf = Set_istf_Counter(istf);
                            Plane.DORotate(new Vector3(Plane.eulerAngles.x, 180, Plane.eulerAngles.z), speed).OnComplete(() =>
                            {
                                Plane.DOMove(transform.position, speed * 2).OnComplete(() => { Liftstop = true; });
                            });
                        });
                    });

                }
                else
                {
                    Plane.DOMove(transform.position + new Vector3(0, 10f, 0), speed).OnComplete(() =>
                    {
                        Plane.DORotate(new Vector3(Plane.eulerAngles.x, 90, Plane.eulerAngles.z), speed).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            istf = Set_istf_Counter(istf);
                            Plane.DORotate(new Vector3(Plane.eulerAngles.x, 0, Plane.eulerAngles.z), speed).OnComplete(() =>
                            {
                                Plane.DOMove(transform.position, speed).OnComplete(() => { Liftstop = true; });
                            });
                        });
                    });

                }
            }
        }
        
    }
    public void Lift(bool istf, float speed = 0.1f)//卡片抬起效果用于取固定效果
    {
        if (istf)
        {
            isLift = false;
        }
        else
        {
            isLift = true;
        }
    }
    public void Lift(float speed = 0.1f)//卡片抬起效果用于取相反效果
    {
        if (isLift)
        {
            isLift = false;
        }
        else
        {
            isLift = true;
        }
    }
}
