using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monsterState = MonsterState.IDLE; // 안 적어도 IDLE(가장 앞)이 기본값

    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;

    public Transform target;

    public float hp;
    public float speed;
    public float attackTime;

    protected float moveDir;
    protected float targetDist;

    protected bool isTrace;

    protected virtual void Init(float hp, float speed, float attackTime)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;

        target = GameObject.FindGameObjectWithTag("Player").transform; // 태그가 적을 경우 사용
        // target = FindFirstObjectByType<KnightController_Keyboard>().transform; // 일반적으로 찾는 방법

        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();
    }

    void Update()
    {
        targetDist = Vector3.Distance(transform.position, target.position);

        Vector3 monsterDir = Vector3.right * moveDir; // 몬스터가 바라보는 방향
        Vector3 playerDir = (transform.position - target.position).normalized; // 플레이어가 몬스터를 바라보는 방향

        float dotValue = Vector3.Dot(monsterDir, playerDir);
        isTrace = dotValue < -0.5f && dotValue >= -1f;
        //isTrace = Vector3.Dot(monsterDir, playerDir) < 0; // 0보다 작으면 서로 마주보고 있는 상태

        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if (monsterState != newState) // 몬스터 State가 새로 설정하는 State와 다를경우
            monsterState = newState;
    }
}