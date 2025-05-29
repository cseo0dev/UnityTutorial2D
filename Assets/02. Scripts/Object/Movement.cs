using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxis("Horizontal"); // ���� Z�� ��
        //float v = Input.GetAxis("Vertical"); // ���� X�� ��

        float h = Input.GetAxisRaw("Horizontal"); // ���� Z�� ��
        float v = Input.GetAxisRaw("Vertical"); // ���� X�� ��

        Vector3 dir = new Vector3(h, 0, v).normalized;
        //Vector3 dir = new Vector3(h, 0, v);
        //Vector3 normalDir = dir.normalized; // ����ȭ ���� (0 ~ 1)


        //Debug.Log($"���� �Է� : {dir}");

        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.LookAt(transform.position + dir);
    }
}
