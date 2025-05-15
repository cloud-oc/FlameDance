using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite stasprite;
    public Sprite endsprite;
    Animator animator;
    public bool haveAnimator = true;
    public UnityEvent unityEvent;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(haveAnimator) animator.SetBool("in", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (haveAnimator) animator.SetBool("in", false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = endsprite;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        unityEvent.Invoke();
        GetComponent<Image>().sprite = stasprite;
    }
}
