using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    // Coin을 위해 SpawnManager 불러오기
    public SpawnManager spawner;

    private SpriteRenderer sRenderer;
    private Animator animator;

    [SerializeField] protected float hp = 3f;
    [SerializeField] protected float moveSpeed = 3f;

    // 화면 끝까지 가면 방향을 바꾸기 위한 값
    private int dir = 1;
    public int Dir
    {
        get { return dir; }
        set { dir = value; }
    }

    // 공격할 때에는 움직이지 않도록 하기 위해 선언한 값
    private bool isMove = true;
    private bool isHit = false;

    public abstract void Init();

    void Awake()
    {
        spawner = FindFirstObjectByType<SpawnManager>();

        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        Init();
    }

    void OnMouseDown()
    {
        //Hit(1);
        StartCoroutine(Hit(1));
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!isMove)
            return;

        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
            dir = -1;
        else if (transform.position.x < -8f)
            dir = 1;

        SetFlip(dir);
    }

    public void SetFlip(int dir)
    {
        if (dir > 0)
            sRenderer.flipX = false;
        else
            sRenderer.flipX = true;
    }

    public IEnumerator Hit(float damage)
    {
        if (isHit)
            yield break;

        isHit = true;
        isMove = false;
        
        hp -= damage;

        if (hp <= 0)
        {
            animator.SetTrigger("[Trigger] Death");

            spawner.DropCoin(transform.position); // 코인 생성

            yield return new WaitForSeconds(3f);
            Destroy(gameObject);

            yield break;
        }

        animator.SetTrigger("[Trigger] Hit");

        // 애니메이션 동작을 위해 코루틴을 사용해서 잠깐 오브젝트 멈춰주기
        yield return new WaitForSeconds(0.65f);
        isHit = false;
        isMove = true;
    }
}

