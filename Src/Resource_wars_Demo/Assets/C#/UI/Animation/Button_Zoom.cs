using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button_Zoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float speed = 0.5f;
    Vector3 Start_S;
    public Vector3 zoom =new Vector3(1.1f, 1.1f, 1f);
    private void Start()
    {
        Start_S = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.GetComponent<Shadow>() != null)
        {
            transform.GetComponent<Shadow>().enabled = false;
        }
        transform.DOScale(zoom, speed);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.GetComponent<Shadow>() != null)
        {
            transform.GetComponent<Shadow>().enabled = true;
        }
        transform.DOScale(Start_S, speed);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(zoom, speed / 2);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(Start_S, speed / 2);
    }
}
