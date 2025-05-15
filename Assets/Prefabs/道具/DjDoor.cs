using UnityEngine;

public class DjDoor : DaojuUsePorint
{
    public AudioSource audioSource;
    public GameObject[] g;
    static bool used1 = false;
    public override void setused1() => used1 = true;
    public override bool getused1() => used1;

    public override void used1Eff()
    {
        foreach (GameObject obj in g)
        {
            obj.SetActive(false);
            if (obj == g[1])
            {
                SoundManager.instance.PlaySound(audioSource, SoundConst.SE_OPENINGDOOR);
            }
        }
    }
}
