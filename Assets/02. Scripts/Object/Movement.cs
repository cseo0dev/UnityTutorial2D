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
        //float h = Input.GetAxis("Horizontal"); // 수평 Z의 값
        //float v = Input.GetAxis("Vertical"); // 수직 X의 값

        float h = Input.GetAxisRaw("Horizontal"); // 수평 Z의 값
        float v = Input.GetAxisRaw("Vertical"); // 수직 X의 값

        Vector3 dir = new Vector3(h, 0, v).normalized;
        //Vector3 dir = new Vector3(h, 0, v);
        //Vector3 normalDir = dir.normalized; // 정규화 과정 (0 ~ 1)


        //Debug.Log($"현재 입력 : {dir}");

        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.LookAt(transform.position + dir);
    }
}
