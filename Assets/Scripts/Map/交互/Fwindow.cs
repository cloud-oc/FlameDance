using UnityEngine;

public class Fwindow : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject GameObject;
    public static bool on = false;
    bool onplayer = false;

    public void Shifton() { on = !on; }
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameObject.SetActive(on);
    }
    private void Update()
    {
        if (onplayer && Input.GetKeyDown(KeyCode.F))
        {
            Shifton();
            SoundManager.instance.PlaySound(audioSource, SoundConst.SE_CLOSINGWINDOW);
            GameObject.SetActive(on);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") onplayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") onplayer = false;
    }
}
