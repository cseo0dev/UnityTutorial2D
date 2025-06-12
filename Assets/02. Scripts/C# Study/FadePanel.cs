using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel; // 페이드 이미지

    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        // 코루틴의 원활한 작동을 위해 정리해주는 부분
        StopAllCoroutines();

        StartCoroutine(FadeRoutine(fadeTime, color, isFadeStart));
    }

    // 이렇게 모듈화 하였기 때문에 다른 씬/프로젝트에서도 사용 가능
      IEnumerator FadeRoutine(float fadeTime, Color color, bool isFadeStart)
    {
        float timer = 0f;
        float percent = 0f;


        while (percent < 1f)
        {
            // 게임이 시작될 때와 종료될 때 다른 fade 값을 넣어주기 위해 변수 생성
            float value = isFadeStart ? percent : 1 - percent;

            timer += Time.deltaTime;
            percent = timer / fadeTime; // Fade 퍼센트

            fadePanel.color = new Color(color.r, color.g, color.b, value);
            yield return null;
        }
    }
}