using System.Collections.Generic;
using UnityEngine;

public class DaojuInit : MonoBehaviour
{
    private AudioSource audioSource;
    public static List<string> objects = new();
    public GameObject daoju;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (daoju) Init();
    }
    void Init()
    {
        bool f = false;
        foreach (var item in objects)
        {
            if (item == daoju.name) { f = !f; break; }
        }
        if (!f)
        {
            GameObject g = Instantiate(daoju);
            g.name = daoju.name;
            g.transform.position = transform.position;
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.SetActive(false);
    }
    
}
