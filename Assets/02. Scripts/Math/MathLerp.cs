using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;

    private Vector3 startPos;

    // 타이머, 퍼센트, 원하는 이동 시간
    private float timer, percent;
    public float lerpTime;

    void Start()
    {
        startPos = transform.position; // 시작 지점 저장
    }

    void Update()
    {
        timer += Time.deltaTime;
        percent = timer / lerpTime;

        // (현재위치, 목표위치, 이동 비율)
        transform.position = Vector3.Lerp(startPos, targetPos, percent);
    }
}