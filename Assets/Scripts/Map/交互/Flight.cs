using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flight : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject bj;
    public static bool on = false;
    bool onplayer = false;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        bj.SetActive(on);
        GetComponent<Light2D>().enabled = on;
    }
    private void Update()
    {
        if(onplayer&&Input.GetKeyDown(KeyCode.F))SetOnOff();
    }
    public void SetOnOff() 
    {
        on = !on;
        GetComponent<Light2D>().enabled = on;
        SoundManager.instance.PlaySound(audioSource,SoundConst.SE_LAMP);
        bj.SetActive(on);
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
