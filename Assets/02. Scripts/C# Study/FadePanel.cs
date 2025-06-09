using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel; // 페이드 이미지

    void Start()
    {
        // 3초동안 페이드 인
        StartCoroutine(FadeRoutineA(3, true));

        // 3초동안 페이드 아웃
        StartCoroutine(FadeRoutineA(3, false));
    }

    // 이렇게 모듈화 하였기 때문에 다른 씬/프로젝트에서도 사용 가능
      IEnumerator FadeRoutineA(float fadeTime, bool isFadeIn)
    {
        float timer = 0f;
        float percent = 0f;
        float value = 0f;

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime; // Fade 퍼센트
            value = isFadeIn ? percent : 1 - percent;

            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, value);
            yield return null;
        }
    }
}