using UnityEngine;

public class Fbird : MonoBehaviour
{
    bool onplayer = false;
    static bool locker = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!locker && onplayer && Input.GetKeyDown(KeyCode.F))
        {
            locker = true;
            PlayerMove.Light = 20;
            PlayerMove.Stage = 3;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onplayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onplayer = false;
        }
    }
}
