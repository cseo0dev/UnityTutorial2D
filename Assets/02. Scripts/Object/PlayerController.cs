using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject hitBox;

    [SerializeField] private float moveSpeed = 3f;
    private float h, v;

    private bool isAttack = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h == 0 && v ==0) // Idle 상태
        {
            animator.SetBool("[Bool] Run", false);
        }
        else // Run 상태
        {
            // 플레이어 방향키에 맞게 왼,오 쳐다보게 설정
            int scaleX = h > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            animator.SetBool("[Bool] Run", true);

            var dir = new Vector3(h, v, 0).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    // 무기가 부웅~ 하는 걸 구현해줄 거임
    IEnumerator AttackRoutine()
    {
        isAttack = true;
        hitBox.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        hitBox.SetActive(false);
        isAttack = false;
    }

    // 몬스터 공격
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Monster>() != null)
        {
            Monster monster = other.GetComponent<Monster>();
            Debug.Log("몬스터에게 공격 성공!");
            StartCoroutine(monster.Hit(1)); // Monster 스크립트에 Hit 코루틴 public으로 선언
        }
    }

    // 아이템 획득
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get();
        }
    }
}
