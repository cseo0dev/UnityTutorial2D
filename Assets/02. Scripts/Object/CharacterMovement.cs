using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderes; // Flip ����� �������� �־

    public float moveSpeed;
    public float jumpPower = 10f;
    private float h;

    private bool isGround;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();

        // �����ִ� ������Ʈ���� ã�� ���Ͽ� true �־��ֱ�
        renderes = GetComponentsInChildren<SpriteRenderer>(true);

        // �̰� ����?
        // GameObject obj = FindObjectOfType(typeof(GameObject)) as GameObject;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        // �������� ���� �������� Fixed�� �����ϸ� ��� ������ �ƴϿ��� Update�� ����
        Jump();
    }

    private void FixedUpdate()
    { 
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGround = true;

        renderes[2].gameObject.SetActive(false); // Jump
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGround = false;

        renderes[0].gameObject.SetActive(false); // Idle
        renderes[1].gameObject.SetActive(false); // Run
        renderes[2].gameObject.SetActive(true); // Jump
    }

    /// <summary>
    /// ĳ���� �����ӿ� ���� �̹����� Flip ���°� ���ϴ� �ڵ�
    /// </summary>
    private void Move()
    {
        if (!isGround) return;

        if (h != 0) // ������ ��
        {
            renderes[0].gameObject.SetActive(false); // Idel
            renderes[1].gameObject.SetActive(true); // Run

            // ������ٵ�� ������ �̵��̶� Fixed���� �������־�� ��
            characterRb.linearVelocityX = h * moveSpeed;

            if (h > 0) // �����ʺ� ��
            {
                renderes[0].flipX = false;
                renderes[1].flipX = false;
                renderes[2].flipX = false;
            }
            else if (h < 0) // ���ʺ� ��
            {
                renderes[0].flipX = true;
                renderes[1].flipX = true;
                renderes[2].flipX = true;
            }
        }
        else // �� ������ ��
        {
            renderes[0].gameObject.SetActive(true); // Idel
            renderes[1].gameObject.SetActive(false); // Run
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump")) // = Input.GetKeyDown(KeyCode.Space)
        {
            characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
}