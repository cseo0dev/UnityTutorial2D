using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel; // ���̵� �̹���

    void Start()
    {
        // 3�ʵ��� ���̵� ��
        StartCoroutine(FadeRoutineA(3, true));

        // 3�ʵ��� ���̵� �ƿ�
        StartCoroutine(FadeRoutineA(3, false));
    }

    // �̷��� ���ȭ �Ͽ��� ������ �ٸ� ��/������Ʈ������ ��� ����
      IEnumerator FadeRoutineA(float fadeTime, bool isFadeIn)
    {
        float timer = 0f;
        float percent = 0f;
        float value = 0f;

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime; // Fade �ۼ�Ʈ
            value = isFadeIn ? percent : 1 - percent;

            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, value);
            yield return null;
        }
    }
}