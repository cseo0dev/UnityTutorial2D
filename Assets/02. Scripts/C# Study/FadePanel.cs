using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel; // ���̵� �̹���

    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        // �ڷ�ƾ�� ��Ȱ�� �۵��� ���� �������ִ� �κ�
        StopAllCoroutines();

        StartCoroutine(FadeRoutine(fadeTime, color, isFadeStart));
    }

    // �̷��� ���ȭ �Ͽ��� ������ �ٸ� ��/������Ʈ������ ��� ����
      IEnumerator FadeRoutine(float fadeTime, Color color, bool isFadeStart)
    {
        float timer = 0f;
        float percent = 0f;


        while (percent < 1f)
        {
            // ������ ���۵� ���� ����� �� �ٸ� fade ���� �־��ֱ� ���� ���� ����
            float value = isFadeStart ? percent : 1 - percent;

            timer += Time.deltaTime;
            percent = timer / fadeTime; // Fade �ۼ�Ʈ

            fadePanel.color = new Color(color.r, color.g, color.b, value);
            yield return null;
        }
    }
}