using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRb;
    public float jumpPower = 10f;
    public bool isGround = false;

    public int jumpCount = 0;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 점프 구현 - 바닥에서 점프할 때만 점프가능(중복 방지)
        //if (Input.GetKeyDown(KeyCode.Space) && isGround)
        //{
        //    catRb.AddForceY(jumpPower, ForceMode2D.Impulse); // Impulse 순간적으로 힘을 가하는 방식
        //}

        // 2단 점프 구현
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
