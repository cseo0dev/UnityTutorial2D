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

        // 앞으로 가는 기능
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        // 뒤로 가는 기능
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        // 왼쪽으로 가는 기능
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        // 오른쪽으로 가는 기능
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

    }
}
