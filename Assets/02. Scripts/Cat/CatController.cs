using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public float jumpPower = 10f;
    public float limitPower = 9f;

    public bool isGround = false;

    public int jumpCount = 0;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // 2�� ���� ����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("IsGround", false);

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;

            soundManager.OnJumpSound();

            // ���� ���� ���� (Ű���� �Է¿� ���� ���� �����̰� �޶��� ���� ����)
            if(catRb.linearVelocityY > limitPower)
                catRb.linearVelocityY = limitPower;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // ���� ���� �� ��� ���� �ִϸ��̼��� �۵��ǵ���
            catAnim.SetBool("IsGround", true);

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
