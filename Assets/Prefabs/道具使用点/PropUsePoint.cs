using System.Collections.Generic;
using UnityEngine;

public class PropUsePoint : MonoBehaviour
{
    public string needPropName;
    public GameObject[] gameObjects;
    public static List<string> isusednames = new List<string>();
    bool pp = false;
    private void Start()
    {
        foreach (var prop in isusednames)
        {
            if (this.name == prop)
            {
                act();
            }
        }
    }
    private void Update()
    {
        if (pp && Input.GetKeyDown(KeyCode.F))
        {
            getuse();
            Bag.it.useAndRemove("Щўзг");
        }
    }

    public void getuse()
    {
        if (useP()) act();
    }

    public bool useP()
    {
        foreach (var prop in Prop.GetPropNames)
        {
            if (needPropName == prop)
            {
                Prop.GetPropNames.Remove(prop);
                Prop.UsdPropNames.Add(prop);
                isusednames.Add(this.name);
                return true;
            }
        }
        return false;
    }
    public void act()
    {
        foreach(var g in gameObjects)
        {
            g.SetActive(!g.activeSelf);
        }
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
