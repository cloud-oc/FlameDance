using UnityEngine;
using UnityEngine.Events;
//��꽻�����
public class FFF : MonoBehaviour
{
    [Header("���")]
    public UnityEvent u1;
    [Header("��ק")]
    public bool canDrag;
    public bool follow_m = false;
    public UnityEvent u2;
    [Header("�Ӵ�")]
    public GameObject GameObject;
    public UnityEvent u3;
    private void OnMouseDown()
    {
        u1.Invoke();
    }
    private void OnMouseDrag()
    {
        u2.Invoke();
        if (follow_m && canDrag) transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3.back * Camera.main.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject&&collision.name==GameObject.name)u3.Invoke();
    }
}
