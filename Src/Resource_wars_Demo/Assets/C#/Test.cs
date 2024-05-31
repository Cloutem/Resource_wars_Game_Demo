using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Tool;
public class Test : MonoBehaviour,IPointerDownHandler,IDragHandler
{
    public GameObject a;
    public bool istf = false;
    public Card_Tool tool = new Card_Tool();
    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonRun();
    }

    void Start()
    {
    }
    void Update()
    {
        if (istf)
        {
            tool.LookAt(gameObject, a, -1);
        }
    }
    public void ButtonRun()
    {
        istf = false;
        transform.DOMove(a.transform.position, 1f).OnComplete(() => { transform.DORotate(new Vector3(0,0,0),0.5f); }) ;
    }
}
