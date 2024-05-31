using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Card_Rotating : MonoBehaviour, IPointerDownHandler
{
    public GameObject Card_front;
    public GameObject Card_verso;
    public bool is_front = true;
    public bool istf_Run = true;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (istf_Run)
        {
            if (!is_front)
            {
                is_front = true;
                istf_Run = false;
                Card_verso.transform.DORotate(new Vector3(0, 90, 0), 1f).OnComplete(() => { Card_front.transform.DORotate(new Vector3(0, 0, 0), 1f).OnComplete(() => { istf_Run = true; }); });
            }
            else if (is_front)
            {
                is_front = false;
                istf_Run = false;
                Card_front.transform.DORotate(new Vector3(0, 90, 0), 1f).OnComplete(() => { Card_verso.transform.DORotate(new Vector3(0, 0, 0), 1f).OnComplete(() => { istf_Run = true; }); });

            }
        }
    }

    void Start()
    {
        if (is_front)
        {
            Card_verso.transform.DORotate(new Vector3(0, 90, 0), 0);
            Card_front.transform.DORotate(new Vector3(0, 0, 0), 0);
        }
        else
        {
            Card_verso.transform.DORotate(new Vector3(0, 0, 0), 0);
            Card_front.transform.DORotate(new Vector3(0, 90, 0), 0);
        }
    }
}
