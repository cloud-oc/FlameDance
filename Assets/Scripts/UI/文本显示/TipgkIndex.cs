using System;
using UnityEngine;

public class TipgkIndex : MonoBehaviour
{
    [SerializeField]
    Tips[] Tip;
    int touchTimes = 0;
    int index = 0;
    bool canTouch = true;
    public void touch()
    {
        //Jingdu.levelN,Jingdu.levelP
        if (canTouch)
        {
            canTouch = false;
            Invoke("reSetTouch", 1);
            if (index != Jingdu.levelN) { index = Jingdu.levelN; touchTimes = 0; }
            if (Jingdu.levelN < Tip.Length && Tip[Jingdu.levelN].tips.Length != 0) GameManager.instant.setTipText(Tip[Jingdu.levelN].tips[touchTimes++ % Tip[Jingdu.levelN].tips.Length]);
        }
    }
    void reSetTouch() => canTouch = true;
    [Serializable]
    public class Tips
    {
        public string[] tips;
    }
}
