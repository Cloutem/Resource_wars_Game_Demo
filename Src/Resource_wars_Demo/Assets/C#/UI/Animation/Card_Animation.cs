using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card_Animation : MonoBehaviour
{
    //�ýű����ڿ��ƿ��ƶ�����һ�����Ƶ�Ч����
    [SerializeField]
    private Transform Plane;
    [SerializeField]
    private GameObject Front;//����
    [SerializeField]
    private GameObject Back;//����
    [SerializeField]
    private Shadow shadow;//��Ӱ
    [SerializeField]
    private bool isLift = true;//�Ƿ�̧��(true/false<��/��>)
    private bool Liftstop = true; //�����Ƿ�ֹͣ
    [Header("������(true/false)")]
    public bool istf = false;//�����ж����滹�Ƿ���
    public bool Dynamic_shadows = true;//�Ƿ����ö�̬��Ӱ
    private Camera Camera;//���ڴ洢�������
    private void Start()//��ʼ��
    {

        if (Plane == null)
        {
            Debug.LogError("�뽫Plane��ӽ��ýű�");
        }

        if (Camera.main == null)
        {
            Debug.LogError("������������");
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
            shadow.effectDistance = Vector2.Lerp(shadow.effectDistance, (Camera.transform.position - transform.position).normalized * 10, Time.deltaTime * 10);//��Ӱ����
        }
        if (!isLift)
        {
            Plane.transform.position = Vector2.Lerp(Plane.position, transform.position + new Vector3(0,10f,0), Time.deltaTime * 10);
        }
        else
        {
            Plane.transform.position = Vector2.Lerp(Plane.position, transform.position, Time.deltaTime * 10);
        }
    }//ʵʱ���㶯̬��Ӱ
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
    }//ȡ������
    public void Turn_over(float speed = 0.1f)//��ת�л�
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
    public void Lift(bool istf, float speed = 0.1f)//��Ƭ̧��Ч������ȡ�̶�Ч��
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
    public void Lift(float speed = 0.1f)//��Ƭ̧��Ч������ȡ�෴Ч��
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
