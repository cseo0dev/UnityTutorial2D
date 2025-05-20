using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        // ������ ���� ���
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        // �ڷ� ���� ���
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        // �������� ���� ���
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        // ���������� ���� ���
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

    }
}
