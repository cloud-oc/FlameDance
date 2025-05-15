using UnityEngine;

public class FmoveTo : MonoBehaviour
{
    public void Movetothere(GameObject p)
    {
        p.transform.position = transform.position;
        p.GetComponent<SpriteRenderer>().enabled = false;
    }
}
