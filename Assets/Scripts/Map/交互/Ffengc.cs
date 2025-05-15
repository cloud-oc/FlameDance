using Unity.Mathematics;
using UnityEngine;

public class Ffengc : MonoBehaviour
{
    public static bool on = false;
    bool playeron = false;
    private void Start()
    {
        on = Fwindow.on;
        if (on)gameObject.SetActive(false);
    }
    void LateUpdate()
    {
        if (playeron) GameManager.instant.getPlayer().GetComponent<Rigidbody2D>().linearVelocityX -= 
        20*(100/(transform.position - GameManager.instant.getPlayer().transform.position).magnitude);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playeron = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playeron = false;
        }
    }
}
