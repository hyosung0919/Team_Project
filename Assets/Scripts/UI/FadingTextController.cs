using System.Collections;
using UnityEngine;
using TMPro;

public class FadingTextController : MonoBehaviour
{
    public TMP_Text targetText;
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeLoop());
    }

    IEnumerator FadeLoop()
    {
        while (true)
        {
            yield return StartCoroutine(FadeText(0f, 1f, fadeDuration)); // 페이드인
            yield return StartCoroutine(FadeText(1f, 0f, fadeDuration)); // 페이드아웃
        }
    }

    IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
    {
        float time = 0f;
        Color color = targetText.color;

        while (time < duration)
        {
            float t = time / duration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            targetText.color = color;
            time += Time.deltaTime;
            yield return null;
        }

        color.a = endAlpha;
        targetText.color = color;
    }
}