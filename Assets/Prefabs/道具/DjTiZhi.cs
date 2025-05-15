using UnityEngine;

public class DjTiZhi : DaojuUsePorint
{
    static bool used1;
    public override bool getused1() => used1;
    public override void setused1() => used1 = true;

    public override void used1Eff()
    {
        gameObject.SetActive(false);
    }
}
