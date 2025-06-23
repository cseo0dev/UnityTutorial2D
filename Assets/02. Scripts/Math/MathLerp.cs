using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;

    private Vector3 startPos;

    // Ÿ�̸�, �ۼ�Ʈ, ���ϴ� �̵� �ð�
    private float timer, percent;
    public float lerpTime;

    void Start()
    {
        startPos = transform.position; // ���� ���� ����
    }

    void Update()
    {
        timer += Time.deltaTime;
        percent = timer / lerpTime;

        // (������ġ, ��ǥ��ġ, �̵� ����)
        transform.position = Vector3.Lerp(startPos, targetPos, percent);
    }
}