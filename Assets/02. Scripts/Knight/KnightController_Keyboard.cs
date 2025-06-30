using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;

    private float atkDamage = 3f;

    private bool isGround;
    private bool isAttack;
    private bool isCombo;
    private bool isLadder;

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputKeyboard();
        Jump();
        Attack();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("[Bool] IsGround", true);
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("[Bool] IsGround", false);
            isGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage} 데미지로 공격");
        }
        
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            // 물리적인 값이 남아있을 수 있으므로 초기화
            knightRb.gravityScale = 0f; // 사다리에서는 중력으로 인한 떨어짐이 없어야 함
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 2f;
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        inputDir = new Vector3(h, v, 0);

        // 애니메이터 파라미터에 값 전달 => 애니메이션 동작
        animator.SetFloat("[Float] JoystickX", inputDir.x);
        animator.SetFloat("[Float] JoystickY", inputDir.y);

        // 몸을 숙였을 때 콜라이더 값 변환
        if (inputDir.y < 0)
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 0.3f);
        else
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 1f);

    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            knightRb.linearVelocityX = inputDir.x * moveSpeed;
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("[Trigger] Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isAttack)
            {
                isAttack = true;
                atkDamage = 3f;
                animator.SetTrigger("[Trigger] Attack");
            }
            else
                isCombo = true;
        }
    }

    public void CheckCombo()
    {
        if (isCombo)
        {
            atkDamage = 5f;
            animator.SetBool("[Bool] IsCombo", true);
        }
        else
        {
            animator.SetBool("[Bool] IsCombo", false);
            isAttack = false;
        }
    }

    public void EndCombo()
    {
        isAttack = false;
        isCombo = false;
    }
}