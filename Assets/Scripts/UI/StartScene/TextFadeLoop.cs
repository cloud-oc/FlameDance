using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextFadeLoop : MonoBehaviour
{
    public TMP_Text uiText;              // 要淡入淡出的Text组件
    public float fadeDuration = 1f;  // 单次淡入或淡出持续时间
    public bool loop = true;         // 是否循环

    void Start()
    {
        // 确保文字初始状态是透明的
        Color textColor = uiText.color;
        textColor.a = 0f;
        uiText.color = textColor;

        // 启动循环淡入淡出效果
        StartCoroutine(FadeInOutLoop());
    }

    // 淡入淡出循环
    IEnumerator FadeInOutLoop()
    {
        // 等待一帧确保初始透明度设置生效
        yield return null;

        while (loop)
        {
            // 先淡入
            yield return StartCoroutine(FadeInText());
            // 再淡出
            yield return StartCoroutine(FadeOutText());
        }
    }

    // 淡入效果
    IEnumerator FadeInText()
    {
        float elapsedTime = 0f;
        Color textColor = uiText.color;
        textColor.a = 0f; // 开始时透明
        uiText.color = textColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textColor.a = Mathf.Clamp01(elapsedTime / fadeDuration); // 渐变透明度
            uiText.color = textColor;
            yield return null; // 等待下一帧
        }
    }

    // 淡出效果
    IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        Color textColor = uiText.color;
        textColor.a = 1f; // 开始时不透明
        uiText.color = textColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textColor.a = Mathf.Clamp01(1f - (elapsedTime / fadeDuration)); // 渐变透明度
            uiText.color = textColor;
            yield return null; // 等待下一帧
        }
    }
}