using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Tool;
using Unity.VisualScripting;
public class Test : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    public GameObject player;
    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    void Start()
    {
    }
    void Update()
    {
        if(player!=null)
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,player.transform.position+new Vector3(0, -250, gameObject.transform.position.z),Time.deltaTime);
    }

}
