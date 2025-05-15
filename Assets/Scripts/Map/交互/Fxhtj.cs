using UnityEngine;

public class Fxhtj : MonoBehaviour
{
    PolygonCollider2D s;
    private void Start()
    {
        s = GetComponent<PolygonCollider2D>();
    }
    void Update()
    {
        if (GameManager.instant.getPlayer().transform.position.y - 4 > transform.position.y)
        {
            s.enabled = true;
        }
        else
        {
            s.enabled = false;
        }
    }
}
