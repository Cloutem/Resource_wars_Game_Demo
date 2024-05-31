using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public class Button_Rotating : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float speed = 1f;
    public Vector3 Rotatin = new Vector3(0,0,180);
    public Vector3 OnClick_Zoom = new Vector3(1.1f,1.1f,1);

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.GetComponent<Shadow>() != null)
        {
            transform.GetComponent<Shadow>().enabled = false;
        }
        transform.DORotate(Rotatin, speed);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.GetComponent<Shadow>() != null)
        {
            transform.GetComponent<Shadow>().enabled = true;
        }
        transform.DORotate(new Vector3(0, 0, 0), speed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(OnClick_Zoom, speed/2);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), speed/2);
    }
}
