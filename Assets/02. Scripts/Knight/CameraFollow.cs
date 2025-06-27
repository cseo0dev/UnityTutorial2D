using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 5f;

    [SerializeField] private Vector2 minBound;
    [SerializeField] private Vector2 maxBound;

    void Start()
    {
        // Start 메서드 처럼 한번만 실행되는 곳에서 find를 사용해도 큰 문제가 없다. -> 업데이트문에서 쓰면 욕먹음
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 destination = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, destination, smoothSpeed * Time.deltaTime);

        smoothPos.x = Mathf.Clamp(smoothPos.x, minBound.x, maxBound.x);
        smoothPos.y = Mathf.Clamp(smoothPos.y, minBound.y, maxBound.y);

        transform.position = smoothPos;
    }
}