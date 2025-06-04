using System.Collections;
using TMPro;
using UnityEngine;

public class TextTyper : MonoBehaviour
{
    public TextMeshProUGUI textPro;
    public string fullText = "jump cat";
    public float typingSpeed = 0.2f;
    public float blinkInterval = 0.3f;   // �����̴� ����
    public int blinkCount = 2;

    private void Start()
    {
        StartCoroutine(LoopingTypeEffect());
    }

    IEnumerator LoopingTypeEffect()
    {
        while (true)
        {
            // �� ���ھ� Ÿ����
            for (int i = 0; i <= fullText.Length; i++)
            {
                textPro.text = fullText.Substring(0, i);
                yield return new WaitForSeconds(typingSpeed);
            }

            // ������ ��ü �ؽ�Ʈ ������
            for (int i = 0; i < blinkCount; i++)
            {
                textPro.enabled = false;
                yield return new WaitForSeconds(blinkInterval);

                textPro.enabled = true;
                yield return new WaitForSeconds(blinkInterval);
            }

            // �ٽ� ���� �� ª�� ���
            yield return new WaitForSeconds(0.5f);
        }
    }
}
