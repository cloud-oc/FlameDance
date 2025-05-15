using UnityEngine;
using UnityEngine.UI;

public class ToggleTip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Toggle>().isOn = Vars.istip;   
    }
}
