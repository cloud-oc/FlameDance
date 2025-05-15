using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Video;
using TMPro;

namespace Commons.UI
{
    public class StartScreenController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float delayBeforeInput = 2f;  // 等待时间，可在检视器中调整
        [SerializeField] private string gameSceneName = "Scene0";  // 游戏场景名称
        [SerializeField] private VideoPlayer videoPlayer;  // 视频播放器引用
        [SerializeField] private TextMeshProUGUI textComponent;  // TextMeshPro文本组件引用

        private float timer = 0f;
        private bool canStart = false;
        private bool isPlayingVideo = false;

        private void Start()
        {
            if (videoPlayer != null)
            {
                videoPlayer.playOnAwake = false;
                videoPlayer.Prepare();
                videoPlayer.frame = 0;
                videoPlayer.Play();
                videoPlayer.Pause();
            }

            if (textComponent != null)
            {
                textComponent.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            // 计时器
            if (!canStart && !isPlayingVideo)
            {
                timer += Time.deltaTime;
                if (timer >= delayBeforeInput)
                {
                    canStart = true;
                    Debug.Log("Ready to start game");
                }
            }
            // 等待时间过后，检测任意点击
            else if (canStart && !isPlayingVideo && Input.anyKeyDown)
            {
                PlayVideoAndLoadScene();
            }
        }

        private void PlayVideoAndLoadScene()
        {
            if (videoPlayer != null)
            {
                isPlayingVideo = true;
                if (textComponent != null)
                {
                    textComponent.gameObject.SetActive(false);
                }
                videoPlayer.Play();
                videoPlayer.loopPointReached += OnVideoFinished;
            }
            else
            {
                SceneManager.LoadScene(gameSceneName);
            }
        }

        private void OnVideoFinished(VideoPlayer vp)
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}