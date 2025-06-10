using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel; // 페이드 이미지

    public void OnFade(float fadeTime, Color color)
    {
        StartCoroutine(FadeRoutine(fadeTime, color));
    }

    // 이렇게 모듈화 하였기 때문에 다른 씬/프로젝트에서도 사용 가능
      IEnumerator FadeRoutine(float fadeTime, Color color)
    {
        float timer = 0f;
        float percent = 0f;

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime; // Fade 퍼센트

            fadePanel.color = new Color(color.r, color.g, color.b, percent);
            yield return null;
        }
    }
}