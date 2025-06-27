using UnityEngine;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;

    [SerializeField] private float moveSpeed = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }

    void OnCollisionExit2D(Collision2D other)
    {

    }

    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized;

        // 애니메이터 파라미터에 값 전달 => 애니메이션 동작
        animator.SetFloat("[Float] JoystickX", inputDir.x);
        animator.SetFloat("[Float] JoystickY", inputDir.y);

        // Flip
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }

    void Move()
    {
        if (inputDir.x != 0)
            knightRb.linearVelocity = inputDir * moveSpeed;
    }
}