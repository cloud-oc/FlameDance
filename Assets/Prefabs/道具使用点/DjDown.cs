using UnityEngine;
using UnityEngine.Windows;

public class DjDown : DaojuUsePorint
{
    public GameObject g;
    public static bool used1;
    public override bool getused1() => used1;

    public override void setused1() => used1 = false;

    public override void used1Eff()
    {
        if(g)g.SetActive(false);
        GameManager.instant.Player.GetComponent<Animator>().Play("降落伞");
        if (PlayerMove.left) { GameManager.instant.Player.transform.rotation = Quaternion.Euler(0, 0, 0);}
        else{ GameManager.instant.Player.transform.rotation = Quaternion.Euler(0, 180, 0);}
        Invoke("Setan", 1.1f);
    }
    void Setan() { GameManager.instant.Player.GetComponent<Animator>().Play("A"); }
}
