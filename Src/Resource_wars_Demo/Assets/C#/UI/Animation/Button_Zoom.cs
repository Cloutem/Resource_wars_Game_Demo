using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button_Zoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float speed = 1f;
    public Vector3 zoom =new Vector3(1.1f, 1.1f, 1f);
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
        transform.DOScale(new Vector3(1f,1f, 1f), speed);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(zoom, speed / 2);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), speed / 2);
    }
}
