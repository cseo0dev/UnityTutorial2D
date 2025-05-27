using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed;

    public bool isStop; // false (�⺻��)

    void Start()
    {
        rotSpeed = 0f;
    }

    void Update()
    {
        // �귿�� �ڱ� �ڽ��� ���ƾ��ϴϱ� Rotate ���
        transform.Rotate(Vector3.forward * rotSpeed);

        // ���콺 ������ Ŭ���Ͽ��� �� ȸ���ϵ��� ���� (Down �Լ��� �ѹ��� ����)
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
        }

        // �����̽��ٸ� ������ ��
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            isStop = true;
        }

        if (isStop == true)
        {
            rotSpeed *= 0.99f;

            if (rotSpeed < 0.01f)
            {
                // �ӵ��� ���� ���ҽ�Ű�� ���
                rotSpeed = 0f;
                isStop = false;
            }
        }
    }
}
