using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
/*
 *   1.����ƶ���ģ������ʾ�߿�
 *   2.��������
 */
public class Select : MonoBehaviour
{
    SpriteShapeRenderer shapeRenderer;
    [Header("��ʾ�߽�")]
    public bool use = true;
    public bool select = false;
    public UnityEvent UnityEvents;
    public int MouseTouch=0;
    // Start is called before the first frame update
    void Start()
    {
        shapeRenderer = GetComponent<SpriteShapeRenderer>();
        if(shapeRenderer)shapeRenderer.enabled = false;
    }
    private void OnMouseEnter()
    {
        if(use&&Time.timeScale!=0)shapeRenderer.enabled = true;
    }
    private void OnMouseExit()
    {
        if(use)shapeRenderer.enabled=false;
    }
    private void OnMouseDown()
    {
        if (select && Time.timeScale != 0)
        {
            UnityEvents.Invoke();
            MouseTouch++;
            MouseTouch %= 2;
            if (MouseTouch == 1)
            {
                print("11");
            }
            else
            {
                print("22");
            }
        }
    }

}
