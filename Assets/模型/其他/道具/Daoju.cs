using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Daoju : MonoBehaviour
{
    public bool isOneUse = true;
    new public string name;
    public int id;
    public static int num = 0;
    public bool init = false;
    bool playeron = false;
    bool f = false;
    bool locker = false;
    private void Start()
    {
        id = num++;
        
    }
    private void Update()
    {
        if (!locker)
        {
            if (playeron && Input.GetKeyDown(KeyCode.F)) { f = true; }
            if(f)
            {
                if (Bag.it.add(this))
                {
                    DontDestroyOnLoad(this);
                    init = true;
                   // gameObject.SetActive(false);
                    transform.DOMove(Camera.main.transform.position + new Vector3(0, 0, 10), 2).OnKill(
               () => {
                   gameObject.SetActive(false);
               }
               );
                    locker = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playeron = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playeron = false;
        }
    }
    abstract public void use1();
    public void Use() { use1();if(isOneUse) Destroy(gameObject); }

    //private void OnMouseDown()
    //{
    //     if(Bag.it.add(this))
    //    {
    //        DontDestroyOnLoad(this);
    //        init = true;
    //        gameObject.SetActive(false);
    //     }
    //    print("123");
    //}
}
