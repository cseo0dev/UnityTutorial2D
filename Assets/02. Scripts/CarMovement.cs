using System.Data.Common;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    
    public Rigidbody2D carRb; // GetComponent<Rigidbody2D>()

    private float h;

    // ���ɿ� ���� �ٸ� ���������� ����Ǵ� �ݹ��Լ�
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // ���� (X��)

        // Transform�� ���ؼ� �̵��߱� ������ �������� ����
        // transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    // ���� ���������� ����Ǵ� �ݹ��Լ�
    void FixedUpdate()
    {
        // Rigidbody �̵�
        carRb.linearVelocityX = h * moveSpeed; // h���� ������Ʈ �ݹ��Լ����� ����־����� ���⼭�� ��� ����!
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log($"{collision.gameObject.name} �浹!");
        
    //    // ������ �����
    //    // collision.gameObject.SetActive(false);
    //}

    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log($"{collision.gameObject.name} ����!");
    //}

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log($"{collision.gameObject.name} �浹 ��!");
    //}
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("Trigger Enter");
    //}

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log("Trigger Stay");
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    Debug.Log("Trigger Exit");
    //}
}
