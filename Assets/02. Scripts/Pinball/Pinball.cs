using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager;

    void OnCollisionEnter2D(Collision2D other)
    {
        // 태그가 없는 오브젝트 처리
        if (other.gameObject.CompareTag("Untagged")) return;
        
        int score = 0;
        switch (other.gameObject.tag)
        {
            case "Score10":
                score = 10;
                break;
            case "Score30":
                score = 30;
                break;
            case "Score50":
                score = 50;
                break;
        }

        pinballManager.totalScore += score;
        Debug.Log($"{score}점 획득!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"최종 점수 : {pinballManager.totalScore}");
        }
    }
}
