using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*
*  1.玩家与模型接触触发
*/
public class Contact : MonoBehaviour
{
    public bool use = true;
    public UnityEvent UnityEvent;
    public GameObject[] gameObjects;
    public bool OnContact = false;
    bool contact = true;
    private void Awake()
    {
        if (OnContact != contact)
        {
            foreach (GameObject ob in gameObjects) { ob.SetActive(OnContact); }
            contact = OnContact;
        }
    }
    private void Update()
    {
        if (OnContact != contact&&use) 
        {
            foreach (GameObject ob in gameObjects) { ob.SetActive(OnContact);}
            contact = OnContact;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            if(UnityEvent != null)UnityEvent.Invoke();
            OnContact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            OnContact = false;
        }
    }
}
