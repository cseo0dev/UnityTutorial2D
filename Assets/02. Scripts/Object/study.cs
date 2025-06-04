using UnityEngine;

public class study : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderes;

    public float moveSpeed;
    private float h;

    public float jumpPower = 10f;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();

        // �����ִ� ������Ʈ���� ã�� ���Ͽ� true �־��ֱ�
        renderes = GetComponentsInChildren<SpriteRenderer>(true);
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

    /// <summary>
    /// ĳ���� �����ӿ� ���� �̹����� Flip ���°� ���ϴ� �ڵ�
    /// </summary>
    private void Move()
    {
        if (h != 0) // ������ ��
        {
            renderes[0].gameObject.SetActive(false); // Idel
            renderes[1].gameObject.SetActive(true); // Run

            // ������ٵ�� ������ �̵��̶� Fixed���� �������־�� ��
            characterRb.linearVelocityX = h * moveSpeed;
        }
        else // �� ������ ��
        {
            renderes[0].gameObject.SetActive(true); // Idel
            renderes[1].gameObject.SetActive(false); // Run
        }

        // �þ� ���� (�ø�)
        if (h > 0)
        {
            renderes[0].flipX = false;
            renderes[1].flipX = false;
        }
        else if (h < 0)
        {
            renderes[0].flipX = true;
            renderes[1].flipX = true;
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