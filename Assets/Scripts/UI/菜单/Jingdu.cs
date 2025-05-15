using UnityEngine;

public class Jingdu : MonoBehaviour
{
    static public Jingdu instand;
    public static int levelP = 0;
    public static int levelN = 0;
    public RectTransform index;
    public GameObject[] obP;
    private void Start()
    {
        if(!instand) instand = GetComponent<Jingdu>();
    }
    private void OnEnable()
    {
        index.position = obP[levelN].GetComponent<levelButton>().indexpoint.position;
        for (int i = 1; i < obP.Length; i++) 
        {
            if(i>levelP)obP[i].GetComponent<levelButton>().ch.SetActive(false);
            else obP[i].GetComponent<levelButton>().ch.SetActive(true);
        }
    }
    public void nextlevel() { if (levelP < obP.Length)levelP++; }
}
