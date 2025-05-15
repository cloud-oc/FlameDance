using UnityEngine;

public class TipDot : MonoBehaviour
{
    public string tip;
    public bool TouchMode = true;
    private void OnMouseDown()
    {
        if (TouchMode) 
        {
            GameManager.instant.setTipText(tip);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!TouchMode&&collision.tag=="Player")GameManager.instant.setTipText(tip);
    }
}
