using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Title_Shake : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOShakeRotation(1f, new Vector3(10, 10, 10), 3, 20, false);
    }

}
