using UnityEngine;

public class CamerLimit : MonoBehaviour
{
    public Transform[] points;
    //int xx = 0;
    void Update()
    {
       print( inpoints());
    }
    bool inpoints()
    {
        int conts = 0;
        Vector2 a;
        Vector2 b;
        for (int i = 1; i < points.Length; i++)
        {
            a = points[i-1].position;
            b = points[i].position;
            if ((a.y > transform.position.y && b.y < transform.position.y) || (a.y < transform.position.y && b.y > transform.position.y))
                if ((a.x > transform.position.x) || (b.x > transform.position.x)) conts++;
           
        }
        a = points[0].position;
        b = points[points.Length-1].position;
        if ((a.y > transform.position.y && b.y < transform.position.y) || (a.y < transform.position.y && b.y > transform.position.y))
            if ((a.x > transform.position.x) || (b.x > transform.position.x)) conts++;
        //if (xx != conts) { print(conts); xx = conts; }
        if (conts ==0)return false;
        return conts % 2 == 1;
    }
}
