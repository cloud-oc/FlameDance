using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public static List<string> UsdPropNames = new List<string>();
    public static List<string> GetPropNames = new List<string>();
    public GameObject[] bz;
    bool pp = false;
    private void Start()
    {
        foreach(var prop in UsdPropNames)
        {
            if (this.name == prop)
            {
                this.gameObject.SetActive(false);
            }
        }
        foreach (var prop in GetPropNames)
        {
            if (this.name == prop)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (pp && Input.GetKeyDown(KeyCode.F))
        {
            //transform.DOMove(Camera.main.transform.position+new Vector3(0,0,10),2).OnKill(
            //    ()=> { 
            //            gameObject.SetActive(false); 
            //         }
            //    );
            //foreach (var g in bz) { g.SetActive(!g.activeSelf); }
            //GetPropNames.Add(this.name);
            getProp();
        }
    }

    public void getProp()
    {
        transform.DOMove(Camera.main.transform.position + new Vector3(0, 0, 10), 2).OnKill(
               () => {
                   gameObject.SetActive(false);
               }
               );
        foreach (var g in bz) { g.SetActive(!g.activeSelf); }
        GetPropNames.Add(this.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pp = false;
        }
    }

}
