using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoOver : MonoBehaviour
{
    public UnityEvent unityEvent;
    VideoPlayer player;
    private void Start()
    {
        player = GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if (player.isPaused)
        {
            // unityEvent.Invoke();
            GameManager.instant.LoadScene("StartScene");
            gameObject.SetActive(false); 
        }
    }
}
