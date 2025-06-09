using UnityEngine;

public class StudyInvoke : MonoBehaviour
{
    public int count = 10;

    void Start()
    {
        // �ݺ� Invoke ("�Լ���", ù ����, �ֱ�)
        InvokeRepeating("Bomb", 0f, 1f);
    }

    private void Bomb()
    {
        Debug.Log($"���� ���� �ð� : {count}��");
        count--;

        if (count == 0)
        {
            Debug.Log("��~~");
            CancelInvoke("Bomb");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Bomb");
            Debug.Log("��ź�� �����Ǿ����ϴ�.");
        }
    }
}
