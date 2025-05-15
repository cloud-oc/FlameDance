using UnityEngine;

public class FsetCameActive : MonoBehaviour
{
    public GameObject ob;
    bool temp;
    public GameObject[] T;
    public GameObject[] F;
    private void Start()
    {
        temp = ob.activeSelf;
        foreach (var g in T) g.SetActive(temp);
        foreach (var g in F) g.SetActive(!temp);
    }
    void Update()
    {
        if (temp != ob.activeSelf)
        {
            temp = ob.activeSelf;
            foreach (var g in T) g.SetActive(temp);
            foreach (var g in F) g.SetActive(!temp);
        }
    }

}
