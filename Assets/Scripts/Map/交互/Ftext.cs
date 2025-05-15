using TMPro;
using UnityEngine;

public class Ftext : MonoBehaviour
{
    public bool IsOn = false;
    public bool onEnable = false;
    [Header("¶à¶Ô»°")]
    public bool texts = false;
    public bool onEnabletonext;
    public bool resycle;
    public string[] Texts;
    int indextexts = 0;

    public float Speed = 10;
    string text="";
    int index = 0;
    float timer = 0;
    TextMeshProUGUI pro;
    void Start()
    {
        pro = GetComponent<TextMeshProUGUI>();
        text = pro.text;
        pro.text = "";
    }
    private void Update()
    {
        IsOn = true;
        if (timer > 0) timer -= Time.deltaTime;
        else if (texts) 
        {
            if (index < Texts[indextexts].Length)
            {
                pro.text += Texts[indextexts][index++];
                timer = 1 / Speed;
            }
            else IsOn = false;
        }
        else if (index < text.Length) 
        {
            pro.text += text[index++];
            timer = 1/Speed;
        }else IsOn = false;

    }
    private void OnEnable()
    {
        if (onEnable&&pro)
        {
            index = 0;
            pro.text = "";
            if (onEnabletonext && indextexts < Texts.Length - 1) indextexts++;
            else if (resycle) indextexts = 0;
        }
    }
}
