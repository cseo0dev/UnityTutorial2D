using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialTextTyper : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string fullText = "�����̽��ٸ� ���� �����ϼ���!";
    public float typingSpeed = 0.05f;
    public float blinkInterval = 0.3f;
    public int blinkCount = 2;

    public IEnumerator StartTyping()
    {
        tutorialText.text = "";

        // Ÿ���� ȿ��
        for (int i = 0; i <= fullText.Length; i++)
        {
            tutorialText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }

        // ������ ȿ��
        for (int i = 0; i < blinkCount; i++)
        {
            tutorialText.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            tutorialText.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }

        tutorialText.gameObject.SetActive(false);  // ���������� ���ֱ�
    }
}
