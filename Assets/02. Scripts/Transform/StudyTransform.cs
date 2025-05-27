using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public GameObject[] testObjects = new GameObject[8];

    public float moveSpeed = 10f;
    public float rotateSpeed = 70f;

    void Update()
    {
        // 1. 월드 방향으로 이동
        // transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        // 2. 로컬 방향으로 이동
        // transform.localPosition += Vector3.forward * moveSpeed * Time.deltaTime;

        // 3. 로컬 방향으로 이동
        // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // float angle = transform.eulerAngles.y + rotateSpeed * Time.deltaTime;
        // float localX = transform.localEulerAngles.x;
        // float localZ = transform.localEulerAngles.z;

        // 4. 월드 방향으로 회전
        // transform.rotation = Quaternion.Euler(localX, angle, localZ);

        // 5. 로컬 방향으로 회전
        // transform.localRotation = Quaternion.Euler(localX, angle, localZ);

        // 6. 로컬 방향으로 회전
        // transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); // Space.Self 생략

        // 7. 월드 방향으로 회전
        // transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        // 8. 특정 위치의 주변을 회전 (new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f) 줄여씀
        // transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);


        // 한눈에 보기
        float dt = Time.deltaTime;

        // 1. 월드 방향으로 이동
        testObjects[0].transform.position += Vector3.forward * moveSpeed * dt;

        // 2. 로컬 방향으로 이동 (localPosition은 시각적 변화는 position과 동일하게 보일 수 있음)
        testObjects[1].transform.localPosition += Vector3.forward * moveSpeed * dt;

        // 3. 로컬 방향으로 이동 (Translate 기본은 Space.Self)
        testObjects[2].transform.Translate(Vector3.forward * moveSpeed * dt);

        // 4. 월드 기준 회전 (회전 값 직접 설정)
        float angle4 = testObjects[3].transform.eulerAngles.y + rotateSpeed * dt;
        float x4 = testObjects[3].transform.localEulerAngles.x;
        float z4 = testObjects[3].transform.localEulerAngles.z;
        testObjects[3].transform.rotation = Quaternion.Euler(x4, angle4, z4);

        // 5. 로컬 기준 회전 (localRotation 사용)
        float angle5 = testObjects[4].transform.localEulerAngles.y + rotateSpeed * dt;
        float x5 = testObjects[4].transform.localEulerAngles.x;
        float z5 = testObjects[4].transform.localEulerAngles.z;
        testObjects[4].transform.localRotation = Quaternion.Euler(x5, angle5, z5);

        // 6. 로컬 축 기준 회전
        testObjects[5].transform.Rotate(Vector3.up, rotateSpeed * dt);

        // 7. 월드 축 기준 회전
        testObjects[6].transform.Rotate(Vector3.up, rotateSpeed * dt, Space.World);

        // 8. (0,0,0)을 중심으로 공전
        testObjects[7].transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * dt);
    }
}
