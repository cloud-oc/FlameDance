using UnityEngine;

public class Door : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject Object;
    public static bool on =false;
    bool onplayer = false;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Object.SetActive(false);
    }
    private void Update()
    {
        if (on && onplayer && Input.GetKeyDown(KeyCode.F))
        {
            Object.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") onplayer = true;
        if (on) {SoundManager.instance.PlaySound(audioSource,SoundConst.SE_OPENINGDOOR);}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") onplayer = false;
    }
}
