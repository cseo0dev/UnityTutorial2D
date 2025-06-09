using UnityEngine;

public class StudyInvoke : MonoBehaviour
{
    public int count = 10;

    void Start()
    {
        // 반복 Invoke ("함수명", 첫 지연, 주기)
        InvokeRepeating("Bomb", 0f, 1f);
    }

    private void Bomb()
    {
        Debug.Log($"현재 남은 시간 : {count}초");
        count--;

        if (count == 0)
        {
            Debug.Log("펑~~");
            CancelInvoke("Bomb");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Bomb");
            Debug.Log("폭탄이 해제되었습니다.");
        }
    }
}
