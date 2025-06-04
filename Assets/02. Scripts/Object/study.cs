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

        // 꺼져있는 오브젝트까지 찾기 위하여 true 넣어주기
        renderes = GetComponentsInChildren<SpriteRenderer>(true);
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        // 순간적인 물리 움직임은 Fixed에 구현하면 즉시 반응이 아니여서 Update에 구현
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 캐릭터 움직임에 따라 이미지의 Flip 상태가 변하는 코드
    /// </summary>
    private void Move()
    {
        if (h != 0) // 움직일 때
        {
            renderes[0].gameObject.SetActive(false); // Idel
            renderes[1].gameObject.SetActive(true); // Run

            // 리지드바디는 물리적 이동이라 Fixed에서 구현해주어야 함
            characterRb.linearVelocityX = h * moveSpeed;
        }
        else // 안 움직일 때
        {
            renderes[0].gameObject.SetActive(true); // Idel
            renderes[1].gameObject.SetActive(false); // Run
        }

        // 시야 방향 (플립)
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