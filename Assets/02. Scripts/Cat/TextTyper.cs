using System.Collections;
using TMPro;
using UnityEngine;

public class TextTyper : MonoBehaviour
{
    public TextMeshProUGUI textPro;
    public string fullText = "jump cat";
    public float typingSpeed = 0.2f;
    public float blinkInterval = 0.3f;   // 깜빡이는 간격
    public int blinkCount = 2;

    private void Start()
    {
        StartCoroutine(LoopingTypeEffect());
    }

    IEnumerator LoopingTypeEffect()
    {
        while (true)
        {
            // 한 글자씩 타이핑
            for (int i = 0; i <= fullText.Length; i++)
            {
                textPro.text = fullText.Substring(0, i);
                yield return new WaitForSeconds(typingSpeed);
            }

            // 마지막 전체 텍스트 깜빡임
            for (int i = 0; i < blinkCount; i++)
            {
                textPro.enabled = false;
                yield return new WaitForSeconds(blinkInterval);

                textPro.enabled = true;
                yield return new WaitForSeconds(blinkInterval);
            }

            // 다시 시작 전 짧은 대기
            yield return new WaitForSeconds(0.5f);
        }
    }
}
