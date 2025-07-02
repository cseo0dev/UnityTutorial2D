using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialTextTyper : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string fullText = "스페이스바를 눌러 점프하세요!";
    public float typingSpeed = 0.05f;
    public float blinkInterval = 0.3f;
    public int blinkCount = 2;

    public IEnumerator StartTyping()
    {
        tutorialText.text = "";

        // 타이핑 효과
        for (int i = 0; i <= fullText.Length; i++)
        {
            tutorialText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }

        // 깜빡임 효과
        for (int i = 0; i < blinkCount; i++)
        {
            tutorialText.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            tutorialText.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }

        tutorialText.gameObject.SetActive(false);  // 최종적으로 꺼주기
    }
}
