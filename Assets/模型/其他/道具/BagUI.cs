using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite uisprite;
    public GameObject[] obs;
    private Vector2 startRectPosition;
    private RectTransform rectTransform;
    static bool isuse = false;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startRectPosition = GetComponent<RectTransform>().position;
        //obs = new GameObject[Bag.it.Daojus.Length];
        //for (int i = 0; i < obs.Length; i++)
        //{
        //    obs[i] = Instantiate(ob, transform);
        //    obs[i].transform.position = new Vector2(
        //        transform.position.x - rectTransform.rect.width + (rectTransform.rect.width/obs.Length) * (i*2),
        //        transform.position.y);
        //}
    }
    private void Update()
    {
        if (!GameManager.instant.over)
        {
            if (isuse)
            {
                for (int i = 0; i < Bag.it.Daojus.Length; i++)
                {
                    if (Bag.it.Daojus[i]) obs[i].gameObject.GetComponent<Image>().sprite = Bag.it.Daojus[i].GetComponent<SpriteRenderer>().sprite;
                    else obs[i].gameObject.GetComponent<Image>().sprite = uisprite;
                    obs[i].gameObject.GetComponent<DaojuUI>().daoju = Bag.it.Daojus[i];
                }
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                isuse = !isuse;
                if (isuse) this.rectTransform.DOMoveY(100, 1);
                else this.rectTransform.DOMoveY(startRectPosition.y, 1);
            }
        }
        else
        {
            if (isuse) this.rectTransform.DOMoveY(startRectPosition.y, 1);
            isuse = false;
            
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isuse = true;
        this.rectTransform.DOMoveY(100, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {      
        isuse = false;
        this.rectTransform.DOMoveY(startRectPosition.y, 1);
    }

 
}
