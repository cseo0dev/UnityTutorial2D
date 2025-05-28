using System.Data.Common;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    
    public Rigidbody2D carRb; // GetComponent<Rigidbody2D>()

    private float h;

    // 성능에 따라 다른 프레임으로 실행되는 콜백함수
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // 수평값 (X값)

        // Transform을 통해서 이동했기 때문에 떨림현상 있음
        // transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    // 고정 프레임으로 실행되는 콜백함수
    void FixedUpdate()
    {
        // Rigidbody 이동
        carRb.linearVelocityX = h * moveSpeed; // h값을 업데이트 콜백함수에서 집어넣었으니 여기서도 사용 가능!
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log($"{collision.gameObject.name} 충돌!");
        
    //    // 닿으면 사라짐
    //    // collision.gameObject.SetActive(false);
    //}

    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log($"{collision.gameObject.name} 유지!");
    //}

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log($"{collision.gameObject.name} 충돌 끝!");
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
