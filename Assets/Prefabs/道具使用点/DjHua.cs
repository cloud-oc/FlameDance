using UnityEngine;
using UnityEngine.Events;

public class DjHua : DaojuUsePorint
{
    public UnityEvent over;
    public static bool used1;
    public override bool getused1() => used1;

    public override void setused1() => used1 = false;

    public override void used1Eff()
    {
        SoundManager.instance.StopBGM();
        over.Invoke();
    }

}
