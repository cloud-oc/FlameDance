using Unity.VisualScripting;
using UnityEngine;

public class Fsun : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject game;
    static bool cf = false;
    bool onplayer = false;
    private void Awake()
    {
        game.SetActive(!cf);
    }
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (onplayer && !cf && Input.GetKeyDown(KeyCode.F))
        {

            SoundManager.instance.PlaySound(audioSource,SoundConst.SE_SUN);
            cf = true;
            PlayerMove.Light = 60;
            PlayerMove.Stage = 2;
            game.SetActive(!cf);
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

    //private void OnMouseDown()
    //{
    //    if (!cf) 
    //    {
    //        cf = true;
    //        PlayerMove.Light -= 20;
    //        PlayerMove.Stage = 2;
    //        game.SetActive(!cf);

    //    }
    //}
}
