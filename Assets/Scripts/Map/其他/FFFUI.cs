using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FFFUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,IDragHandler,IEndDragHandler
{
    [Header("mµã»÷")]
    public UnityEvent u1;
    [Header("mÍÏ×§")]
    public bool follow_m = false;
    public bool FuWui = false;
    public UnityEvent u2;
    [Header("mÒÆÈë")]
    public UnityEvent u3;
    [Header("mÒÆ³ö")]
    public UnityEvent u4;

    Vector3 Vector3;
    Vector3 StartPosition;
    public void OnDrag(PointerEventData eventData)
    {
        u2.Invoke();
        if (follow_m) GetComponent<RectTransform>().position = Input.mousePosition + Vector3;
        print("drop");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (FuWui) GetComponent<RectTransform>().position = StartPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        u1.Invoke();
        Vector3 = GetComponent<RectTransform>().position - Input.mousePosition;
        StartPosition = GetComponent<RectTransform>().position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        u3.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        u4?.Invoke();
    }
}
