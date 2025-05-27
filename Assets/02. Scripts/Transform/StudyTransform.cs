using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public GameObject[] testObjects = new GameObject[8];

    public float moveSpeed = 10f;
    public float rotateSpeed = 70f;

    void Update()
    {
        // 1. ���� �������� �̵�
        // transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        // 2. ���� �������� �̵�
        // transform.localPosition += Vector3.forward * moveSpeed * Time.deltaTime;

        // 3. ���� �������� �̵�
        // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // float angle = transform.eulerAngles.y + rotateSpeed * Time.deltaTime;
        // float localX = transform.localEulerAngles.x;
        // float localZ = transform.localEulerAngles.z;

        // 4. ���� �������� ȸ��
        // transform.rotation = Quaternion.Euler(localX, angle, localZ);

        // 5. ���� �������� ȸ��
        // transform.localRotation = Quaternion.Euler(localX, angle, localZ);

        // 6. ���� �������� ȸ��
        // transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); // Space.Self ����

        // 7. ���� �������� ȸ��
        // transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        // 8. Ư�� ��ġ�� �ֺ��� ȸ�� (new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f) �ٿ���
        // transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);


        // �Ѵ��� ����
        float dt = Time.deltaTime;

        // 1. ���� �������� �̵�
        testObjects[0].transform.position += Vector3.forward * moveSpeed * dt;

        // 2. ���� �������� �̵� (localPosition�� �ð��� ��ȭ�� position�� �����ϰ� ���� �� ����)
        testObjects[1].transform.localPosition += Vector3.forward * moveSpeed * dt;

        // 3. ���� �������� �̵� (Translate �⺻�� Space.Self)
        testObjects[2].transform.Translate(Vector3.forward * moveSpeed * dt);

        // 4. ���� ���� ȸ�� (ȸ�� �� ���� ����)
        float angle4 = testObjects[3].transform.eulerAngles.y + rotateSpeed * dt;
        float x4 = testObjects[3].transform.localEulerAngles.x;
        float z4 = testObjects[3].transform.localEulerAngles.z;
        testObjects[3].transform.rotation = Quaternion.Euler(x4, angle4, z4);

        // 5. ���� ���� ȸ�� (localRotation ���)
        float angle5 = testObjects[4].transform.localEulerAngles.y + rotateSpeed * dt;
        float x5 = testObjects[4].transform.localEulerAngles.x;
        float z5 = testObjects[4].transform.localEulerAngles.z;
        testObjects[4].transform.localRotation = Quaternion.Euler(x5, angle5, z5);

        // 6. ���� �� ���� ȸ��
        testObjects[5].transform.Rotate(Vector3.up, rotateSpeed * dt);

        // 7. ���� �� ���� ȸ��
        testObjects[6].transform.Rotate(Vector3.up, rotateSpeed * dt, Space.World);

        // 8. (0,0,0)�� �߽����� ����
        testObjects[7].transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * dt);
    }
}
